using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lab;

public interface ILabwork : IIdentifiable
{
    Point Points { get; }

    string Description { get; }

    string EvaluationCriteria { get; }

    ILabwork Clone();

    long? BaseId { get; }

    EditResult EditDescription(IUser user, string description);

    EditResult EditEvaluationCriteria(IUser user, string criteria);

    EditResult EditName(IUser user, string name);
}