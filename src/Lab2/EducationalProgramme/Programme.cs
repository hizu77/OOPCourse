using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramme.Semesters;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramme;

public class Programme : IProgramme
{
    public Programme(
        long id,
        string name,
        IReadOnlyCollection<ISemester> subjects,
        IUser manager)
    {
        Id = id;
        Name = name;
        Subjects = subjects;
        Author = manager;
    }

    public string Name { get; }

    public IReadOnlyCollection<ISemester> Subjects { get; }

    public IUser Author { get; }

    public long Id { get; }
}