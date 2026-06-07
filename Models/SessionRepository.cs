// Models/SessionRepository.cs
namespace CampSessionAPI.Models
{
    public static class SessionRepository
    {
        public static List<CampSession> Sessions { get; } = new()
        {
            new CampSession {
                Name="Robotics",
                Description="Build and program robots using LEGO and Arduino.",
                TotalSpots=20, AvailableSpots=20,
                StartDate="July 7, 2025", Fee="$350"
            },
            new CampSession {
                Name="Coding",
                Description="Learn web development with HTML, CSS, JavaScript.",
                TotalSpots=25, AvailableSpots=25,
                StartDate="July 14, 2025", Fee="$320"
            },
            new CampSession {
                Name="Art",
                Description="Digital art, 3D modelling, and creative design.",
                TotalSpots=15, AvailableSpots=15,
                StartDate="July 21, 2025", Fee="$300"
            },
            new CampSession {
                Name="Science",
                Description="Hands-on chemistry, physics, and biology experiments.",
                TotalSpots=20, AvailableSpots=20,
                StartDate="July 28, 2025", Fee="$330"
            },
        };
    }
}
