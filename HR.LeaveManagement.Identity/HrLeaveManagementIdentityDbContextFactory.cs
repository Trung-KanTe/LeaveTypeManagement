using HR.LeaveManagement.Identity.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HR.LeaveManagement.Identity
{
    public class HrLeaveManagementIdentityDbContextFactory : IDesignTimeDbContextFactory<HrLeaveManagementIdentityDbContext>
    {
        public HrLeaveManagementIdentityDbContext CreateDbContext(string[] args)
        {
            // Tìm đường dẫn chính xác tới file appsettings.json
            var basePath = Directory.GetCurrentDirectory();
            var solutionDir = Directory.GetParent(basePath).FullName; // Lên một cấp từ thư mục dự án hiện tại

            var configuration = new ConfigurationBuilder()
                .SetBasePath(solutionDir)
                .AddJsonFile("HR.LeaveManagement.Api/appsettings.json") // Điều chỉnh đường dẫn tới file appsettings.json
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<HrLeaveManagementIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("HrDatabaseConnectionString");

            optionsBuilder.UseSqlServer(connectionString);

            return new HrLeaveManagementIdentityDbContext(optionsBuilder.Options);
        }
    }
}
