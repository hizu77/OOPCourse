using Itmo.ObjectOrientedProgramming.Lab2.Lab;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes.SubjectBuilders;

public abstract class SubjectBuilderBase : ISubjectBuilder
{
    private readonly List<ILabwork> _labworks = [];
    private readonly List<ILectureMaterials> _materials = [];
    private string? _name;
    private Point? _points;
    private long? _id;
    private IUser? _author;

    protected SubjectBuilderBase(IUser? author = null)
    {
        _author = author;
    }

    public ISubjectBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public ISubjectBuilder WithAuthor(IUser user)
    {
        _author = user;
        return this;
    }

    public ISubjectBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISubjectBuilder AddLabwork(ILabwork labwork)
    {
        _labworks.Add(labwork);
        return this;
    }

    public ISubjectBuilder AddLectureMaterial(ILectureMaterials lectureMaterials)
    {
        _materials.Add(lectureMaterials);
        return this;
    }

    public ISubjectBuilder WithPoints(Point points)
    {
        _points = points;
        return this;
    }

    public CreateSubjectResult Build()
    {
        return Build(
            _id ?? throw new ArgumentNullException(),
            _name ?? throw new ArgumentNullException(),
            _labworks,
            _materials,
            _points ?? throw new ArgumentNullException(),
            _author ?? throw new ArgumentNullException());
    }

    protected abstract CreateSubjectResult Build(
        long id,
        string name,
        IReadOnlyCollection<ILabwork> labworks,
        IReadOnlyCollection<ILectureMaterials> materials,
        Point points,
        IUser author);
}