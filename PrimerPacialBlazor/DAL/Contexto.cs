using Microsoft.EntityFrameworkCore;
using PrimerPacialBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerPacialBlazor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
