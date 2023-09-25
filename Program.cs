using HillarysHairCare.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillarysHairCareDbContext>(builder.Configuration["HillarysHairCareDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/customers", (HillarysHairCareDbContext db) => {
    return db.Customers;
});

app.MapGet("/api/appointments", (HillarysHairCareDbContext db) => {
    return db.Appointments
    .Include(a => a.Customer)
    .Include(a => a.Stylist)
    .Include(a => a.Services);
});

app.MapGet("/api/stylists", (HillarysHairCareDbContext db) => {
    return db.Stylists;
});

app.MapGet("/api/services", (HillarysHairCareDbContext db) => {
    return db.Services;
});

app.MapPost("/api/customers", (HillarysHairCareDbContext db, Customer newCustomer) => {
    try {
        db.Customers.Add(newCustomer);
        db.SaveChanges();
        return Results.Created($"/api/customers/{newCustomer.Id}", newCustomer);
    } 
    catch (DbUpdateException) {
        return Results.BadRequest("Invalid Data Submitted");
    }
});

app.MapPost("/api/stylists", (HillarysHairCareDbContext db, Stylist newStylist) => {

try {
    newStylist.isEmployed = true;
    db.Stylists.Add(newStylist);
    db.SaveChanges();
    return Results.Created($"/api/stylists/{newStylist.Id}", newStylist);
}
catch (DbUpdateException) {
    return Results.BadRequest("Invalid Data Submitted");
}
});

app.MapDelete("api/stylists/{id}", (HillarysHairCareDbContext db, int id) => {
    Stylist stylistToDeactivate = db.Stylists.SingleOrDefault(s => s.Id == id);

    stylistToDeactivate.isEmployed = false;
    db.SaveChanges();
    return Results.Ok(stylistToDeactivate);
});

app.MapDelete("/api/customers/{id}", (HillarysHairCareDbContext db, int id) => {
    Customer customerToDelete = db.Customers.SingleOrDefault(c => c.Id == id);
    db.Customers.Remove(customerToDelete);
    db.SaveChanges();
    return Results.Ok(customerToDelete);
});

app.MapPost("/api/appointments", (HillarysHairCareDbContext db, Appointment newAppointment) => {

List<int> serviceIds = newAppointment.Services.Select(s => s.Id).ToList();
List<Service> foundServices = db.Services.Where(s => serviceIds.Contains(s.Id)).ToList();
Customer matchedCustomer = db.Customers.SingleOrDefault(c => c.Id == newAppointment.CustomerId);
Stylist matchedStylist = db.Stylists.SingleOrDefault(s => s.Id == newAppointment.StylistId);
newAppointment.Services = foundServices;
newAppointment.Customer = matchedCustomer;
newAppointment.Stylist = matchedStylist;
db.Appointments.Add(newAppointment);
db.SaveChanges();
return Results.Created($"/api/appointments/{newAppointment.Id}", newAppointment);

});

app.UseAuthorization();

app.MapControllers();

app.Run();
