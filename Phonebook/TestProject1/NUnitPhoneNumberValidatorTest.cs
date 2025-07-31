using NUnit.Framework;
using Phonebook;

namespace Phonebook.Tests;

[TestFixture]
public class PhoneNumberValidatorTests
{
    [Test]
    public void Validate_ValidPhoneNumber_DoesNotThrow()
    {
        // Arrange
        var number = "+7 (123) 456-7890";
        var phoneNumber = new PhoneNumber(number, PhoneNumberType.Personal);

        // Act & Assert
        Assert.DoesNotThrow(() => PhoneNumberValidator.Validate(phoneNumber));
    }
}