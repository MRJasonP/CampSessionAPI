// Models/CampSession.cs
namespace CampSessionAPI.Models
{
    public class CampSession
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TotalSpots { get; set; }
        public int AvailableSpots { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string Fee { get; set; } = string.Empty;
    }

    public class RegistrationRequest
    {
        public string StudentName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string SessionName { get; set; } = string.Empty;
    }

    public class RegistrationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string SessionName { get; set; } = string.Empty;
        public string ConfirmationCode { get; set; } = string.Empty;
    }
}
