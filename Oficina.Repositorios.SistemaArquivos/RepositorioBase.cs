using System;
using System.Configuration;
using System.IO;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class RepositorioBase
    {
        public RepositorioBase(string chave)
        {
            CaminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                ConfigurationManager.AppSettings[chave]);
        }

        public string CaminhoArquivo { get; }
    }
}