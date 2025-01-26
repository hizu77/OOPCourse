namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger
{
    void ReceiveMessage(string message);

    void DisplayText(string message);
}