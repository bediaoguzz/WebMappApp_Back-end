using Microsoft.EntityFrameworkCore;
using WebMappApplication.Interfaces;
using WebMappApplication.Model;
using WebMappApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepository<Door>, GenericRepository<Door>>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//builder.Services.AddTransient<IDoor, EntityService>();
builder.Services.AddDbContext<EFDataContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_DB")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
