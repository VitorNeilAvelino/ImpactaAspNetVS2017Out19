using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Oficina.WebPages
{
    public class VeiculoAplicacao
    {
        private readonly CorRepositorio corRepositorio = new CorRepositorio();
        private readonly MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        private readonly ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        private readonly VeiculoRepositorio veiculoRepositorio = new VeiculoRepositorio();

        public VeiculoAplicacao()
        {
            PopularControles();
        }

        public List<Marca> Marcas { get; set; }
        public string MarcaSelecionada { get; set; }
        public List<Cor> Cores { get; private set; }
        public List<Combustivel> Combustiveis { get; private set; }
        public List<Cambio> Cambios { get; private set; }
        public List<Modelo> Modelos { get; private set; } = new List<Modelo>();
        public string MensagemErro { get; private set; }

        private void PopularControles()
        {
            Marcas = marcaRepositorio.Obter();

            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = modeloRepositorio.ObterPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            Cores = corRepositorio.Obter();
            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();
        }

        public void Inserir()
        {
            try
            {
                var veiculo = new Veiculo();
                var formulario = HttpContext.Current.Request.Form;

                veiculo.Ano = Convert.ToInt32(formulario["ano"]);
                veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]);
                veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
                veiculo.Cor = corRepositorio.Obter(Convert.ToInt32(formulario["cor"]));
                veiculo.Modelo = modeloRepositorio.Obter(Convert.ToInt32(formulario["modelo"]));
                veiculo.Observacao = formulario["observacao"];
                veiculo.Placa = formulario["placa"];

                veiculoRepositorio.Inserir(veiculo);
            }
            catch (FileNotFoundException ex) when (!ex.FileName.ToUpper().Contains("SENHA"))
            {                
                MensagemErro =  $"Arquivo {ex.FileName} não encontrado.";
            }
            catch (UnauthorizedAccessException)
            {
                MensagemErro = "Arquivo sem permissão de gravação";
            }
            catch (DirectoryNotFoundException)
            {
                MensagemErro = "Caminho não encontrado";
            }
            catch /*(Exception)*/
            {
                MensagemErro = "Eita, algo deu errado!";
                // Logar o objeto exception.
            }
            //finally
            //{

            //}
        }
    }
}