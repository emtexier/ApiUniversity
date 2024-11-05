namespace ApiUniversity.Models;

public class Enrollment
{
    public int Id { get; set; }
    public Grade Grade { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;

    public Enrollment() { }

    public Enrollment(DetailedEnrollmentDTO enrollmentDTO)
    {
        Id = enrollmentDTO.Id;
        Grade = enrollmentDTO.Grade;
        StudentId = enrollmentDTO.Id;
        CourseId = enrollmentDTO.Id;
        Student = enrollmentDTO.Student;
        Course = enrollmentDTO.Course;
    }
}