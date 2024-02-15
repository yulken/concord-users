using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Exceptions;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Impl;
using concord_users.Src.Domain.UseCases.Input;
using Moq;
using NUnit.Framework;

namespace concord_users.Test.UseCases
{
    [TestFixture]
    public class CreateUserUseCaseTest
    {
        private Mock<IUserPersistencePort> _portMock = new();
        private CreateUserUseCase _useCase;

        [SetUp]
        public void Setup()
        {
            var logger = TestDependencies.GetLogger<CreateUserUseCase>();
            var mapper = TestDependencies.GetMapper();
            _useCase = new CreateUserUseCase(logger, _portMock.Object, mapper);
        }

        [TearDown]
        public void Teardown()
        {
            _portMock.Invocations.Clear();
        }

        [Test]
        public void ShouldReturnUuid_IfUserCreatedSuccessfully()
        {
            CreateUserInput input = new(
                "João da Silva",
                "joao@gmail.com",
                "12345678",
                "joaozinho",
                "s3://fdfdsk"
                );

            User expectedUser = new()
            {
                Uuid = "uuid"
            };

            User? capturedUser = new();
            _portMock.Setup(m => m.Create(It.IsAny<User>())).Returns(expectedUser)
                .Callback<User>(u => capturedUser = u);


            string result = _useCase.Execute(input);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expectedUser.Uuid));
                Assert.That(capturedUser.Name, Is.EqualTo("João da Silva"));
            });

            _portMock.Verify(m => m.Create(It.IsAny<User>()), Times.Once());

        }

        [Test]
        public void ShouldThrow_IfPersistencePortReturnsNull()
        {
            CreateUserInput input = new(
                "João da Silva",
                "joao@gmail.com",
                "12345678",
                "joaozinho",
                "s3://fdfdsk"
                );

            User expectedUser = new()
            {
                Uuid = "uuid"
            };

            _portMock.Setup(m => m.FindByEmailOrLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(new User());

            Assert.Throws<ConflictingDataException>(() => _useCase.Execute(input));
            _portMock.Verify(m => m.FindByEmailOrLogin("joao@gmail.com", "joaozinho"), Times.Once());
        }


    }
}
