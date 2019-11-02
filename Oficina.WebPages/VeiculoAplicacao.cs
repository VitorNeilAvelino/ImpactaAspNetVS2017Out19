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
        CorRepositorio corRepositorio = new CorRepositorio();
        MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        VeiculoRepositorio veiculoRepositorio = new VeiculoRepositorio();

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
            catch (FileNotFoundException ex)
            {                
                HttpContext.Current.Items.Add("MensagemErro", $"Arquivo {ex.FileName} não encontrado.");
                throw;
            }
            catch (Exception)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Eita, algo deu errado!");
                throw;
            }
        }
    }
}