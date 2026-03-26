using Microsoft.EntityFrameworkCore;
using AIScheduleUI5.BLL.Infrastructure;
using Microsoft.Extensions.DependencyInjection;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connection))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");
        }

        builder.Services.AddAIScheduleUI5Context(connection);
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddUnitOfWorkService();
        builder.Services.AddBusinessServices();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();



        var allowedOrigin = builder.Configuration["Ui5:Origin"];

        builder.Services.AddControllers();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowUI5", policy =>
                policy.WithOrigins(allowedOrigin ?? "http://localhost:8080")
                      .AllowAnyHeader()
                      .AllowAnyMethod());
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



        app.UseCors("AllowUI5");
        app.MapControllers();
        app.Run();

    }



}



