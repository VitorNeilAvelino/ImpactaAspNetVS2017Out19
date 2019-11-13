using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer
{
    public class ViagensOnlineDbContext : DbContext
    {
        public ViagensOnlineDbContext() : base("viagensOnlineConnectionString")
        {

        }

        public DbSet<Destino> Destinos { get; set; }
    }
}
