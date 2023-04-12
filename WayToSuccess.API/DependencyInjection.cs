using Microsoft.EntityFrameworkCore;
using WTSuccess.Infrastructure.Persistence.DataBases;

namespace WayToSuccess.API
{
    public static class DependencyInjection
    {
        public static void MigrateDatabase(this WebApplication application)
        {
            using var scope = application.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var db = services.GetRequiredService<EFContext>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
