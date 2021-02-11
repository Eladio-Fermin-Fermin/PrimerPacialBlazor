using Microsoft.EntityFrameworkCore;
using PrimerPacialBlazor.DAL;
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





    }
}
