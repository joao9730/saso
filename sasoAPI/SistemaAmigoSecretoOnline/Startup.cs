using System;
using Microsoft.Owin;
using SistemaAmigoSecretoOnline.Repository;
using System.Configuration;
using SistemaAmigoSecretoOnline.Models;
using Microsoft.IdentityModel.Tokens;
using Owin;
using AutoMapper;

[assembly: OwinStartup(typeof(SistemaAmigoSecretoOnline.Startup))]

namespace SistemaAmigoSecretoOnline
{
    public partial class Startup : BaseRepositoy
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
