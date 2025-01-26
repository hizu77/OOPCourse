﻿using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

[GenerateBuilder]
public partial record TreeGoToArgumentsContext(
    string? Path);