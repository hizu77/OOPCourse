using Itmo.ObjectOrientedProgramming.Lab2.Lab;
using Itmo.ObjectOrientedProgramming.Lab2.Lab.LabBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Lections;
using Itmo.ObjectOrientedProgramming.Lab2.Lections.LectureBuilder;
using Itmo.ObjectOrientedProgramming.Lab2.Persons;
using Itmo.ObjectOrientedProgramming.Lab2.RepositoryModel;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectTypes.Factories;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Xunit;

namespace Lab2.Tests;

public class UnitTests
{
    [Fact]
    public void TryClone_ShouldReturnBaseIdEqual_WhenCloningLabwork()
    {
        // Arrange
        ILabwork lab = new LabworkBuilder()
            .WithId(12)
            .WithAuthor(new User(1, "John Doe"))
            .WithCriteria("lol")
            .WithDescription("kek")
            .WithPoints(new Point(12))
            .WithName("Man")
            .Build();

        // Act
        ILabwork lab2 = lab.Clone();

        // Assert
        Assert.Equal(12, lab2.BaseId);
    }

    [Fact]
    public void TryEdit_ShouldReturnSuccess_WhenUserIsLabworkAuthor()
    {
        // Arrange
        ILabwork lab = new LabworkBuilder()
            .WithId(12)
            .WithAuthor(new User(1, "John Doe"))
            .WithCriteria("lol")
            .WithDescription("kek")
            .WithPoints(new Point(12))
            .WithName("Man")
            .Build();

        // Act
        EditResult res = lab.EditName(new User(1, "John Doe"), "bomb");

        // Assert
        Assert.IsType<EditResult.Success>(res);
        Assert.Equal("bomb", lab.Name);
    }

    [Fact]
    public void TryEdit_ShouldReturnFailed_WhenUserIsNotLabworkAuthor()
    {
        // Arrange
        ILabwork lab = new LabworkBuilder()
            .WithId(12)
            .WithAuthor(new User(1, "John Doe"))
            .WithCriteria("lol")
            .WithDescription("kek")
            .WithPoints(new Point(12))
            .WithName("Man")
            .Build();

        // Act
        EditResult res = lab.EditEvaluationCriteria(new User(2, "Kent"), "always 0");

        // Assert
        Assert.IsType<EditResult.Failed>(res);
    }

    [Fact]
    public void TryClone_ShouldReturnBaseIdEqual_WhenCloningLectureMaterial()
    {
        // Arrange
        ILectureMaterials lecture = new LectureMaterialsBuilder()
            .WithId(12)
            .WithAuthor(new User(1, "John Doe"))
            .WithDescription("kek")
            .WithName("Man")
            .WithContent("aeeeeee")
            .Build();

        // Act
        ILectureMaterials lec2 = lecture.Clone();

        // Assert
        Assert.Equal(12, lec2.BaseId);
    }

    [Fact]
    public void TryEdit_ShouldReturnFailed_WhenUserIsNotMaterialAuthor()
    {
        // Arrange
        ILectureMaterials lecture = new LectureMaterialsBuilder()
            .WithId(12)
            .WithAuthor(new User(1, "John Doe"))
            .WithDescription("kek")
            .WithName("Man")
            .WithContent("aeeeeee")
            .Build();

        // Act
        EditResult res = lecture.EditName(new User(2, "Bro"), "ahaha");

        // Assert
        Assert.IsType<EditResult.Failed>(res);
    }

    [Fact]
    public void TryEdit_ShouldReturnSuccess_WhenUserIsMaterialAuthor()
    {
        // Arrange
        ILectureMaterials lecture = new LectureMaterialsBuilder()
            .WithId(12)
            .WithAuthor(new User(1, "John Doe"))
            .WithDescription("kek")
            .WithName("Man")
            .WithContent("aeeeeee")
            .Build();

        // Act
        EditResult res = lecture.EditContent(new User(1, "John Doe"), "bruh");

        // Assert
        Assert.IsType<EditResult.Success>(res);
        Assert.Equal("bruh", lecture.Content);
    }

    [Fact]
    public void TryBuildExamSubject_ShouldReturnSuccess_When90LabworkPoints10ExamPoints()
    {
        // Arrange
        ISubjectBuilderFactory factory = new ExamSubjectBuilderFactory();

        // Act
        CreateSubjectResult result = CreateSubjectWith90LabworkPoints(factory, 10);

        // Assert
        Assert.IsType<CreateSubjectResult.Success>(result);
    }

    [Fact]
    public void TryBuildExamSubject_ShouldReturnFailed_When90LabworkPoints20ExamPoints()
    {
        // Arrange
        ISubjectBuilderFactory factory = new ExamSubjectBuilderFactory();

        // Act
        CreateSubjectResult result = CreateSubjectWith90LabworkPoints(factory, 20);

        // Assert
        Assert.IsType<CreateSubjectResult.Failed>(result);
    }

    [Fact]
    public void TryBuildCreditSubject_ShouldReturnSuccess_When100LabworkPoints()
    {
        // Arrange
        ISubjectBuilderFactory factory = new CreditSubjectBuilderFactory();

        // Act
        CreateSubjectResult result = CreateSubjectWith100LabworkPoints(factory, 10);

        // Assert
        Assert.IsType<CreateSubjectResult.Success>(result);
    }

