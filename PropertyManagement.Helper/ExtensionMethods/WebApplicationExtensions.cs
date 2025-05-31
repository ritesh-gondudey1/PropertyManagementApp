using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace PropertyManagement.Helper.ExtensionMethods
{
    public static class WebApplicationExtensions
    {
        public static void UseDevelopmentSettngs(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
