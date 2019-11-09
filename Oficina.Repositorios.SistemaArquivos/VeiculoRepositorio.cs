using System;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class VeiculoRepositorio : RepositorioBase
    {
       private XDocument arquivoXml;

        public VeiculoRepositorio() : base("caminhoArquivoVeiculo")
        {
            //arquivoXml = XDocument.Load(CaminhoArquivo);
        }

        public void Gravar<T>(T veiculo)
        {
            var registro = new StringWriter();
            var serializador = new XmlSerializer(typeof(T));

            serializador.Serialize(registro, veiculo);

            arquivoXml = XDocument.Load(CaminhoArquivo);

            arquivoXml.Root.Add(XElement.Parse(registro.ToString()));
            arquivoXml.Save(CaminhoArquivo);
        }
    }
}
