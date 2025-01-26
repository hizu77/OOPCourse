using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParsers;

public interface ICommandParser
{
    ICommand? ParseCommand(IEnumerable<string> args);
}