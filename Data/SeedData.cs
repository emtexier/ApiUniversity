using ApiUniversity.Models;

namespace ApiUniversity.Data;

public static class SeedData
{
    // Test data for part 1 and 2
    public static void Init()
    {
        using var context = new ApiUniversityContext();
        // Look for existing content
        if (context.Students.Any())
        {
            return;   // DB already filled
        }

        // Add students
        Student carson = new()
        {
            FirstName = "Alexander",
            LastName = "Carson",
            EnrollmentDate = DateTime.Parse("2016-09-01"),
        };
        Student alonso = new()
        {
            FirstName = "Meredith",
            LastName = "Alonso",
            EnrollmentDate = DateTime.Parse("2018-09-01"),
        };
        Student anand = new()
        {
            FirstName = "Arturo",
            LastName = "Anand",
            EnrollmentDate = DateTime.Parse("2019-09-01"),
        };
        Student barzdukas = new()
        {
            FirstName = "Gytis",
            LastName = "Barzdukas",
            EnrollmentDate = DateTime.Parse("2018-09-01"),
        };
        context.Students.AddRange(
            carson,
            alonso,
            anand,
            barzdukas
        );

        // Add courses
        Course chemistry = new()
        {
            Id = 1,
            Title = "Chemistry",
            Credits = 3,
        };
        Course microeconomics = new()
        {
            Id = 2,
            Title = "Microeconomics",
            Credits = 3,
        };
        Course macroeconmics = new()
        {
            Id = 3,
            Title = "Macroeconomics",
            Credits = 3,
        };
        Course calculus = new()
        {
            Id = 4,
            Title = "Calculus",
            Credits = 4,
        };
        context.Courses.AddRange(
            chemistry,
            microeconomics,
            macroeconmics,
            calculus
        );

        // Add enrollments
        context.Enrollments.AddRange(
            new Enrollment
            {
                Student = carson,
                Course = chemistry,
                Grade = Grade.A
            },
            new Enrollment
            {
                Student = carson,
                Course = microeconomics,
                Grade = Grade.C
            },
            new Enrollment
            {
                Student = alonso,
                Course = calculus,
                Grade = Grade.B
            },
            new Enrollment
            {
                Student = anand,
                Course = chemistry,
            },
            new Enrollment
            {
                Student = anand,
                Course = microeconomics,
                Grade = Grade.B
            },
            new Enrollment
            {
                Student = barzdukas,
                Course = chemistry,
                Grade = Grade.C
            }
        );

        // Commit changes into DB
        context.SaveChanges();
    }
}