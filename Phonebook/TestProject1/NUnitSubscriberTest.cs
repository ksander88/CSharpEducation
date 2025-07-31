namespace Phonebook;
using NUnit.Framework;

[TestFixture]
public class SubscriberTests
{
    [Test]
    public void Subscriber_Equals_ReturnsTrueForSameId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var subscriber1 = new Subscriber(id, "Shasha", new List<PhoneNumber>());
        var subscriber2 = new Subscriber(id, "Alex", new List<PhoneNumber>());

        // Act & Assert
        Assert.AreEqual(subscriber1, subscriber2);
        Assert.IsTrue(subscriber1.Equals(subscriber2));
    }

    [Test]
    public void Subscriber_GetHashCode_ReturnsSameForSameId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var subscriber1 = new Subscriber(id, "Sasha", new List<PhoneNumber>());
        var subscriber2 = new Subscriber(id, "Alex", new List<PhoneNumber>());

        // Act & Assert
        Assert.AreEqual(subscriber1.GetHashCode(), subscriber2.GetHashCode());
    }
}