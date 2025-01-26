using Itmo.ObjectOrientedProgramming.Lab2.CommonInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramme.Semesters;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramme;

public interface IProgramme : IIdentifiable
{
    public IReadOnlyCollection<ISemester> Subjects { get; }
}