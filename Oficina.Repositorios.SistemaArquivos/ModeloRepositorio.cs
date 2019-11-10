using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class ModeloRepositorio
    {
        private static readonly string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            ConfigurationManager.AppSettings["caminhoArquivoModelo"]);

        private readonly XDocument arquivoXml = XDocument.Load(caminhoArquivo);

        public List<Modelo> ObterPorMarca(int marcaId)
        {
            var modelos = new List<Modelo>();

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
