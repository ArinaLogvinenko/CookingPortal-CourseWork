namespace CookingPortal.Extensions
{
    using System;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    public static class EnvironmentVariableExtensions
    {
        public static string GetDbConnectionString(this IConfiguration configuration, IWebHostEnvironment env)
        {
            return @"data source=(localdb)\MSSQLLOcalDB;Initial Catalog=CookingPortal;Integrated Security=True;";
        }
    }
}
