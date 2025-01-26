using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lab.LabBuilder;

public class LabworkBuilder
{
    private string? _name;
    private string? _description;
    private string? _evaluationCriteria;
    private Point? _points;
    private IUser? _author;
    private long? _id;

    public LabworkBuilder(IUser? author = null)
    {
        _author = author;
    }

    public LabworkBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public LabworkBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public LabworkBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public LabworkBuilder WithCriteria(string criteria)
    {
        _evaluationCriteria = criteria;
        return this;
    }

    public LabworkBuilder WithPoints(Point points)
    {
        _points = points;
        return this;
    }

    public LabworkBuilder WithAuthor(IUser author)
    {
        _author = author;
        return this;
    }

    public ILabwork Build()
    {
        return new Labwork(
            _id ?? throw new ArgumentNullException(),
            _name ?? throw new ArgumentNullException(),
            _description ?? throw new ArgumentNullException(),
            _evaluationCriteria ?? throw new ArgumentNullException(),
            _points ?? throw new ArgumentNullException(),
            _author ?? throw new ArgumentNullException());
    }
}