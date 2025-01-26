using Itmo.ObjectOrientedProgramming.Lab4.CommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.DomainHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main()
    {
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();

        var parser = new CommandParser(parameterHandler);

        IFileSystemContext context = new FileSystemContext();

        while (true)
        {
            string? line = Console.ReadLine();

            if (line is null)
            {
                break;
            }

            ICommand? command = parser.ParseCommand(line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList());

            if (command is null)
            {
                Console.WriteLine("Invalid command, please try again");
                continue;
            }

            CommandExecutionResult executionResult = command.Execute(context);

            if (executionResult is CommandExecutionResult.Failure failure)
            {
                Console.WriteLine(failure.Error);
            }
        }
    }
}