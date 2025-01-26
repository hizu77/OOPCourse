using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

[GenerateBuilder]
public partial record FileMoveArgumentsContext(
    string? Source,
    string? Destination);