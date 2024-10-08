﻿using IBL;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public static class BLCommon
    {
        public static IServiceCollection AddBLDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserBL, UserServices>(); // Make sure UserServices implements IUserBL
            services.AddScoped<IRepositoryBL, RepositoryServices>();
            services.AddScoped<IBranchBL, BranchServices>();
            return services;
        }
    }
}
