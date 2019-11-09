using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class ModeloRepositorio : RepositorioBase
    {
        private XDocument arquivoXml;

        public ModeloRepositorio() : base("caminhoArquivoModelo")
        {

        }

        public List<Modelo> ObterPorMarca(int marcaId)
        {
            var modelos = new List<Modelo>();
            arquivoXml = XDocument.Load(CaminhoArquivo);

            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                //if (elemento.Element("marcaId").Value.Equals(marcaId.ToString()))
                if (elemento.Element("marcaId").Value == marcaId.ToString())
                {
                    var modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;

                    var marcaRepositorio = new MarcaRepositorio();

                    modelo.Marca = marcaRepositorio.Obter(marcaId);

                    modelos.Add(modelo);
                }
            }

            return modelos;
        }

        public Modelo Obter(int id)
        {
            Modelo modelo = null;
            arquivoXml = XDocument.Load(CaminhoArquivo);

            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                //if (elemento.Element("marcaId").Value.Equals(marcaId.ToString()))
                if (elemento.Element("id").Value == id.ToString())
                {
                    modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;

                    var marcaRepositorio = new MarcaRepositorio();

                    modelo.Marca = marcaRepositorio
                        .Obter(Convert.ToInt32(elemento.Element("marcaId").Value));

                    break;
                }
            }

            return modelo;
        }
    }
}
