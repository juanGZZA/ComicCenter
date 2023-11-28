using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CapaNegocio
{
    public class CN_Recursos
    {
        //Encriptar texto

        public static string ConvertirSha256(string texto)
        {
            return texto;
        }
        public static string ConvertirBase64(string ruta, out bool conversion)
        {
            string textoBase64 = string.Empty;
            conversion = true;

            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);
                textoBase64 = Convert.ToBase64String(bytes);
            }
            catch
            {
                conversion = false;
            }

            return textoBase64;
        }

    }



}
