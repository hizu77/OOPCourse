using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Proxy;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.RecipientTypes;
using Itmo.ObjectOrientedProgramming.Lab3.TextWriters;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Users.MessageStatus;
using Itmo.ObjectOrientedProgramming.Lab3.Users.ReadResult;
using NSubstitute;
using Xunit;

namespace Lab3.Tests;

public class UnitTests
{
    [Fact]
    public void TryReceiveMessage_ShouldReturnUnRead_WhenReceiverUser()
    {
        // Arrange
        var message = new Message(title: "lol", text: "Hello, bro!", priority: 1);
        var user = new User("Mike");
        var recipient = new UserAddressee(user);
        Topic topic = Topic.Builder
            .AddRecipient(recipient)
            .WithName("Top")
            .Build();

        // Act
        topic.SendRecipientMessage(message);
        MessageCheckStatusResult result = user.CheckMessageStatus(message);

        // Assert
        Assert.IsType<Status.UnRead>(((MessageCheckStatusResult.Success)result).Status);
    }

    [Fact]
    public void TryReadMessage_ShouldReturnReadStatus_WhenMessageStatusWasUnRead()
    {
        // Arrange
        var message = new Message(title: "lol", text: "Hello, bro!", priority: 1);
        var user = new User("Mike");
        var recipient = new UserAddressee(user);
        Topic topic = Topic.Builder
            .AddRecipient(recipient)
            .WithName("Top")
            .Build();

        // Act
        topic.SendRecipientMessage(message);
        MessageReadResult result = user.ReadMessage(message);
        MessageCheckStatusResult statusResult = user.CheckMessageStatus(message);

        // Assert
        Assert.IsType<MessageReadResult.Success>(result);
        Assert.IsType<Status.Read>(((MessageCheckStatusResult.Success)statusResult).Status);
    }

    [Fact]
    public void TryReadMessage_ShouldReturnMessageReadFailure_WhenMessageStatusWasRead()
    {
        // Arrange
        var message = new Message(title: "lol", text: "Hello, bro!", priority: 1);
        var user = new User("Mike");
        var recipient = new UserAddressee(user);
        Topic topic = Topic.Builder
            .AddRecipient(recipient)
            .WithName("Top")
            .Build();

        // Act
        topic.SendRecipientMessage(message);
        user.ReadMessage(message);
        MessageReadResult result = user.ReadMessage(message);

        // Assert
        Assert.IsType<MessageReadResult.MessageAlreadyRead>(result);
    }

    [Fact]
    public void TrySendMessage_ShouldNotReceiveMessage_WhenMismatchesFilter()
    {
        // Arrange
        var message = new Message(title: "lol", text: "Hello, bro!", priority: 1);
        IUser user = Substitute.For<IUser>();
        var filteredRecipient = new FilteringAddresseeProxy(x => x.Priority > 3, new UserAddressee(user));
        Topic topic = Topic.Builder
            .AddRecipient(filteredRecipient)
            .WithName("Top")
            .Build();

        // Act
        topic.SendRecipientMessage(message);

        // Assert
        user.DidNotReceive().ReceiveMessage(message);
    }

    [Fact]
    public void TrySendMessage_ShouldReceiveTwoMessage_WhenMatchesFilter()
    {
        // Arrange
        var message = new Message(title: "lol", text: "Hello, bro!", priority: 4);
        IUser user = Substitute.For<IUser>();
        var filteredRecipient = new FilteringAddresseeProxy(x => x.Priority > 1, new UserAddressee(user));
        Topic topic = Topic.Builder
            .AddRecipient(filteredRecipient)
            .WithName("Top")
            .Build();

        // Act
        topic.SendRecipientMessage(message);
        topic.SendRecipientMessage(message);

        // Assert
        user.Received(2).ReceiveMessage(message);
    }

    [Fact]
    public void TryLog_ShouldReceiveTwoMessage_WhenMatchesFilter()
    {
        // Arrange
        var message = new Message(title: "lol", text: "Hello, bro!", priority: 4);
        IDisplay display = Substitute.For<IDisplay>();
        ILogger logger = Substitute.For<ILogger>();
        var loggingRecipient = new LoggingAddresseeDecorator(new DisplayAddressee(display), logger);
        Topic topic = Topic.Builder
            .AddRecipient(loggingRecipient)
            .WithName("Top")
            .Build();

        // Act
        topic.SendRecipientMessage(message);

        // Assert
        logger.Received(1).Log("Redirected message lol");
        display.Received(1).ReceiveMessage(message.Format());
    }

    [Fact]
    public void TryReceiveMessage_ShouldEqual_WhenReceiverMessenger()
    {
        // Arrange
        var message = new Message(title: "lol", text: "Hello, bro!", priority: 4);
        ConsoleTextWriter writer = Substitute.For<ConsoleTextWriter>();
        IMessenger messenger = new Messenger(new ConsoleTextWriter());
        var recipient = new MessengerAddressee(messenger);
        Topic topic = Topic.Builder
            .AddRecipient(recipient)
            .WithName("Top")
            .Build();

        // Act
        topic.SendRecipientMessage(message);

        // Assert
        writer.Received(1).WriteText("Messenger: Hello, bro!");
    }

    [Fact]
    public void TryReceiveMessage_ShouldReceiveOnce_WhenReceiverUser()
    {
        // Arrange
        var message = new Message(title: "lol", text: "Hello, bro!", priority: 2);
        IUser user = Substitute.For<IUser>();
        var filteringRecipient = new FilteringAddresseeProxy(x => x.Priority > 3, new UserAddressee(user));

        GroupAddressee addressee = GroupAddressee.Builder
            .AddRecipient(new UserAddressee(user))
            .AddRecipient(filteringRecipient)
            .Build();

        Topic topic = Topic.Builder
            .AddRecipient(addressee)
            .WithName("Top")
            .Build();

        // Act
        topic.SendRecipientMessage(message);

        // Assert
        user.Received(1).ReceiveMessage(message);
    }
}