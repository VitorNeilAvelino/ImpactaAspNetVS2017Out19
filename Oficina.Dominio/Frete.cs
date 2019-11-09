using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    public class Frete
    {
        public Frete(UF uf, decimal valorProduto)
        {
            UF = uf;
            ValorProduto = valorProduto;

            Calcular();
        }

        public Cliente Cliente { get; set; }
        public decimal ValorProduto { get; set; }
        public UF UF { get; set; }
        public decimal ValorFrete { get; private set; }
        public Dictionary<UF, decimal> ValoresFrete { get; set; }
        public decimal ValorTotal { get; private set; }

        public void PreencherValores()
        {
            ValoresFrete.Add(UF.SP, 0.2M);
            ValoresFrete.Add(UF.RJ, 0.3M);

            ValorFrete = ValoresFrete[UF];
        }

        private void Calcular()
        {
            switch (UF.ToString().ToUpper())
            {
                case "SP":
                    ValorFrete = 0.2m;
                    break;

                case "RJ":
                case "ES":
                    ValorFrete = 0.3m;
                    break;

                case "MG":
                    ValorFrete = 0.35m;
                    break;

                case "AM":
                    ValorFrete = 0.6m;
                    break;

                default:
                    ValorFrete = 0.7m;
                    break;
            }

            //ValorTotal += (ValorProduto * ValorFrete);
            ValorTotal = (1 + ValorFrete) * ValorProduto;
        }
    }
}
