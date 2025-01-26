using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Generator;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lab;

public class Labwork : ILabwork, IPrototype<Labwork>
{
    public Labwork(
        long id,
        string name,
        string description,
        string evaluationCriteria,
        Point points,
        IUser user,
        long? baseId = null)
    {
        Id = id;
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        Points = points;
        Author = user;
        BaseId = baseId;
    }

    public Point Points { get;  }

    public IUser Author { get; }

    public string Name { get; private set; }

    public long Id { get; }

    public long? BaseId { get; } = null;

    public string Description { get; private set; }

    public string EvaluationCriteria { get; private set; }

    public EditResult EditDescription(IUser user, string description)
    {
        if (Author.Id != user.Id)
        {
            return new EditResult.Failed();
        }

        Description = description;

        return new EditResult.Success();
    }

    public EditResult EditEvaluationCriteria(IUser user, string criteria)
    {
        if (Author.Id != user.Id)
        {
            return new EditResult.Failed();
        }

        EvaluationCriteria = criteria;

        return new EditResult.Success();
    }

    public EditResult EditName(IUser user, string name)
    {
        if (Author.Id != user.Id)
        {
            return new EditResult.Failed();
        }

        Name = name;

        return new EditResult.Success();
    }

    public Labwork Clone()
    {
        long randomId = GeneratorId.Generate();

        return new Labwork(
            randomId,
            Name,
            Description,
            EvaluationCriteria,
            Points,
            Author.Clone(),
            Id);
    }

    ILabwork ILabwork.Clone()
    {
        return Clone();
    }
}