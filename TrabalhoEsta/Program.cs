HistoricoEstacionamento historico = new HistoricoEstacionamento();

bool continuar = true;
while (continuar)
{
    Console.WriteLine();
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Registrar entrada de carro");
    Console.WriteLine("2 - Registrar saída de carro");
    Console.WriteLine("3 - Mostrar histórico de estacionamento");
    Console.WriteLine("4 - Sair do programa");
    Console.Write("Opção: ");

    string opcao = Console.ReadLine();
    Console.WriteLine();

    switch (opcao)
    {
        case "1":
            historico.RegistrarEntrada();
            break;
        case "2":
            historico.RegistrarSaida();
            break;
        case "3":
            historico.MostrarHistorico();
            break;
        case "4":
            continuar = false;
            Console.WriteLine("Saindo do programa...");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}