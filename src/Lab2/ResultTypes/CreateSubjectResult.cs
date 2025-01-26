using Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record CreateSubjectResult
{
    private CreateSubjectResult() { }

    public sealed record Success(ISubject Subject) : CreateSubjectResult;

    public sealed record Failed : CreateSubjectResult;
}