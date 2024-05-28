using concord_users.Src.Domain.Entities;
using concord_users.Src.Domain.Exceptions;
using concord_users.Src.Domain.Ports.Persistence;
using concord_users.Src.Domain.UseCases.Users.Impl;
using concord_users.Src.Domain.UseCases.Users.Input;
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
            _useCase = new CreateUserUseCase(logger, _portMock.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _portMock.Invocations.Clear();
        }

        [Test]
        public void ShouldReturnUuid_IfUserCreatedSuccessfully()
        {
            CreateUserInput input = SampleCreateUserInput();
            User expectedUser = CreateFromInput(input);
            expectedUser.Uuid = Guid.Parse("7f18e929-ad08-45f8-bf68-d688f1e36ac7");
            
            User? capturedUser = null;
            _portMock.Setup(m => m.Create(It.IsAny<User>())).Returns(expectedUser)
                .Callback<User>(u => capturedUser = u);

            string result = _useCase.Execute(input);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expectedUser.Uuid.ToString()));
                Assert.That(capturedUser?.Name, Is.EqualTo("John"));
                _portMock.Verify(m => m.Create(It.IsAny<User>()), Times.Once());
            });

        }

        [Test]
        public void ShouldThrow_IfPersistencePortReturnsUser()
        {
            CreateUserInput input = SampleCreateUserInput();
            User mockUser = CreateFromInput(input);

            _portMock.Setup(m => m.FindByEmailOrLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(mockUser);

            Assert.Throws<ConflictingDataException>(() => _useCase.Execute(input));
        }

        private static CreateUserInput SampleCreateUserInput()
        {
            return new(
                "John",
                "john@example.com",
                "correct_password",
                "john"
                );
        }

        private static User CreateFromInput(CreateUserInput input)
        {
            return new(
                input.Name,
                input.Email,
                input.Login,
                input.Password
            );
        }


    }
}
