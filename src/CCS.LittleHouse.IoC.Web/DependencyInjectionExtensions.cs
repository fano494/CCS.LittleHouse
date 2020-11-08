using AutoMapper;
using CCS.LittleHouse.Aplication.AutoMapper.Users;
using CCS.LittleHouse.Aplication.Interfaces.Journals;
using CCS.LittleHouse.Aplication.Interfaces.Users;
using CCS.LittleHouse.Aplication.Services.Journals;
using CCS.LittleHouse.Aplication.Services.Users;
using CCS.LittleHouse.Data.Repositories.Journals;
using CCS.LittleHouse.Data.Repositories.Users;
using CCS.LittleHouse.Domain.Models.Users;
using CCS.LittleHouse.Domain.Repositories.Journals;
using CCS.LittleHouse.Domain.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CCS.LittleHouse.IoC.Web
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUsersAppService, UsersAppService>();
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddSingleton<IJournalsAppService, JournalsAppService>();
            services.AddSingleton<IJournalsRepository, JournalsRepository>();
            return services;
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            Type[] profiles = new Type[]
            {
                typeof(UsersMappingProfile)
            };
            services.AddAutoMapper(profiles);
        }
    }
}
