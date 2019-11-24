using System;
using System.Collections.Generic;

namespace Loja.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public bool Entregue { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}