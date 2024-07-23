using NewSportsAcademy.Models;

namespace NewSportsAcademy.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="John",LastName="Doe",DOB=DateTime.Parse("2000-01-01"),Gender="Male",Address="123 Main St",ContactNumber="1234567890",MedicalInformation="None",Email="john.doe@example.com"},
                new Student{FirstName="Jane",LastName="Smith",DOB=DateTime.Parse("2001-02-01"),Gender="Female",Address="456 Maple Ave",ContactNumber="0987654321",MedicalInformation="Asthma",Email="jane.smith@example.com"}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var sports = new Sport[]
            {
                new Sport{SportName="Soccer"},
                new Sport{SportName="Basketball"}
            };

            context.Sports.AddRange(sports);
            context.SaveChanges();

            var fixtures = new Fixture[]
            {
                new Fixture{SportID=1,StudentID=1,Date=DateTime.Parse("2023-08-15"),Time=DateTime.Parse("10:00:00"),Location="Stadium A"},
                new Fixture{SportID=2,StudentID=2,Date=DateTime.Parse("2023-08-16"),Time=DateTime.Parse("14:00:00"),Location="Arena B"}
            };

            context.Fixtures.AddRange(fixtures);
            context.SaveChanges();
        }
    }
}
