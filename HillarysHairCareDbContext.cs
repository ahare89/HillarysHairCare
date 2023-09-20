using Microsoft.EntityFrameworkCore;
using HillarysHairCare.Models;

public class HillarysHairCareDbContext: DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentsServices { get; set; }
    
    public HillarysHairCareDbContext(DbContextOptions<HillarysHairCareDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new Customer[]
        {
            new Customer {Id = 1, Name = "Barry O'Bannon" },
            new Customer {Id = 2, Name = "Michael O'Keefe" },
            new Customer {Id = 3, Name = "Billy Smalls" },
            new Customer {Id = 4, Name = "Mary O'Reilly" },
            new Customer {Id = 5, Name = "Micah Swanson" }
        });

        modelBuilder.Entity<Stylist>().HasData(new Stylist[]
        {
           new Stylist {Id = 1, Name = "Yvonne Peterson", isEmployed = true},
           new Stylist {Id = 2, Name = "MichaelAnne Yarbrough", isEmployed = true},
           new Stylist {Id = 3, Name = "Kimmy Sanderson", isEmployed = true},
           new Stylist {Id = 4, Name = "Adrian Wizniowski", isEmployed = true},
           new Stylist {Id = 5, Name = "Pippa Vanderschnout", isEmployed = true}

        });

        modelBuilder.Entity<Appointment>().HasData(new Appointment[]
        {
            new Appointment {Id = 1, CustomerId = 1, StylistId = 3, Date = new DateTime(2023, 09, 15, 14, 30, 0)}
        });

        modelBuilder.Entity<Service>().HasData(new Service[]
        {
            new Service {Id = 1, Name = "Women's Haircut", Price = 30M},
            new Service {Id = 2, Name = "Shampoo", Price = 20M},
            new Service {Id = 3, Name = "Men's Haircut", Price = 15M},
            new Service {Id = 4, Name = "Beard Trim", Price = 5M},
            new Service {Id = 5, Name = "Razor Shave", Price = 10M},
            new Service {Id = 6, Name = "Hot Towel", Price = 2M},
            new Service {Id = 7, Name = "Massage", Price = 100M},
            new Service {Id = 8, Name = "Pedicure", Price = 35M},
            new Service {Id = 9, Name = "Manicure", Price = 25M},
            new Service {Id = 10, Name = "Perm", Price = 80M},
            new Service {Id = 11, Name = "Color", Price = 70M},

        });

        modelBuilder.Entity<AppointmentService>().HasData(new AppointmentService[]
        {
            new AppointmentService {Id = 1, AppointmentId = 1, ServiceId = 1 }
        });
    }








}