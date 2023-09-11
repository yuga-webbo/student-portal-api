
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<College_Student.DataBase.CourseDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnectionstring")));

builder.Services.AddCors((corsoptions) =>
{
  corsoptions.AddPolicy("MyPolicy", (policyoptions) =>
  {
    policyoptions.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
