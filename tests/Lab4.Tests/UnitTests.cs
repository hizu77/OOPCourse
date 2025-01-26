using Itmo.ObjectOrientedProgramming.Lab4.CommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.DomainHandlers;
using Xunit;

namespace Lab4.Tests;

public class UnitTests
{
    [Fact]
    public void Handle_ShouldReturnConnectCommand_WhenCommandIsCorrect()
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = @"connect C:Kek\lol -m local".Split().ToList();
        var parser = new CommandParser(parameterHandler);
        ConnectArgumentsContext context = new ConnectArgumentsContext.Builder()
            .WithAddress("C:Kek\\lol")
            .WithFileSystemMode(FileSystemMode.Local)
            .Build();

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.IsType<ConnectCommand>(command);
    }

    [Theory]
    [InlineData(@"connect C:Kek\lol -r local")]
    [InlineData("connect -m local")]
    [InlineData(@"connect C:Kek\lol")]
    [InlineData(@"connect C:Kek\lol -m virtual")]
    [InlineData(@"conneeeect add C:Kek\lol -m local")]
    [InlineData(@"connect C:Kek\lol add -m local")]
    [InlineData(@"connect C:Kek\lol -m add local")]
    [InlineData(@"connect C:Kek\lol -m local faf")]
    [InlineData(@"ad connect C:Kek\lol -m local faf")]
    public void Handle_ShouldReturnNull_WhenCommandInCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.Null(command);
    }

    [Fact]
    public void Handle_ShouldReturnDisconnectCommand_WhenCommandIsCorrect()
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = @"disconnect".Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.IsType<DisconnectCommand>(command);
        Assert.Equal(new DisconnectCommand(), command);
    }

    [Theory]
    [InlineData("disconnddect")]
    [InlineData("aff disconnect")]
    [InlineData("disconnect dgg")]
    public void Handle_ShouldReturnNullDisconnect_WhenCommandIsInCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.Null(command);
    }

    [Fact]
    public void Handle_ShouldReturnTreeGoToCommand_WhenCommandIsCorrect()
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = @"tree goto C:Kek\lol".Split().ToList();
        var parser = new CommandParser(parameterHandler);
        TreeGoToArgumentsContext context = new TreeGoToArgumentsContext.Builder()
            .WithPath("C:Kek\\lol")
            .Build();

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.IsType<TreeGoToCommand>(command);
    }

    [Theory]
    [InlineData(@"tree goto")]
    [InlineData(@"goto C:Kek\lol")]
    [InlineData(@"tree C:Kek\lol")]
    [InlineData(@"treee goto C:Kek\lol")]
    [InlineData(@"tree gofto C:Kek\lol")]
    [InlineData(@"ff tree goto C:Kek\lol")]
    [InlineData(@"tree df goto C:Kek\lol")]
    [InlineData(@"tree goto sff C:Kek\lol")]
    [InlineData(@"tree goto C:Kek\lol sffa")]
    public void Handle_ShouldReturnNullGoTo_WhenCommandIsInCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.Null(command);
    }

    [Theory]
    [InlineData(@"tree list -d 5")]
    [InlineData(@"tree list")]
    public void Handle_ShouldReturnTreeListCommand_WhenCommandIsCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.IsType<TreeListCommand>(command);
    }

    [Theory]
    [InlineData(@"tree list -d ed")]
    [InlineData(@"tree list -e 5")]
    [InlineData(@"tree list -d")]
    [InlineData(@"tree list ed")]
    [InlineData(@"list -d ed")]
    [InlineData(@"tree -d ed")]
    [InlineData(@"add tree list -d 4")]
    [InlineData(@"tree afaf list -d 4")]
    [InlineData(@"tree list ag -d 4")]
    [InlineData(@"tree list -d 4 sff")]
    public void Handle_ShouldReturnNullListCommand_WhenCommandIsInCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.Null(command);
    }

    [Fact]
    public void Handle_ShouldReturnFileShowCommand_WhenCommandIsCorrect()
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = @"file show C:Kek\lol -m console".Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.IsType<FileShowCommand>(command);
    }

    [Theory]
    [InlineData(@"file show C:Kek\lol -m ahahhah")]
    [InlineData(@"file show C:Kek\lol -r console")]
    [InlineData(@"file shosw C:Kek\lol -m console")]
    [InlineData(@"filee show C:Kek\lol -m console")]
    [InlineData(@"file show C:Kek\lol -m")]
    [InlineData(@"file show C:Kek\lol console")]
    [InlineData(@"file show -m console")]
    [InlineData(@"file C:Kek\lol -m console")]
    [InlineData(@"show C:Kek\lol -m console")]
    [InlineData(@"add file show C:Kek\lol -m console")]
    [InlineData(@"file af show C:Kek\lol -m console")]
    [InlineData(@"file show aff C:Kek\lol -m console")]
    [InlineData(@"file show C:Kek\lol af -m console")]
    [InlineData(@"file show C:Kek\lol -m afg console")]
    [InlineData(@"file show C:Kek\lol -m console afaf")]
    public void Handle_ShouldReturnNullFileShowCommand_WhenCommandIsInCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.Null(command);
    }

    [Fact]
    public void Handle_ShouldReturnFileMoveCommand_WhenCommandIsCorrect()
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = @"file move C:Kek\lol C:Kek\lolik".Split().ToList();
        var parser = new CommandParser(parameterHandler);
        FileMoveArgumentsContext context = new FileMoveArgumentsContext.Builder()
            .WithSource(@"C:Kek\lol")
            .WithDestination(@"C:Kek\lolik")
            .Build();

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.IsType<FileMoveCommand>(command);
    }

    [Theory]
    [InlineData(@"file movee C:Kek\lol C:Kek\lolik")]
    [InlineData(@"filee move C:Kek\lol C:Kek\lolik")]
    [InlineData(@"file move C:Kek\lol")]
    [InlineData(@"file C:Kek\lol C:Kek\lolik")]
    [InlineData(@"move C:Kek\lol C:Kek\lolik")]
    [InlineData(@"file aff move C:Kek\lol C:Kek\lolik")]
    [InlineData(@"file move aff C:Kek\lol C:Kek\lolik")]
    [InlineData(@"file move C:Kek\lol gss C:Kek\lolik")]
    [InlineData(@"file move C:Kek\lol C:Kek\lolik sgg")]
    public void Handle_ShouldReturnNullFileMoveCommand_WhenCommandIsInCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.Null(command);
    }

    [Fact]
    public void Handle_ShouldReturnFileCopyCommand_WhenCommandIsCorrect()
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = @"file copy C:Kek\lol C:Kek\lolik".Split().ToList();
        var parser = new CommandParser(parameterHandler);
        FileCopyArgumentsContext context = new FileCopyArgumentsContext.Builder()
            .WithSource(@"C:Kek\lol")
            .WithDestination(@"C:Kek\lolik")
            .Build();

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.IsType<FileCopyCommand>(command);
    }

    [Theory]
    [InlineData(@"file copyy C:Kek\lol C:Kek\lolik")]
    [InlineData(@"filee copy C:Kek\lol C:Kek\lolik")]
    [InlineData(@"file copy C:Kek\lol")]
    [InlineData(@"file C:Kek\lol C:Kek\lolik")]
    [InlineData(@"copy C:Kek\lol C:Kek\lolik")]
    [InlineData(@"file aff copy C:Kek\lol C:Kek\lolik")]
    [InlineData(@"file copy aff C:Kek\lol C:Kek\lolik")]
    [InlineData(@"file copy C:Kek\lol gss C:Kek\lolik")]
    [InlineData(@"file copy C:Kek\lol C:Kek\lolik sgg")]
    public void Handle_ShouldReturnNullFileCopyCommand_WhenCommandIsInCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.Null(command);
    }

    [Fact]
    public void Handle_ShouldReturnFileDeleteCommand_WhenCommandIsCorrect()
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = @"file delete C:Kek\lol".Split().ToList();
        var parser = new CommandParser(parameterHandler);
        FileDeleteArgumentsContext context = new FileDeleteArgumentsContext.Builder()
            .WithSource(@"C:Kek\lol")
            .Build();

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.IsType<FileDeleteCommand>(command);
    }

    [Theory]
    [InlineData(@"file delete")]
    [InlineData(@"delete C:Kek\lol")]
    [InlineData(@"file C:Kek\lol")]
    [InlineData(@"filee delete C:Kek\lol")]
    [InlineData(@"file deleete C:Kek\lol")]
    [InlineData(@"ff file delete C:Kek\lol")]
    [InlineData(@"file df delete C:Kek\lol")]
    [InlineData(@"file delete sff C:Kek\lol")]
    [InlineData(@"file delete C:Kek\lol sffa")]
    public void Handle_ShouldReturnNullFileDeleteCommand_WhenCommandIsInCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.Null(command);
    }

    [Fact]
    public void Handle_ShouldReturnFileRenameCommand_WhenCommandIsCorrect()
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = @"file rename C:Kek\lol bratik".Split().ToList();
        var parser = new CommandParser(parameterHandler);
        FileRenameArgumentsContext context = new FileRenameArgumentsContext.Builder()
            .WithSource(@"C:Kek\lol")
            .WithName("bratik")
            .Build();

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.IsType<FileRenameCommand>(command);
    }

    [Theory]
    [InlineData(@"file renamee C:Kek\lol misha")]
    [InlineData(@"filee rename C:Kek\lol misha")]
    [InlineData(@"file rename misha")]
    [InlineData(@"file C:Kek\lol misha")]
    [InlineData(@"copy C:Kek\lol misha")]
    [InlineData(@"file aff rename C:Kek\lol misha")]
    [InlineData(@"file rename aff C:Kek\lol misha")]
    [InlineData(@"file rename C:Kek\lol gss misha")]
    [InlineData(@"file rename C:Kek\lol misha sgg")]
    public void Handle_ShouldReturnNullFileRenameCommand_WhenCommandIsInCorrect(string request)
    {
        // Arrange
        var factory = new ParameterСhainFactory();
        IDomainParameterHandler parameterHandler = factory.Create();
        var args = request.Split().ToList();
        var parser = new CommandParser(parameterHandler);

        // Act
        ICommand? command = parser.ParseCommand(args);

        // Assert
        Assert.Null(command);
    }
}