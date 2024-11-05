namespace ApiUniversity.Models;

public class DetailedEnrollmentDTO
{
    public int Id { get; set; }
    public Grade Grade { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;

    public DetailedEnrollmentDTO(Enrollment enrollment) {
        Id = enrollment.Id;
        Grade = enrollment.Grade;
        Student = enrollment.Student;
        Course = enrollment.Course;
    }
}