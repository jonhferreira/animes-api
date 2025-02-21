using AnimesAPI.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimesAPI.API.Extensions
{
    public static class Seed
    {
        public static async Task SeedAsync(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {

                var context = scope.ServiceProvider.GetRequiredService<AnimesDBContext>();

                using (context)
                {
                    try
                    {
                        var migrations = context.Database.GetPendingMigrations();
                        if (migrations.Any())
                        {
                            context.Database.Migrate();
                        }

                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
