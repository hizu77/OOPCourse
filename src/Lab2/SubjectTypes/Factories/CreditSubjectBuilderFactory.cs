using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes.SubjectTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes.Factories;

public class CreditSubjectBuilderFactory : ISubjectBuilderFactory
{
    public ISubjectBuilder Create(IUser? author = null)
    {
        return CreditSubject.Builder(author);
    }
}