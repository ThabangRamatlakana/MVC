using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GoodsDonation> goodDonation { get; set; }
        public DbSet<MonetaryDonation> monetaryGoods { get; set; }
        public DbSet<Disaster> Disasters { get; set; }
    }
}
