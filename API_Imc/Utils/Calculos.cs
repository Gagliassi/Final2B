using System;

namespace API_Imcs.Utils
{
    public class Calculos
    {
        public static double CalcularImc(double Peso, double Altura)
            => Peso / (Altura * Altura);
            
            public static string ClassificacaoImc(double imc){

            if ( imc <18.9)
            {
                return "Abaixo do peso";   
            }else if (imc <=25 )
            {
                return "Peso normal";
            }else if ( imc <=30)
            {
                return "Sobrepeso";
            }else if (imc <=35)
            {
                return "Grau de Obesidade I";
            }else if (imc <=40)
            {
                return "Grau de Obesidade II";
            }else
            {
                return "Grau de Obesidade III";
            }
        }

        internal static string CalcularImc(double imc)
        {
            throw new NotImplementedException();
        }
    }
}