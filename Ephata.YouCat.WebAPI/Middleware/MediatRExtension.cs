﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ephata.YouCat.WebAPI.Middleware
{
    public static class MediatRExtension
    {
        public static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
        }
    }
}
