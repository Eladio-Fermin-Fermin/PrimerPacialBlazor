using Microsoft.EntityFrameworkCore;
using PrimerPacialBlazor.DAL;
using PrimerPacialBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerPacialBlazor.BLL
{
    public class ArticulosBLL
    {
        private Contexto contexto { get; set; }

        public ArticulosBLL(Contexto contexto)
        {
            this.contexto = contexto;
        }

        //Metodo Existe.
        public async Task<bool> Existe(int id)
        {
            bool encontrado = false;
            try
            {
                encontrado = await contexto.Articulos.AnyAsync(a => a.ArticuloId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }

        //Metodo Insertar.
        public async Task<bool> Insertar(Articulos articulos)
        {
            bool paso = false;
            try
            {
                await contexto.Articulos.AddAsync(articulos);
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        //Metodo Modificar.
        private async Task<bool> Modificar(Articulos articulos)
        {
            bool paso = false;
            try
            {
                contexto.Entry(articulos).State = EntityState.Modified;
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


    }
}
