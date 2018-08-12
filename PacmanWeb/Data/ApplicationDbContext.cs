using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PacmanWeb.Models;
using PacmanWeb.Models.GameModels;

namespace PacmanWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        
        public virtual DbSet<RecordsModel> Records { get; set; }
    }
}
