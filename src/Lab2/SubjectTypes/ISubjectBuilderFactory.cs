using Itmo.ObjectOrientedProgramming.Lab2.Persons;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes;

public interface ISubjectBuilderFactory
{
    ISubjectBuilder Create(IUser? author = null);
}