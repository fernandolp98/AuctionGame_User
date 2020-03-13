using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionGame_User
{
    public class Map
    {
        public static string Serialize (List<string> lista)
        {
            if (lista.Count == 0) return null;
            var esElPrimero = true;
            var salida = new StringBuilder();
            foreach (var linea in lista)
            {
                if (esElPrimero) salida.Append(linea);
                else salida.Append($"|{linea}");
            }
            return salida.ToString();
        }
        public static List<string> Deserialize(string entrada)
        {
            var str = entrada;
            var lista = new List<string>();
            if (string.IsNullOrEmpty(str)) return lista;
            try
            {
                foreach (var linea in entrada.Split('|'))
                {
                    lista.Add(linea);
                }
            }
            catch (Exception)
            {

                return null;
            }
            return lista;
        }
    }
}
