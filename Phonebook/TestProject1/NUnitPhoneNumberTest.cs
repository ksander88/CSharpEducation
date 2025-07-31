namespace Phonebook;
using NUnit.Framework;

[TestFixture]
public class PhoneNumberTests
{
    [Test]
    public void PhoneNumber_Creation_SetsPropertiesCorrectly()
    {
        // Arrange
        string number = "+7 (123) 456-7890";
        var type = PhoneNumberType.Personal;

        // Act
        var phoneNumber = new PhoneNumber(number, type);

        // Assert
        Assert.AreEqual(number, phoneNumber.Number);
        Assert.AreEqual(type, phoneNumber.Type);
    }
}