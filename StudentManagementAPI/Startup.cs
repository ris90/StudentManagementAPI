using Newtonsoft.Json.Serialization;
using StudentManagementAPI.Database;
using StudentManagementAPI.Services;

namespace StudentManagementAPI
{
    public class Startup
    {
        public static IConfiguration? Configuration { get; set; }
        public static IWebHostEnvironment? Environment { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMongoDbClient, MongoDbClient>();
            services.AddSingleton<IStudentService, StudentService>();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();

        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
