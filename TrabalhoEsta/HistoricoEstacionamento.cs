using System;
using System.Collections.Generic;
using TrabalhoEsta;

public class HistoricoEstacionamento
{
    private List<RegistroEstacionamento> registros;
    private int numeroMaximoVagas = 50;  

    public HistoricoEstacionamento()
    {
        registros = new List<RegistroEstacionamento>();
    }

    public void RegistrarEntrada()
    {
        if (registros.Count >= numeroMaximoVagas)
        {
            Console.WriteLine("Não há vagas disponíveis no momento.");
            return;
        }

        Console.WriteLine($"O Numero de vagas disponiveis é {numeroMaximoVagas}");

        Console.Write("Digite a placa do carro: ");
        string placa = Console.ReadLine();

        Console.Write("Digite o modelo do carro: ");
        string modelo = Console.ReadLine();

        Console.Write("Digite o nome do dono do carro: ");
        string dono = Console.ReadLine();


        Carro carro = new Carro { Placa = placa, Modelo = modelo, Dono = dono };
        RegistroEstacionamento registro = new RegistroEstacionamento(carro, DateTime.Now);
        registros.Add(registro);
        Console.WriteLine($"Entrada registrada: {carro.Placa} - {carro.Modelo} de {carro.Dono} às {registro.Entrada}");

        
        Console.WriteLine($"Vagas disponíveis: {numeroMaximoVagas - registros.Count}/{numeroMaximoVagas}");
    }

    public void RegistrarSaida()
    {
        Console.Write("Digite a placa do carro que está saindo: ");
        string placa = Console.ReadLine();

        RegistroEstacionamento registro = registros.Find(r => r.Carro.Placa == placa);
        if (registro != null)
        {
            Console.Write("Digite a data e hora da saída (no formato dd/MM/yyyy HH:mm:ss): ");
            DateTime saida;
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out saida))
            {
                registro.RegistrarSaida(saida);
                Console.WriteLine($"Saída registrada: {registro.Carro.Placa} - {registro.Carro.Modelo} às {saida}");

                // Mostrar quantas vagas restam
                Console.WriteLine($"Vagas disponíveis: {numeroMaximoVagas - registros.Count}/{numeroMaximoVagas}");
            }
            else
            {
                Console.WriteLine("Formato de data e hora inválido.");
            }
        }
        else
        {
            Console.WriteLine($"Carro com placa {placa} não encontrado no histórico.");
        }
    }
    public void MostrarHistorico()

    {
        Console.WriteLine("Histórico de Estacionamento:");
        foreach (var registro in registros)
        {
            string saida = registro.Saida.HasValue ? registro.Saida.Value.ToString() : "Ainda não saiu";
            Console.WriteLine($"Carro: {registro.Carro.Placa} - Entrada: {registro.Entrada}, Saída: {saida}");
        }
    }
}