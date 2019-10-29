using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNet.Capitulo01.Troco
{
    public partial class TrocoForm : Form
    {
        public TrocoForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            decimal valorCompra = Convert.ToDecimal(valorCompraTextBox.Text);
            var valorPago = Convert.ToDecimal(valorPagoTextBox.Text);

            var troco = valorPago - valorCompra;

            trocoTextBox.Text = troco.ToString("C");

            // Convert - arredonda!
            //var moeda1Real = Convert.ToInt32(troco);

            var moedas = new decimal[] {1, 0.5m, 0.25m, 0.1m, 0.05m, 0.01m };
            //var j = 0;

            //foreach (var moeda in moedas)
            //{
            //    moedasListView.Items[j++].Text = ((int)(troco / moeda)).ToString();
            //    troco %= moeda;
            //}

            for (int i = 0; i < moedas.Length; i++)
            {
                moedasListView.Items[i].Text = ((int)(troco / moedas[i])).ToString();
                troco %= moedas[i];
            }

            //var moeda1Real = (int)(troco / 1);
            ////troco = troco % 1;
            //troco %= 1;

            //var moeda50 = (int)(troco / 0.5m);
            //troco %= 0.5m;

            //var moeda25 = (int)(troco / 0.25m);
            //troco %= 0.25m;

            //var moeda10 = (int)(troco / 0.1m);
            //troco %= 0.1m;

            //var moeda5 = (int)(troco / 0.05m);
            //troco %= 0.05m;

            //var moeda1 = (int)(troco / 0.01m);
            //troco %= 0.01m;

            ////var meuInteiro = int.Parse(troco);

            //moedasListView.Items[0].Text = moeda1Real.ToString();
            //moedasListView.Items[1].Text = moeda50.ToString();
            //moedasListView.Items[2].Text = moeda25.ToString();
            //moedasListView.Items[3].Text = moeda10.ToString();
            //moedasListView.Items[4].Text = moeda5.ToString();
            //moedasListView.Items[5].Text = moeda1.ToString();
        }
    }
}
