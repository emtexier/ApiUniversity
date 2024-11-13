namespace ApiUniversity.Models;

public class EnrollmentDTO
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public Grade Grade { get; set; }

    public EnrollmentDTO() { }
}

