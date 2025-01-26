using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemConfigs;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandHandler.FileHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandHandler.TreeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.DomainHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ParameterСhainFactory
{
    public IDomainParameterHandler Create()
    {
        var listFlagHandler = new DepthHandler();
        var showFlagHandler = new WriterTypeHandler();
        var connectFlagHandler = new FileSystemTypeHandler();

        IParameterHandler treeParameterHandler =
            new GoToHandler()
                .AddNext(new ListHandler(
                    listFlagHandler,
                    WriterType.Console,
                    new ComponentIcons(
                            FileSymbol: "+",
                            FolderSymbol: "#",
                            PaddingSymbols: "  ")));

        IParameterHandler fileParameterHandler =
            new ShowHandler(showFlagHandler)
                .AddNext(new MoveHandler())
                .AddNext(new CopyHandler())
                .AddNext(new DeleteHandler())
                .AddNext(new RenameHandler());

        IDomainParameterHandler parameterDomainHandler =
            new ConnectHandler(connectFlagHandler)
                .AddNext(new DomainParameterHandler("tree", treeParameterHandler))
                .AddNext(new DomainParameterHandler("file", fileParameterHandler))
                .AddNext(new DisconnectHandler());

        return parameterDomainHandler;
    }
}