using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNet.Capitulo01.Repeticao.Testes
{
    [TestClass]
    public class RepeticaoTeste
    {
        [TestMethod]
        public void TabuadaTeste()
        {
            for (int a = 1; a <= 10; a++)
            {
                for (int b = 1; b <= 10; b++)
                {
                    Console.WriteLine($"{a} * {b} = {a * b}");
                }

                Console.WriteLine(new string('-', 50));
            }
        }

        [TestMethod]
        public void EstruturaForTeste()
        {
            var i = 1;

            for (Console.WriteLine("Iniciou"); i <= 3; Console.WriteLine(++i))
            {
                //i++;
            }

            /*
             for(1. Inicialização; 2. Critério; 4. Pós-execução)
             {
                3. Execução
            }
             */
        }

        [TestMethod]
        public void ForApenasComCondicaoTeste()
        {
            var i = 1;

            for (; i <= 3;)
            {
                Console.WriteLine(i++);
            }
        }

        [TestMethod]
        public void ContinueTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i <= 5)
                {
                    continue;
                }

                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public void BreakTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i > 5)
                {
                    break;
                }

                Console.WriteLine(i);
            }
        }
    }
}
