using Itmo.ObjectOrientedProgramming.Lab2.Persons;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lections.LectureBuilder;

public class LectureMaterialsBuilder
{
    private string? _name;
    private string? _description;
    private string? _content;
    private IUser? _author;
    private long? _id;

    public LectureMaterialsBuilder(IUser? author = null)
    {
        _author = author;
    }

    public LectureMaterialsBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public LectureMaterialsBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public LectureMaterialsBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public LectureMaterialsBuilder WithContent(string content)
    {
        _content = content;
        return this;
    }

    public LectureMaterialsBuilder WithAuthor(IUser author)
    {
        _author = author;
        return this;
    }

    public ILectureMaterials Build()
    {
        return new LectureMaterials(
            _id ?? throw new ArgumentNullException(),
            _name ?? throw new ArgumentNullException(),
            _description ?? throw new ArgumentNullException(),
            _content ?? throw new ArgumentNullException(),
            _author ?? throw new ArgumentNullException());
    }
}