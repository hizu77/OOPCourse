using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Proxy;

public class FilteringAddresseeProxy : IAddressee
{
    private readonly Func<Message, bool> _filter;
    private readonly IAddressee _addressee;

    public FilteringAddresseeProxy(Func<Message, bool> filter, IAddressee addressee)
    {
        _filter = filter;
        _addressee = addressee;
    }

    public void ReceiveMessage(Message message)
    {
        if (!_filter(message))
        {
            return;
        }

        _addressee.ReceiveMessage(message);
    }
}