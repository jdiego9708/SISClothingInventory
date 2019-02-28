using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    public class MessageConvert
    {
        public static string ConvertMessage(string mensaje, int charactersValid)
        {
            string finishedMessage = mensaje;
            int totalCharacters = mensaje.Length;
            int charactersRange = 0;
            StringBuilder builder = new StringBuilder();
            List<string> cadenas = new List<string>();

            if (totalCharacters > charactersValid)
            {
                while (charactersRange < totalCharacters)
                {
                    if ((totalCharacters - charactersRange) < 46)
                    {
                        charactersValid = totalCharacters - charactersRange;
                    }

                    string str = mensaje.Substring(charactersRange, charactersValid);
                    charactersRange += charactersValid;
                    cadenas.Add(str);
                }

                foreach (string cadena in cadenas)
                {
                    builder.Append(cadena + "\r\n");
                }
                finishedMessage = Convert.ToString(builder);
            }
            
            return finishedMessage;
        }
    }
}
