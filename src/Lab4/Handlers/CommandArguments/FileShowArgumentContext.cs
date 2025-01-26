using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

[GenerateBuilder]
public partial record FileShowArgumentsContext(
    string? Address,
    WriterType? WriterType);