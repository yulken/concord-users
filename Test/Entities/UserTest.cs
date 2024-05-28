using concord_users.Src.Domain.Entities;
using NUnit.Framework;

namespace concord_users.Test.Entities
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void ShouldCreate_IfAllDataIsProvided()
        {
            User userModel = new(
                "John",
                "john@example.com",
                "john",
                "password"
            );
            Assert.Multiple(() =>
            {
                Assert.That(userModel.Name, Is.EqualTo("John"));
                Assert.That(userModel.Email, Is.EqualTo("john@example.com"));
                Assert.That(userModel.Login, Is.EqualTo("john"));
            });
        }
        [Test]
        public void Shouldthrow_IfDataIsMissing()
        {

            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentNullException>(() => new User(null, "john@example.com", "john", "password"));
                Assert.Throws<ArgumentNullException>(() => new User("John", null, "john", "password"));
                Assert.Throws<ArgumentNullException>(() => new User("John", "john@example.com", null, "password"));
                Assert.Throws<ArgumentNullException>(() => new User("John", "john@example.com", "john",null));
            });           
        }

        [Test]
        public void ShouldValidatePassword()
        {
            User userModel = new(
                "John",
                "john@example.com",
                "john",
                "correct_password"
            );
            Assert.Multiple(() =>
            {
                Assert.That(userModel.IsPasswordCorrect("correct_password"), Is.True);
                Assert.That(userModel.IsPasswordCorrect("wrong_password"), Is.False);
            });
            
        }

        [Test]
        public void ShouldValidateUuid()
        {
            User userModel = new(
                "John",
                "john@example.com",
                "john",
                "password"
            );
            Assert.Multiple(() =>
            {
                Assert.That(userModel.IsSelf(Guid.NewGuid()), Is.False);
            });

        }
    }
}
