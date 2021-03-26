using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntranceMonitoring.Models;

namespace EntranceMonitoring.Data
{
    public class DataInitializer
    {
        public static void Initialize(MonitoringContext context)
        {
            context.Database.EnsureCreated();
            //look for Users in the system
            if (context.Users.Any())
            {
                return; //there are already users in the system
            }

            var users = new User[]
            {
                new User{Name="Wojtek", LastName="Testowy", Email="testowymail@gmail.com" },
                new User{Name="Piotrek", LastName="Tescikowy", Email="testowymail2@gmail.com" },
                new User{Name="Krzys", LastName="test", Email="testowymail3@gmail.com" },
                new User{Name="Adam", LastName="kowalski", Email="testowymail4@gmail.com" }
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var buildings = new Building[]
            {
                new Building{Name="Glowne Biuro", Address="Mickiewicza 1 Poznan"},
                new Building{Name="Magazyn", Address="Sobieskiego 14 Poznan"},
                new Building{Name="Szopa", Address="Konstytucji 3 maja, szczecin"},
                new Building{Name="Biuro 2", Address="Mickiewicza 5 Poznan"}
            };
            foreach (Building b in buildings)
            {
                context.Buildings.Add(b);
            }
            context.SaveChanges();

            var registries = new Registry[]
            {
                new Registry{UserId=1, BuildingId=1, InOut="in", Registedtime=DateTime.Parse("2010-05-12")},
                new Registry{UserId=1, BuildingId=1, InOut="out", Registedtime=DateTime.Parse("2010-05-13")}
            };
            foreach (Registry r in registries)
            {
                context.Registries.Add(r);
            }
            context.SaveChanges();
        }
    }
}
