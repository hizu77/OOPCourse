using Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramme.Semesters;

public record Semester : ISemester
{
    public Semester(int id, IReadOnlyCollection<ISubject> subjects)
    {
        Id = id;
        Subjects = subjects;
    }

    public IReadOnlyCollection<ISubject> Subjects { get; }

    public int Id { get; }
}