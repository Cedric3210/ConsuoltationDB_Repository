using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Infrastructure.Data;
using FlutterAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlutterAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
<<<<<<< HEAD:FlutterAPI/Controllers/FacultyController.cs
    public class FacultyController : ControllerBase
=======
    public class FacultyDashBoard : ControllerBase
>>>>>>> Added and change name, ready nani data nalang kulang:FlutterAPI/Controllers/FacultyDashBoard.cs
    {

        private readonly AppDbContext _context;

<<<<<<< HEAD:FlutterAPI/Controllers/FacultyController.cs
        public FacultyController(AppDbContext context)
=======
        public FacultyDashBoard(AppDbContext context)
>>>>>>> Added and change name, ready nani data nalang kulang:FlutterAPI/Controllers/FacultyDashBoard.cs
        {
            _context = context;
        }


        //Faculty Dashboard
        [HttpGet]
        public async Task<IActionResult> GetAllConsultationRequests()
        {
            //Query to get all consultation requests
            var requests = await _context.ConsultationRequest
                .Include(c => c.Student)
                    .ThenInclude(s => s.EnrolledCourses)
                .ToListAsync();

            //Check if there are no requests
            if (requests == null || !requests.Any())
            {
                return NotFound(new { Message = "No consultation requests found." });
            }

            //Map the requests to the view model
            var responses = requests.Select(request =>
            {
                var enrolledCourse = request.Student.EnrolledCourses.FirstOrDefault();

                return new ConsultationRequestViewModel
                {
                    ConsultationID = request.ConsultationID,
                    CourseCode = enrolledCourse?.CourseCode ?? "N/A",
                    StudentName = request.Student.StudentName,
                    DateSchedule = request.DateSchedule,
                    TimeStart = request.StartedTime,
                    TimeEnd = request.EndedTime,
                    Status = request.Status
                };
            }).ToList();

<<<<<<< HEAD:FlutterAPI/Controllers/FacultyController.cs

=======
>>>>>>> Added and change name, ready nani data nalang kulang:FlutterAPI/Controllers/FacultyDashBoard.cs
            return Ok(responses);
        }

        [HttpPut("api/consultation-requests/{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusModel usm)
        {
            var request = await _context.ConsultationRequest.FindAsync(id);
            if (request == null)
                return NotFound("Consultation request not found.");

            if (request.Status != Status.Pending)
                return BadRequest("Only pending requests can be updated.");

            if (usm.Status != Status.Approved && usm.Status != Status.Disapproved)
                return BadRequest("Invalid status. Use 'Approved' or 'Disapproved'.");

            request.Status = usm.Status;
            await _context.SaveChangesAsync();

            return Ok(request);
        }
    }
}
