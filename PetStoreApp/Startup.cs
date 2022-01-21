using System.Reflection;
using MediatR;
using PetStoreApp.Application.Orders.OrderService;
using PetStoreApp.Application.Pets.DataAccess;

namespace PetStoreApp;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<PetStoreDbContext>(options =>
            // {
            //     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            // });
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddSingleton<IOrderService, OrderService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
