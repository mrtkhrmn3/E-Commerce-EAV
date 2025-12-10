using ECommerceEAV.Application.DependencyResolver;
using ECommerceEAV.Persistence.DependencyResolver;

namespace ECommerceEAV.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DI
            builder.Services.AddAutoMapperServices();
            builder.Services.AddFluentValidationServices();
            builder.Services.AddMediatRServices();

            builder.Services.AddDbContextServices();
            builder.Services.AddRepositoryServices();

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

            app.Run();
        }
    }
}
