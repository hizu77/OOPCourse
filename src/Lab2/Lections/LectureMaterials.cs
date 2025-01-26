using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Generator;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lections;

public class LectureMaterials : ILectureMaterials, IPrototype<LectureMaterials>
{
    public LectureMaterials(
        long id,
        string name,
        string description,
        string content,
        IUser author,
        long? baseId = null)
    {
        Id = id;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
        BaseId = baseId;
    }

    public IUser Author { get; }

    public string Name { get; private set; }

    public long Id { get; }

    public long? BaseId { get; } = null;

    public string Description { get; private set; }

    public string Content { get; private set; }

    public EditResult EditName(IUser user, string name)
    {
        if (Author.Id != user.Id)
        {
            return new EditResult.Failed();
        }

        Name = name;

        return new EditResult.Success();
    }

    public EditResult EditDescription(IUser user, string description)
    {
        if (Author.Id != user.Id)
        {
            return new EditResult.Failed();
        }

        Description = description;

        return new EditResult.Success();
    }

    public EditResult EditContent(IUser user, string content)
    {
        if (Author.Id != user.Id)
        {
            return new EditResult.Failed();
        }

        Content = content;

        return new EditResult.Success();
    }

    public LectureMaterials Clone()
    {
        long randomId = GeneratorId.Generate();

        return new LectureMaterials(
            randomId,
            Name,
            Description,
            Content,
            Author.Clone(),
            Id);
    }

    ILectureMaterials ILectureMaterials.Clone()
    {
        return Clone();
    }
}