namespace ApiUniversity.Models;

// Data Transfer Object class, used to bypass navigation properties validation during API calls
public class StudentDTO
{
    public int Id { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new();

    public StudentDTO() { }

    public StudentDTO(Student student){
        Id = student.Id;
        LastName = student.LastName;
        FirstName = student.FirstName;
        EnrollmentDate = student.EnrollmentDate;
        Enrollments = student.Enrollments;
    }
}