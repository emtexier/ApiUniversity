using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiUniversity.Models;

namespace ApiUniversity.Controllers;

[ApiController]
[Route("api/enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly ApiUniversityContext _context;

    public EnrollmentController(ApiUniversityContext context)
    {
        _context = context;
    }

    // GET: api/student/2
    /*[HttpGet("{id}")]
    public async Task<ActionResult<DetailedEnrollmentDTO>> GetEnrollment(int id)
    {
        var enrollment = await _context.Enrollments.SingleOrDefaultAsync(t => t.Id == id);

        if (enrollment == null)
        {
            return NotFound();
        }

        return new DetailedEnrollmentDTO(enrollment);
    }*/

    // POST: api/student
    [HttpPost]
    public async Task<ActionResult<DetailedEnrollmentDTO>> PostEnrollment(DetailedEnrollmentDTO enrollmentDTO)
    {
        Enrollment enrollment = new(enrollmentDTO);

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, new DetailedEnrollmentDTO(enrollment));
    }

    // PUT: api/student/2
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEnrollment(int id, DetailedEnrollmentDTO enrollmentDTO)
    {
        if (id != enrollmentDTO.Id)
        {
            return BadRequest();
        }

        Enrollment enrollment = new(enrollmentDTO);

        _context.Entry(enrollment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Enrollments.Any(m => m.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/student/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);

        if (enrollment == null)
        {
            return NotFound();
        }

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    // GET: api/enrollment/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<DetailedEnrollmentDTO>> GetEnrollment(int id)
    {
        // Charger l’inscription avec les données de l’étudiant et du cours associés
        var enrollment = await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .SingleOrDefaultAsync(e => e.Id == id);

        if (enrollment == null)
        {
            return NotFound();
        }

        return new DetailedEnrollmentDTO(enrollment);
    }

    [HttpPost]
    public async Task<ActionResult<DetailedEnrollmentDTO>> CreateEnrollment(EnrollmentDTO enrollmentDto)
    {
        // Vérifier que l'étudiant et le cours existent dans la base de données
        var student = await _context.Students.FindAsync(enrollmentDto.StudentId);
        var course = await _context.Courses.FindAsync(enrollmentDto.CourseId);

        if (student == null || course == null)
        {
            return BadRequest("Invalid StudentId or CourseId.");
        }

        // Créer une nouvelle instance d'Enrollment à partir de l'objet DTO
        var enrollment = new Enrollment
        {
            StudentId = enrollmentDto.StudentId,
            CourseId = enrollmentDto.CourseId,
            Grade = enrollmentDto.Grade
        };

        // Ajouter l'inscription à la base de données et sauvegarder
        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        // Charger l'inscription avec les détails nécessaires pour DetailedEnrollmentDTO
        await _context.Entry(enrollment).Reference(e => e.Student).LoadAsync();
        await _context.Entry(enrollment).Reference(e => e.Course).LoadAsync();

        // Retourner l'objet DetailedEnrollmentDTO
        var detailedEnrollmentDto = new DetailedEnrollmentDTO(enrollment);
        return CreatedAtAction(nameof(CreateEnrollment), new { id = detailedEnrollmentDto.Id }, detailedEnrollmentDto);
    }
}