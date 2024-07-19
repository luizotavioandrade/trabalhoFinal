using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoEsta
{
    public class RegistroEstacionamento
    {
        public Carro Carro { get; }
        public DateTime Entrada { get; }
        public DateTime? Saida { get; private set; }

        public RegistroEstacionamento(Carro carro, DateTime entrada)
        {
            Carro = carro;
            Entrada = entrada;
            Saida = null;
        }

        public void RegistrarSaida(DateTime saida)
        {
            Saida = saida;
        }
    }
}