using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conta;

namespace ContaBancariaDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Conta.Conta c = new Conta.Conta("8547-8", "74859-X", 2000);
                c.depositar(500);
                c.sacar(1000);
                c.depositar(200);
                c.sacar(300);

                Console.WriteLine("Arquivo para visualizar Conta: " + c.visualizarSaldo());
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
