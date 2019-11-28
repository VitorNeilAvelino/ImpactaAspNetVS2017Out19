using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Loja.Mvc.Helpers
{
    public class CulturaHelper
    {
        private const string LinguagemPadrao = "pt-BR";
        private string linguagemSelecionada = LinguagemPadrao;
        private List<string> LinguagensSuportadas = new List<string> { "pt-BR", "en-US", "es" };

        public string NomeNativo { get; set; }
        public string Abreviacao { get; set; }

        public CulturaHelper()
        {
            DefinirLinguagemPadrao();
            ObterRegionInfo();
        }

        private void ObterRegionInfo()
        {
            var cultura = CultureInfo.CreateSpecificCulture(linguagemSelecionada);
            var regiao = new RegionInfo(cultura.LCID);

            NomeNativo = regiao.NativeName;
            Abreviacao = regiao.TwoLetterISORegionName.ToLower();
        }

        private void DefinirLinguagemPadrao()
        {
            var request = HttpContext.Current.Request;

            if (request.Cookies["LinguagemSelecionada"] != null)
            {
                linguagemSelecionada = request.Cookies["LinguagemSelecionada"].Value;
                return;
            }

            if (request.UserLanguages != null && 
                LinguagensSuportadas.Contains(request.UserLanguages[0]))
            {
                linguagemSelecionada = request.UserLanguages[0];
            }

            var cookie = new HttpCookie("LinguagemSelecionada", linguagemSelecionada);
            cookie.Expires = DateTime.MaxValue;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public CultureInfo ObterCultureInfo()
        {
            var linguagemSelecionada = HttpContext.Current
                .Request.Cookies["LinguagemSelecionada"];
            var linguagem = linguagemSelecionada?.Value ?? LinguagemPadrao;

            return CultureInfo.CreateSpecificCulture(linguagem);
        }
    }
}