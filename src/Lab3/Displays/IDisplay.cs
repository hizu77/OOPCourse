namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    void ReceiveMessage(string message);

    void DisplayText(string message);
}