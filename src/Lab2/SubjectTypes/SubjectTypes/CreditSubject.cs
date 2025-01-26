using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Generator;
using Itmo.ObjectOrientedProgramming.Lab2.Lab;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes.SubjectBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes.SubjectTypes;

public class CreditSubject : ISubject, IPrototype<CreditSubject>
{
    public static CreditSubjectBuilder Builder(IUser? author = null) => new CreditSubjectBuilder(author);

    private CreditSubject(
        long id,
        string name,
        IReadOnlyCollection<ILabwork> labworks,
        IReadOnlyCollection<ILectureMaterials> materials,
        Point points,
        IUser author,
        long? baseId = null)
    {
        Id = id;
        Name = name;
        Labworks = labworks;
        Materials = materials;
        Points = points;
        Author = author;
        BaseId = baseId;
    }

    public IUser Author { get; }

    public string Name { get; private set; }

    public long Id { get; }

    public long? BaseId { get; }

    public IReadOnlyCollection<ILabwork> Labworks { get; }

    public IReadOnlyCollection<ILectureMaterials> Materials { get; private set; }

    public Point Points { get; }

    public class CreditSubjectBuilder : SubjectBuilderBase
    {
        public CreditSubjectBuilder(IUser? author = null) : base(author) { }

        protected override CreateSubjectResult Build(
            long id,
            string name,
            IReadOnlyCollection<ILabwork> labworks,
            IReadOnlyCollection<ILectureMaterials> materials,
            Point points,
            IUser author)
        {
            double totalPoints = labworks.Sum(l => l.Points.Value);

            return totalPoints != Point.KMaxPoint.Value
                ? new CreateSubjectResult.Failed()
                : new CreateSubjectResult.Success(new CreditSubject(
                id,
                name,
                labworks,
                materials,
                points,
                author));
        }
    }

    public CreditSubject Clone()
    {
        var copyLabworks = Labworks.Select(l => l.Clone()).ToList();
        var copyMaterials = Materials.Select(m => m.Clone()).ToList();
        long randomId = GeneratorId.Generate();

        return new CreditSubject(
            randomId,
            Name,
            copyLabworks,
            copyMaterials,
            Points,
            Author.Clone(),
            Id);
    }

    ISubject ISubject.Clone()
    {
        return Clone();
    }

    public EditResult EditName(IUser user, string newName)
    {
        if (Author.Id != user.Id)
        {
            return new EditResult.Failed();
        }

        Name = newName;

        return new EditResult.Success();
    }

    public EditResult EditMaterials(IUser user, IReadOnlyCollection<ILectureMaterials> materials)
    {
        if (Author.Id != user.Id)
        {
            return new EditResult.Failed();
        }

        Materials = materials;

        return new EditResult.Success();
    }
}