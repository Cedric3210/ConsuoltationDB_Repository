namespace FlutterAPI.ViewModel
{
    public class RequestViewModel
    {
        public string SchoolYear { get; set; }
        public List<CourseInfo> Courses { get; set; }

    }
        public class CourseInfo
        {
            public string Code { get; set; }
            public string Course { get; set; }
            public string Instructor { get; set; }
        }
    }
