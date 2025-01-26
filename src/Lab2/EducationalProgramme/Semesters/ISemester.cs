using Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramme.Semesters;

public interface ISemester
{
    int Id { get; }

    IReadOnlyCollection<ISubject> Subjects { get; }
}