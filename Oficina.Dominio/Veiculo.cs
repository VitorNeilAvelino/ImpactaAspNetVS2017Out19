using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    // ToDo: OO - Classe ou abstração.
    public abstract class Veiculo
    {
        private string placa;

        // ToDo: OO - Encapsulamento.
        public string Placa
        {
            get
            {
                return placa.ToUpper();
            }
            set
            {
                placa = value.ToUpper();
            }
        }

        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }
        public int Ano { get; set; }
        public string Observacao { get; set; }

        protected List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (!Enum.IsDefined(typeof(Cambio), Cambio))
            {
                erros.Add($"O câmbio {Cambio} não é válido.");
            }

            return erros;
        }

        public abstract List<string> Validar();
    }
}