using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
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
        public List<Cor> Cores { get; set; }
        public List<Modelo> Modelos { get; set; } = new List<Modelo>();
        public List<Combustivel> Combustiveis { get; set; }
        public List<Cambio> Cambios { get; set; }

        private void PopularControles()
        {
            Marcas = marcaRepositorio.Obter();

            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = modeloRepositorio
                    .ObterPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            Cores = corRepositorio.Obter();

            Combustiveis = Enum
                .GetValues(typeof(Combustivel))
                .Cast<Combustivel>()
                .ToList();

            Cambios = Enum
                .GetValues(typeof(Cambio))
                .Cast<Cambio>()
                .ToList();
        }

        public void Gravar()
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

            veiculoRepositorio.Gravar(veiculo);
        }
    }
}