using System;
namespace dotNet.Proj1Bank{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}

        private double Saldo {get; set;}

        private double Credito {get; set;}

        private string Nome {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome){
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque){
            if (this.Saldo - valorSaque < (this.Credito *- 1)){
                Console.WriteLine ("Transação negada. Saldo insuficiente.");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Transação autorizada.");
            return true;
        }

        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;
            Console.WriteLine("Transação autorizada. Depositados R${0}.", valorDeposito);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino){
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString(){
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}
    }
}