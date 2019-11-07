using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class CorRepositorio
    {
        static string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            ConfigurationManager.AppSettings["caminhoArquivoCor"]);

        // ToDo: OO - Polimorfismo por sobrecarga.
        public List<Cor> Obter()
        {
            var cores = new List<Cor>();

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var cor = new Cor();
                cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                cor.Nome = linha.Substring(5);

                cores.Add(cor);
            }

            return cores;
        }

        public Cor Obter(int id)
        {
            Cor cor = null;

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var linhaId = Convert.ToInt32(linha.Substring(0, 5));

                if (id == linhaId)
                {
                    cor = new Cor();
                    cor.Id = linhaId;
                    cor.Nome = linha.Substring(5);

                    break;
                }               
            }

            return cor;
        }
    }
}
