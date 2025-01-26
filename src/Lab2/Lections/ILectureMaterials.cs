using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lections;

public interface ILectureMaterials : IIdentifiable
{
    string Description { get; }

    string Content { get; }

    long? BaseId { get; }

    ILectureMaterials Clone();

    EditResult EditName(IUser user, string name);

    EditResult EditDescription(IUser user, string description);

    EditResult EditContent(IUser user, string content);
}