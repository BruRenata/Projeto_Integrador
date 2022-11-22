using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API_medicos.Utilitarios
{
    public static class Validacoes
    {
        public static void CPFValido(string cpf)
        {
            long total = 0;
            long mult = 10;
            long digitoVerificador1 = 0;
            foreach (char num in cpf)
            {
                if (mult >= 2)
                {
                    total += Convert.ToInt64(num.ToString()) * mult;
                    mult--;
                }
                else
                {
                    digitoVerificador1 = Convert.ToInt64(num.ToString());
                    break;
                }
            }

            long resto = (total * 10) % 11;
            if (digitoVerificador1 != resto)
            {
                if (resto == 10 && digitoVerificador1 == 0)
                {

                }
                else
                {
                    throw new Exception("CPF Inválido.");
                }
            }

            total = 0;
            mult = 11;
            long digitoVerificador2 = 0;
            foreach (char num in cpf)
            {
                if (mult >= 2)
                {
                    total += Convert.ToInt64(num.ToString()) * mult;
                    mult--;
                }
                else
                {
                    digitoVerificador2 = Convert.ToInt64(num.ToString());
                    break;
                }
            }

            resto = (total * 10) % 11;
            if (digitoVerificador2 != resto)
            {
                if (resto == 10 && digitoVerificador2 == 0)
                {

                }
                else
                {
                    throw new Exception("CPF Inválido.");
                }
            }
        }

        public static void CPFFormatoCorreto(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (!Regex.Match(cpf, @"^([0-9]){11}$").Success)
            {
                throw new Exception("CPF com formato incorreto.");
            }
        }
    }
}
