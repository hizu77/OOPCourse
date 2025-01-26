using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramme.Semesters;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramme.Builder;

public class ProgrammeBuilder
{
    private readonly IReadOnlyCollection<ISemester> _subjects = [];
    private string? _name;
    private long? _id;
    private IUser? _manager;

    public ProgrammeBuilder(IUser? manager = null)
    {
        _manager = manager;
    }

    public ProgrammeBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public ProgrammeBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ProgrammeBuilder AddSubject(ISubject subject, int semesterId)
    {
        ISemester currentSemester = _subjects.FirstOrDefault(s => s.Id == semesterId)
                                     ?? new Semester(semesterId, []);

        currentSemester.Subjects.Append(subject);

        return this;
    }

    public ProgrammeBuilder WithManager(IUser user)
    {
        _manager = user;
        return this;
    }

    public IProgramme Build()
    {
        return new Programme(
            _id ?? throw new ArgumentNullException(),
            _name ?? throw new ArgumentNullException(),
            _subjects,
            _manager ?? throw new ArgumentNullException());
    }
}