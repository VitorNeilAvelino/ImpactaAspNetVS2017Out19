using System;
using System.Windows.Forms;

namespace ImpactaAspNet.Capitulo01.Variaveis
{
    public partial class VariaveisForm : Form
    {
        int x = 32;
        int y = 16;
        int w = 45;
        int z = 32;
        int a = 10;

        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = 2;
            int b = 6, c = 10;
            var d = 13;

            //string nome = "Vítor";
            //var endereco = "R. Tal, 45";
            //var valor = 20.29m;
            //var aprovado = true;

            //Comentário: essa instrução não será executada.

            //var nascimento = new DateTime(1970, 12, 25);
            var A = 46;
            //a = 20;
            //a = "59";
            object coisa = "texto";
            coisa = DateTime.Now;

            //var e = 58;

            var @class = "3E";

            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add(string.Concat("b = ", b));
            resultadoListBox.Items.Add(string.Format("c = {0}, d = {1}", c, d));
            resultadoListBox.Items.Add($"d = {d}");

            resultadoListBox.Items.Add($"c * d = {c * d}");
            resultadoListBox.Items.Add($"d / a = {d / a}");
            resultadoListBox.Items.Add($"d % a = {d % a}");
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = 5;
            resultadoListBox.Items.Add($"x = {x}");

            //x = x - 3;
            x -= 3;

            resultadoListBox.Items.Add($"x = {x}");
        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pré-incremento");
            resultadoListBox.Items.Add($"a = {a}");
            resultadoListBox.Items.Add($"2 + ++a = {2 + ++a}");
            resultadoListBox.Items.Add($"a = {a}");

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pós-incremento");
            resultadoListBox.Items.Add($"a = {a}");
            resultadoListBox.Items.Add($"2 + a++ = {2 + a++}");
            resultadoListBox.Items.Add($"a = {a}");
            //if (a > 5)
            //{

            //}
        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (true)
            //{
            //    var a = 58;
            //}

            //a = 12;

            ExibirValoresVariaveis();

            resultadoListBox.Items.Add($"w <= x = {w <= x}");
            resultadoListBox.Items.Add($"x == z = {x == z}");
            resultadoListBox.Items.Add($"x != z = {x != z}");
        }

        private void ExibirValoresVariaveis()
        {
            resultadoListBox.Items.Add($"x = {x}");
            resultadoListBox.Items.Add($"y = {y}");
            resultadoListBox.Items.Add($"w = {w}");
            resultadoListBox.Items.Add($"z = {z}");
            resultadoListBox.Items.Add(new string('-', 50));
        }

        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValoresVariaveis();

            resultadoListBox.Items.Add($"w <= x || y == 16 = {w <= x || y == 16}");
            resultadoListBox.Items.Add($"x == z && z != x = {x == z && z != x}");
            resultadoListBox.Items.Add($"!(y > w) = {!(y > w)}");

        }

        private void ternarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ano;

            ano = 2014;
            resultadoListBox.Items
                .Add($"O ano {ano} é bissexto? {(ano % 4 == 0 ? "Sim" : "Não")}.");

            ano = 2020;
            resultadoListBox.Items
                .Add($"O ano {ano} é bissexto? {(DateTime.IsLeapYear(ano) ? "Sim" : "Não")}.");
        }
    }
}
