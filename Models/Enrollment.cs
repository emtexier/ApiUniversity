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

    public Enrollment(DetailedEnrollmentDTO detailedEnrollmentDTO) {
        Id = detailedEnrollmentDTO.Id;
        Student = new Student(detailedEnrollmentDTO.Student);
        Course = new Course(detailedEnrollmentDTO.Course);
    }
}