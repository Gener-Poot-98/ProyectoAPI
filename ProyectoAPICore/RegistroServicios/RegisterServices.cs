using Microsoft.Extensions.DependencyInjection;
using ProyectoAPICore.Business;
using ProyectoAPICore.Business.Repository.Interface;
using Microsoft.AspNetCore.Authentication.BearerToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPICore.RegistroServicios
{
    public class RegisterServices
    {
        public static void RegistrarServicios(IServiceCollection services)
        {
            services.AddScoped<IClientes, ClientesBAL>();
            services.AddScoped<IUser, UserBAL>();
            services.AddTransient<IAuthServices, AuthServices>();
        }
    }
}
