using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_TipoArticulo
    {
        private CD_TipoArticulos objCapaDato = new CD_TipoArticulos();

        public List<TipoArticulo> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(TipoArticulo obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre de la categoria no puede estar vacia";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }


        }

        public bool Editar(TipoArticulo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre de la categoria no puede estar vacia";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {

            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