    [Fact]
    public void TryBuildCreditSubject_ShouldReturnFailed_When90LabworkPoints()
    {
        // Arrange
        ISubjectBuilderFactory factory = new CreditSubjectBuilderFactory();

        // Act
        CreateSubjectResult result = CreateSubjectWith90LabworkPoints(factory, 10);

        // Assert
        Assert.IsType<CreateSubjectResult.Failed>(result);
    }

    [Fact]
    public void TryEditSubject_ShouldReturnSuccess_WhenSubjectUserIsAuthor()
    {
        // Arrange
        ISubjectBuilderFactory factory = new ExamSubjectBuilderFactory();
        CreateSubjectResult result = CreateSubjectWith90LabworkPoints(factory, 10);
        ISubject subject = ((CreateSubjectResult.Success)result).Subject;

        // Act
        EditResult subjectEdit = subject.EditName(new User(1, "John Doe"), "math");

        // Assert
        Assert.IsType<EditResult.Success>(subjectEdit);
        Assert.Equal("math", subject.Name);
    }

    [Fact]
    public void TryEditSubject_ShouldReturnFailed_WhenSubjectUserIsNotAuthor()
    {
        // Arrange
        ISubjectBuilderFactory factory = new ExamSubjectBuilderFactory();
        CreateSubjectResult result = CreateSubjectWith90LabworkPoints(factory, 10);
        ISubject subject = ((CreateSubjectResult.Success)result).Subject;

        // Act
        EditResult subjectEdit = subject.EditName(new User(2, "Brat"), "phys");

        // Assert
        Assert.IsType<EditResult.Failed>(subjectEdit);
    }

    [Fact]
    public void TryClone_ShouldReturnBaseIdEqual_WhenCloningSubject()
    {
        // Arrange
        ISubjectBuilderFactory factory = new ExamSubjectBuilderFactory();
        CreateSubjectResult result = CreateSubjectWith90LabworkPoints(factory, 10);
        ISubject subject = ((CreateSubjectResult.Success)result).Subject;

        // Act
        ISubject subject2 = subject.Clone();

        // Assert
        Assert.Equal(subject2.BaseId, subject.Id);
    }

    [Fact]
    public void RepositoryFindTest_ShouldReturnNotNull_WhenFindingExistLabwork()
    {
        // Arrange
        Repository<ILabwork> repo = CreateLabworkRepository();

        // Act
        ILabwork? lab1 = repo.FindById(1);

        // Assert
        Assert.NotNull(lab1);
    }

    [Fact]
    public void RepositoryFindTest_ShouldReturnNull_WhenFindingNotExistLabwork()
    {
        // Arrange
        Repository<ILabwork> repo = CreateLabworkRepository();

        // Act
        ILabwork? lab4 = repo.FindById(4);

        // Assert
        Assert.Null(lab4);
    }

    [Fact]
    public void RepositoryFindTest_ShouldReturnEquals_WhenFindingExistLabwork()
    {
        // Arrange
        Repository<ILabwork> repo = CreateLabworkRepository();

        // Act
        ILabwork? lab1 = repo.FindById(1);

        // Assert
        Assert.NotNull(lab1);
        Assert.Equal(1, lab1.Id);
        Assert.Equal("Man", lab1.Name);
        Assert.Equal(1, lab1.Author.Id);
    }

    private static Repository<ILabwork> CreateLabworkRepository()
    {
        ILabwork labwork1 = new LabworkBuilder()
            .WithId(1)
            .WithAuthor(new User(1, "Bolt"))
            .WithCriteria("lol")
            .WithDescription("kek")
            .WithPoints(new Point(12))
            .WithName("Man")
            .Build();

        ILabwork labwork2 = new LabworkBuilder()
            .WithId(2)
            .WithAuthor(new User(2, "Kent"))
            .WithCriteria("null")
            .WithDescription("ahAHAHA")
            .WithPoints(new Point(20))
            .WithName("Girl")
            .Build();

        ILabwork labwork3 = new LabworkBuilder()
            .WithId(3)
            .WithAuthor(new User(3, "Bro"))
            .WithCriteria("che")
            .WithDescription("bebebebebeb")
            .WithPoints(new Point(30))
            .WithName("Woman")
            .Build();

        var labworkRepository = new Repository<ILabwork>();
        labworkRepository.Add(labwork1);
        labworkRepository.Add(labwork2);
        labworkRepository.Add(labwork3);

        return labworkRepository;
    }

    private static CreateSubjectResult CreateSubjectWith90LabworkPoints(ISubjectBuilderFactory factory, double point)
    {
        var points = new Point(point);

        return factory.Create()
            .WithId(1)
            .WithAuthor(new User(1, "John Doe"))
            .WithName("math")
            .WithPoints(points)
            .AddLabwork(new Labwork(
                1,
                "John Doe",
                "a",
                "v",
                new Point(20),
                new User(2, "Misha")))
            .AddLabwork(new Labwork(
                2,
                "John Doe",
                "a",
                "v",
                new Point(70),
                new User(2, "Lol")))
            .Build();
    }

    private static CreateSubjectResult CreateSubjectWith100LabworkPoints(ISubjectBuilderFactory factory, double point)
    {
        var points = new Point(point);

        return factory.Create()
            .WithId(1)
            .WithAuthor(new User(1, "John Doe"))
            .WithName("math")
            .WithPoints(points)
            .AddLabwork(new Labwork(
                1,
                "John Doe",
                "a",
                "v",
                new Point(100),
                new User(2, "Misha")))
            .Build();
    }
}