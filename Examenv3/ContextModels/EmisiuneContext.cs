using Examenv3.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Examenv3.ContextModels
{
    public class EmisiuneContext : DbContext
    {

        public EmisiuneContext(DbContextOptions<EmisiuneContext> options) : base(options) { }

        public DbSet<EMISIUNE> Emisiuni { get; set; }

        public DbSet<CANAL_TV> CanaleTV { get; set; }
    }
}
