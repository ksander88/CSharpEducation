namespace Phonebook;
using NUnit.Framework;

[TestFixture]
public class PhonebookTests
{
    [Test]
    public void AddSubscriber_ValidSubscriber_AddsToCollection()
    {
        // Arrange
        var phonebook = new Phonebook();
        var subscriber = new Subscriber(Guid.NewGuid(), "Alice", new List<PhoneNumber>());

        // Act
        phonebook.AddSubscriber(subscriber);

        // Assert
        CollectionAssert.Contains(phonebook.GetAll(), subscriber);
    }

    [Test]
    public void AddSubscriber_DuplicateSubscriber_ThrowsInvalidOperationException()
    {
        // Arrange
        var subscriber = new Subscriber(Guid.NewGuid(), "Alice", new List<PhoneNumber>());
        var phonebook = new Phonebook(new List<Subscriber> { subscriber });

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => phonebook.AddSubscriber(subscriber));
    }

    [Test]
    public void DeleteSubscriber_ExistingSubscriber_RemovesFromCollection()
    {
        // Arrange
        var subscriber = new Subscriber(Guid.NewGuid(), "Alice", new List<PhoneNumber>());
        var phonebook = new Phonebook(new List<Subscriber> { subscriber });

        // Act
        phonebook.DeleteSubscriber(subscriber);

        // Assert
        CollectionAssert.DoesNotContain(phonebook.GetAll(), subscriber);
    }

    [Test]
    public void RenameSubscriber_ValidName_UpdatesName()
    {
        // Arrange
        var subscriber = new Subscriber(Guid.NewGuid(), "Alice", new List<PhoneNumber>());
        var phonebook = new Phonebook(new List<Subscriber> { subscriber });
        string newName = "Bob";

        // Act
        phonebook.RenameSubscriber(subscriber, newName);
        var updatedSubscriber = phonebook.GetSubscriber(subscriber.Id);

        // Assert
        Assert.AreEqual(newName, updatedSubscriber.Name);
    }
}