using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionGame_User
{
    public class Package
    {
        public string Command { get; set; }
        public string Content { get; set; }

        public Package()
        {

        }
        public Package(string command, string content)
        {
            Command = command;
            Content = content;
        }
        public Package(string datos) //Ej: comanto: contenido
        {
            var sepIndex = datos.IndexOf(":", StringComparison.Ordinal);
            Command = datos.Substring(0, sepIndex);
            Content = datos.Substring(Command.Length + 1);
        }
        public string Serializar()
        {
            return $"{Command}:{Content}";
        }
        public static implicit operator string(Package package)
        {
            return package.Serializar();
        }
    }
}
