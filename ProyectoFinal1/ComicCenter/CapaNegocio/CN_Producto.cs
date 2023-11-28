using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objCapaDato = new CD_Producto();

        public List<Producto> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Producto obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del producto no puede estar vacia";
            } else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripcion del producto no puede estar vacia";
            }else if (obj.oMarca.IdMarca == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }else if (obj.oTipoArticulo.IdTipoArticulo == 0)
            {
                Mensaje = "Debe seleccionar un tipo de articulo";
            } else if (obj.Precio == 0)
            {
                Mensaje = "Debe ingresar el precio del prducto";
            }else if (obj.Stock == 0)
            {
                Mensaje = "Debe ingresar el stock del prducto";
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

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del producto no puede estar vacia";
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripcion del producto no puede estar vacia";
            }
            else if (obj.oMarca.IdMarca == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }
            else if (obj.oTipoArticulo.IdTipoArticulo == 0)
            {
                Mensaje = "Debe seleccionar un tipo de articulo";
            }
            else if (obj.Precio == 0)
            {
                Mensaje = "Debe ingresar el precio del prducto";
            }
            else if (obj.Stock == 0)
            {
                Mensaje = "Debe ingresar el stock del prducto";
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


        public bool GuardarDatosImagen(Producto obj, out string Mensaje)
        {

            return objCapaDato.GuardarDatosImagen(obj, out Mensaje);
        }


        public bool Eliminar(int id, out string Mensaje)
        {

            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
