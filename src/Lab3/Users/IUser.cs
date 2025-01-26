using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.ReadResult;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    string Name { get; }

    MessageCheckStatusResult CheckMessageStatus(Message message);

    MessageReadResult ReadMessage(Message message);

    void ReceiveMessage(Message message);
}