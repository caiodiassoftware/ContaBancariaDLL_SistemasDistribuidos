using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta
{
    public class Conta
    {
        private string numero { get; set; }
        private string agencia { get; set; }
        private double valor { get; set; }

        public Conta(string numero, string agencia, double valor)
        {
            this.numero = numero;
            this.agencia = agencia;
            this.valor = valor;
        }

        public string visualizarSaldo()
        {
            escrever("Operação: Visualizar Saldo " + "Saldo Atual: " + valor);
            return Path.Combine(Path.GetTempPath() + "conta.txt");
        }

        public void sacar(double valor)
        {
            if (this.valor >= valor)
            {
                this.valor -= valor;
                escrever("Operação: Sacar. " + "Foi realizado um saque no valor de " + valor.ToString() + ". Saldo atual: " + this.valor);
            }
            else
            {
                escrever("Operação: Sacar. " + "Saldo insuficiente para realizar saque!");
            }
        }

        public void depositar(double valor)
        {
            this.valor += valor;
            escrever("Operação: Depositar. " + "Foi realizado um deposito no valor de " + valor.ToString() + ". Saldo atual: " + this.valor);
        }

        private void escrever(string texto)
        {
            string path = Path.Combine(Path.GetTempPath() + "conta.txt");

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine(texto);
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(texto);
                    sw.Close();
                }
            }
        }
    }
}
