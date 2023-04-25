using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Models;

namespace StudentDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolmentController : ControllerBase
    {
        private readonly APIDbContext _context;

        public EnrolmentController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Enrolment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrolment>>> GetEnrolments()
        {
          if (_context.Enrolments == null)
          {
              return NotFound();
          }
            return await _context.Enrolments.ToListAsync();
        }

        // GET: api/Enrolment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrolment>> GetEnrolment(int id)
        {
          if (_context.Enrolments == null)
          {
              return NotFound();
          }
            var enrolment = await _context.Enrolments.FindAsync(id);

            if (enrolment == null)
            {
                return NotFound();
            }

            return enrolment;
        }

        // PUT: api/Enrolment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnrolment(int id, Enrolment enrolment)
        {
            if (id != enrolment.EnrolmetId)
            {
                return BadRequest();
            }

            _context.Entry(enrolment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrolmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Enrolment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enrolment>> PostEnrolment(Enrolment enrolment)
        {
            if (_context.Enrolments == null)
            {
                return Problem("Entity set 'APIDbContext.Enrolments'  is null.");
            }

            var student = await _context.Students.FindAsync(enrolment.StudentId);
            if (student == null)
            {
                return NotFound($"Student with ID {enrolment.StudentId} not found.");
            }

            var subject = await _context.Subjects.FindAsync(enrolment.SubjectId);
            if (subject == null)
            {
                return NotFound($"Subject with ID {enrolment.SubjectId} not found.");
            }

            _context.Enrolments.Add(enrolment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnrolment", new { id = enrolment.EnrolmetId }, enrolment);
        }

        // DELETE: api/Enrolment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrolment(int id)
        {
            if (_context.Enrolments == null)
            {
                return NotFound();
            }
            var enrolment = await _context.Enrolments.FindAsync(id);
            if (enrolment == null)
            {
                return NotFound();
            }

            _context.Enrolments.Remove(enrolment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnrolmentExists(int id)
        {
            return (_context.Enrolments?.Any(e => e.EnrolmetId == id)).GetValueOrDefault();
        }






        // get all the subjects a student has enrolled for
        // GET: api/Enrolment/student/5/subjects
        [HttpGet("students/{studentId}/subjects")]
        public ActionResult<IEnumerable<Subject>> GetEnrolledSubjects(int studentId)
        {
            var enrolments = _context.Enrolments.Where(e => e.StudentId == studentId);
            var subjects = new List<Subject>();

            foreach (var enrolment in enrolments)
            {
                var subject = _context.Subjects.FirstOrDefault(s => s.SubjectId == enrolment.SubjectId);
                if (subject != null)
                {
                    subjects.Add(subject);
                }
            }

            return Ok(subjects);
        }

        // get all the students who are enrolled for a particular subject
        // GET: api/Enrolment/subjects/5/students
        // using a single query re write this

        [HttpGet("subjects/{subjectId}/students")]
        public ActionResult<IEnumerable<Student>> GetEnrolledStudents(int subjectId)
        {
            var students = _context.Enrolments
                .Where(e => e.SubjectId == subjectId)
                .Select(e => e.Students)
                .ToList();

            return Ok(students);
        }

        // DELETE: api/Enrolment/enrolledStudent/5
        [HttpDelete("enrolledStudent/{id}")]
        public IActionResult DeleteEnrolmentsForStudent(int id)
        {
            var enrolments = _context.Enrolments.Where(e => e.StudentId == id);
            _context.Enrolments.RemoveRange(enrolments);
            _context.SaveChanges();

            return Ok();
        }
    }
}
