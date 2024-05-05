using Contactmanagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contactmanagement.Data
{
    public class ApplicationDbContaxt : DbContext
    {
        private readonly ApplicationDbContaxt _db;

        public ApplicationDbContaxt(DbContextOptions options) :base(options)
        {
        }

        public DbSet<Contact> Contacts {  get; set; }
    }
}
