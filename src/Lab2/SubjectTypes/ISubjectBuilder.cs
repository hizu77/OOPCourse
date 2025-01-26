using Itmo.ObjectOrientedProgramming.Lab2.Lab;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes;

public interface ISubjectBuilder
{
    ISubjectBuilder WithId(long id);

    ISubjectBuilder WithAuthor(IUser user);

    ISubjectBuilder WithName(string name);

    ISubjectBuilder AddLabwork(ILabwork labwork);

    ISubjectBuilder AddLectureMaterial(ILectureMaterials lectureMaterials);

    ISubjectBuilder WithPoints(Point points);

    CreateSubjectResult Build();
}