using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OA.Application;
using OA.Application.Contracts.User;
using OA.Domain;
using OA.Domain.Services;
using OA.Domain.UserAgg;
using OA.Infrastructure.EFCore;
using OA.Infrastructure.EFCore.Repositories;

namespace OA.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserValidatorService, UserValidatorService>();

            services.AddTransient<IUnitOfWork, UnitOfWorkEF>();

            services.AddDbContext<MasterContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
