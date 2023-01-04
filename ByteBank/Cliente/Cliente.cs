using System;
using ByteBank.Sistemas;
using ByteBank.Contas;

namespace ByteBank.Clientes
{
    public class Cliente
    {
        #region AtributosCliente
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        #endregion
        
        #region ConstrutorCliente
        public Cliente(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
        }
        #endregion
    }
}
