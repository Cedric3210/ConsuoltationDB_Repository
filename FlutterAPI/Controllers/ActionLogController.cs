using Consultation.Domain;
using Consultation.Domain.Enum;
using Consultation.Infrastructure.Data;
using FlutterAPI.ViewModel;

namespace FlutterAPI.Controllers
{
    public class ActionLogController
    {

        private readonly AppDbContext _context;
        public  ActionLogController(AppDbContext context)
        {
            _context = context;

        }

        //ActionLog for Log-in
        public ActionLog ActionLogAunthentication(string message, string AccountName,
            UserType UserType, Users user, string id)
        {
            var users = _context.Users.FirstOrDefault(c => c.Id == id);
            ActionLog viewModel = new ActionLog()
            {
                ActionLogID = 0,
                Date = DateTime.Now,
                Description = message,
                Time = TimeOnly.FromDateTime(DateTime.Now),
                Users = users

            };
            return viewModel;
        }


        public ActionLog ActionLogInput(string message, string AccountName,
        UserType UserType, Users user, string id)
        {
            var users = _context.Users.FirstOrDefault(c => c.Id == id);
            ActionLog viewModel = new ActionLog()
            {
                ActionLogID = 0,
                Date = DateTime.Now,
                Description = message,
                Time = TimeOnly.FromDateTime(DateTime.Now),
                Users = users

            };
            return viewModel;
        }
    }
}
