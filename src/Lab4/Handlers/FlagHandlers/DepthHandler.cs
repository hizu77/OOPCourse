using Itmo.ObjectOrientedProgramming.Lab4.Handlers.CommandArguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers.FlagHandlers;

public class DepthHandler : FlagHandlerBase<TreeListArgumentsContext.Builder>
{
    public override TreeListArgumentsContext.Builder? Handle(
        IEnumerator<string> request,
        TreeListArgumentsContext.Builder builder)
    {
        if (request.Current is not "-d")
        {
            return Next?.Handle(request, builder);
        }

        if (request.MoveNext() is false)
        {
            return null;
        }

        if (!request.Current.All(char.IsDigit))
        {
            return null;
        }

        builder.WithDepth(int.Parse(request.Current));

        return builder;
    }
}