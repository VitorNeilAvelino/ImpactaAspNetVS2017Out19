using System.Collections.Generic;

namespace AspNet.Capitulo03.Portfolio.Models
{
    public class PortfolioViewModel
    {
        public PortfolioViewModel()
        {
            //CaminhosImagens = new List<string>();
        }

        public List<string> CaminhosImagens { get; set; } = new List<string>();
    }
}