﻿using KDSApi.Domain.Interfaces.Repositories;
using KDSApi.Infra.ReadInterfaces;
using KDSApi.Infra.Repositories.ReadRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace KDSApi.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraDependency(this IServiceCollection services)
        {
            services
                .AddTnfEntityFrameworkCore()    // Configura o uso do EntityFrameworkCore registrando os contextos que serão usados pela aplicação
                .AddMapperDependency();         // Configura o uso do AutoMappper

            // Registro dos repositórios
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductReadRepository, ProductReadRepository>();

            return services;
        }
    }
}
