using Consultation.Infrastructure.Data;
using Enum;
using FlutterAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlutterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RequestController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult RequestPart(int studentId)
        {

            var student = _context.Students
                .Include(s => s.SchoolYears)
                .Include(s => s.EnrolledCourses)
                .ThenInclude(c => c.Course)
                .Include(s => s.EnrolledCourses)
                .ThenInclude(c => c.Faculty)
                .FirstOrDefault(s => s.StudentID == studentId);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var currentSchoolYear = student.SchoolYears
                .FirstOrDefault(sy => sy.SchoolYearStatus == SchoolYearStatus.Current);

            if (currentSchoolYear == null)
            {
                return NotFound("Current school year not found.");
            }

            // Convert tung sem nga enum into string
            string semesterString = currentSchoolYear.Semester switch
            {
                Semester.Semester1 => "First Semester",
                Semester.Semester2 => "Second Semester",
                Semester.Summer => "Summer",
                _ => "Unknown Semester"
            };

            string schoolYearString = $"{semesterString} {currentSchoolYear.Year1}-{currentSchoolYear.Year2}";

            var courses = student.EnrolledCourses.Select(ec => new CourseInfo
            {
                Code = ec.CourseCode,
                Course = ec.Course.CourseName,
                Instructor = ec.Faculty.FacultyName
            }).ToList();

            var result = new RequestViewModel
            {
                SchoolYear = schoolYearString,
                Courses = courses
            };

            return Ok(result);

        }
    }
}
