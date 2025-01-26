using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemModes;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

[GenerateBuilder]
public partial record ConnectArgumentsContext(
    string? Address,
    FileSystemMode? FileSystemMode);