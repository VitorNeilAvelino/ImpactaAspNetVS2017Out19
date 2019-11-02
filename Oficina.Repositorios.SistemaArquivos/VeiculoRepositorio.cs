using Oficina.Dominio;
using System;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class VeiculoRepositorio
    {
        private readonly static string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            ConfigurationManager.AppSettings["caminhoArquivoVeiculo"]);
        XDocument arquivoXml;

        public void Inserir(Veiculo veiculo)
        {
            var registro = new StringWriter();
            var serializador = new XmlSerializer(typeof(Veiculo));

            serializador.Serialize(registro, veiculo);

            arquivoXml = XDocument.Load(caminhoArquivo);
            arquivoXml.Root.Add(XElement.Parse(registro.ToString()));
            arquivoXml.Save(caminhoArquivo);
        }
    }
}