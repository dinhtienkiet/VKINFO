using Microsoft.EntityFrameworkCore;
using VKINFO.PERSISTENCE.Infrastructure;

namespace VKINFO.PERSISTENCE
{
    public class VKDbContextFactory : DesignTimeDbContextFactoryBase<VKDbContext>
    {
        protected override VKDbContext CreateNewInstance(DbContextOptions<VKDbContext> options)
        {
            return new VKDbContext(options);
        }
    }
}
