using Microsoft.EntityFrameworkCore;
using PrimerPacialBlazor.DAL;
using PrimerPacialBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        //Guardar
        public async Task<bool> Guardar(Articulos articulos)
        {
            if (!await Existe(articulos.ArticuloId))
                return await Insertar(articulos);
            else
                return await Modificar(articulos);
        }

        //Buscar
        public async Task<Articulos> Buscar(int id)
        {
            Articulos articulos;
            try
            {
                articulos = await contexto.Articulos.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }

            return articulos;
        }

        //Eliminar
        public async Task<bool> Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var articulo = await contexto.Articulos.FindAsync(id);
                if(articulo != null)
                {
                    contexto.Articulos.Remove(articulo);
                    paso = await contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        //GetList
        public async Task<List<Articulos>> GetArticulos()
        {
            List<Articulos> lista = new List<Articulos>();
            try
            {
                lista = await contexto.Articulos.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public async Task<List<Articulos>> GetArticulos(Expression<Func<Articulos, bool>> criterio)
        {
            List<Articulos> lista = new List<Articulos>();

            try
            {
                lista = await contexto.Articulos.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

    }
}
