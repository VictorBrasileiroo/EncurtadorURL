using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncurtadorURL.Core.Shared
{
    public static class ConversorBase62
    {
        public const string Alfabeto = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const int Base = 62;

        public static string Codificar(long numero)
        {
            if (numero == 0)
            {
                return Alfabeto[0].ToString();
            }

            var sb = new StringBuilder();
            while (numero > 0)
            {
                sb.Insert(0, Alfabeto[(int)(numero % Base)]);
                numero /= Base;
            }
            return sb.ToString();
        }

        public static long Decodificar(string base62)
        {
            long numero = 0;
            long potencia = 1;

            for (int i = base62.Length - 1; i >= 0; i--)
            {
                char caractere = base62[i];
                int digito = Alfabeto.IndexOf(caractere);

                if (digito == -1)
                {
                    throw new ArgumentException("Caractere inválido na string Base62: " + caractere);
                }

                numero += digito * potencia;
                potencia *= Base;
            }
            return numero;
        }
    }
}
