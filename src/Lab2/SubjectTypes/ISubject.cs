using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Lab;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes;

public interface ISubject : IIdentifiable
{
    long? BaseId { get; }

    IReadOnlyCollection<ILabwork> Labworks { get; }

    IReadOnlyCollection<ILectureMaterials> Materials { get; }

    Point Points { get; }

    ISubject Clone();

    EditResult EditName(IUser user, string newName);

    EditResult EditMaterials(IUser user, IReadOnlyCollection<ILectureMaterials> materials);
}