using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using todoApi.Models;

[assembly: OwinStartup(typeof(todoApi.Startup))]

namespace todoApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
