//Screen Sound(Projeto Curso C# Alura)

using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;

Musica musica1 = new Musica();
musica1.nome = "RIP";
musica1.artista = "BMTH";
musica1.duracao = 2;
musica1.disponivel = true;

string msgBoasVindas = "Seja bem vindo ao Sonzeras, seu sistema de interação com suas músicas favoritas!!!";
//List<string> listaDeBandas = new List<string>();
Dictionary<string, List<int>> bandasNotas = new Dictionary<string, List<int>>
{
    { "Linkin Park", new List<int> { 10, 10, 10, 9 } },
    { "U2", new List<int>() },
    { "Bring me The Horizon", new List<int>{ 9, 9, 7 }},
    { "Deftones", new List<int>{ 10, 5, 8}}

}; //Declaração de um dicionário com o a chave string(nome das bandas), e o valor de Lista(Notas das Bandas)

void BoasVindas()
{
    Console.WriteLine(@"
    
░██████╗░█████╗░███╗░░██╗███████╗███████╗██████╗░░█████╗░░██████╗
██╔════╝██╔══██╗████╗░██║╚════██║██╔════╝██╔══██╗██╔══██╗██╔════╝
╚█████╗░██║░░██║██╔██╗██║░░███╔═╝█████╗░░██████╔╝███████║╚█████╗░
░╚═══██╗██║░░██║██║╚████║██╔══╝░░██╔══╝░░██╔══██╗██╔══██║░╚═══██╗
██████╔╝╚█████╔╝██║░╚███║███████╗███████╗██║░░██║██║░░██║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚══╝╚══════╝╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░

");

    Console.WriteLine(msgBoasVindas);
}

void MenuOpcoes()
{
    Console.WriteLine("\n1 - Cadastrar Banda");
    Console.WriteLine("2 - Listar Bandas");
    Console.WriteLine("3 - Avaliar Banda");
    Console.WriteLine("4 - Média de avaliações");
    Console.WriteLine("0 - Sair");

    Console.Write("\nSua Opção: ");
    string opcao = Console.ReadLine()!;
    int opcaoNumero = int.Parse(opcao);

    switch (opcaoNumero)
    {
        case 1:
            RegistrarBandas();
            break;
        case 2:
            ListarBandas();
            break;
        case 3:
            AvaliarBandas();
            break;
        case 4:
            ExibirMediaBandas();
            break;
        case 0:
            Console.WriteLine("Obrigado pela companhia, até mais!");
            break;
        default:
            Console.WriteLine("Opção inválida!!");
            break;
    }
}

void RegistrarBandas()
{
    TitulosOpcoes("Registro de Banda");
    Console.Write("Insira o nome da Banda: ");
    string nomeBanda = Console.ReadLine()!;
    bandasNotas.Add(nomeBanda, new List<int>()); //usando o método Add para inserir na lista listaDeBandas o valor que coletei anteriormente
    Console.WriteLine($"A banda {nomeBanda} foi registrada"); //usando $ no começo da string para colocar o nome da variável entre chaves {}
    Thread.Sleep(2000);

    BoasVindas();
    MenuOpcoes();
}

void ListarBandas()
{
    Console.Clear();
    TitulosOpcoes("Lista de Bandas");
    /*  for (int i = 0; i < listaDeBandas.Count; i++) //estrutura de repetição para navegar por todos os itens da lista listaDeBandas, usando o método Count da instância lista
      {
          Console.WriteLine($"Banda  {listaDeBandas[i]}"); //exibindo os valores da lista na posição do valor do contador i
      }
  */

    foreach (string banda in bandasNotas.Keys)
    {
        Console.WriteLine($"Banda  {banda}");
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar");
    Console.ReadKey();
    Console.Clear();
    MenuOpcoes();

}

void TitulosOpcoes(string titulo)
{
    int qtdeLetras = titulo.Length;
    string asterisks = "".PadLeft(qtdeLetras, '*');
    Console.WriteLine(asterisks);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisks + "\n");
}

void AvaliarBandas()
{
    Console.Clear();
    TitulosOpcoes("Avaliar Bandas");

    //receber qual banda a pessoa deseja avaliar (Ler uma entrada do usuário Console.readline)
    Console.Write("Insira a banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;

    //conferir se a banda existe(percorrer as chaves da lista, conferindo com um if se o valor bate com o que o usuário inseriu)
    if (bandasNotas.ContainsKey(nomeBanda))
    {
        //receber nota e adicionar na lista de notas dessa banda(ler o valor e um Add na lista cuja chave é a banda que o usuário inseriu inicialmente)
        Console.Write("Qual nota deseja atribuir para esta banda? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasNotas[nomeBanda].Add(nota);
        Console.WriteLine($"\nNota registrada com sucesso para {nomeBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        MenuOpcoes();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não consta na base de dados ;-;");
        Console.WriteLine("\nDigite qualquer tecla para voltar");
        Console.ReadKey();
        Console.Clear();
        MenuOpcoes();
    }
}


void ExibirMediaBandas()
{
    Console.Clear();
    TitulosOpcoes("Médias das bandas");
    Console.WriteLine("Digite o nome da Banda que deseja consultar");
    string consultaBanda = Console.ReadLine()!;
    if (bandasNotas.ContainsKey(consultaBanda))
    {
        if (bandasNotas[consultaBanda].Any())
        {
            double mediaBandaUnica = bandasNotas[consultaBanda].Average();
            Console.WriteLine($"A média da Banda {consultaBanda} é {mediaBandaUnica}");
        }
        else
        {
            Console.WriteLine($"Não temos notas na base de dados para gerar a média de {consultaBanda}");
            Thread.Sleep(4000);
            Console.Clear();
            MenuOpcoes();
        }
    }
    else
    {
        Console.WriteLine("Que pena! Não consegui identificar essa banda no nosso banco de dados, segue todas as médias das bandas presentes\n");
        foreach (var bandas in bandasNotas)
        {
            if (bandas.Value.Any())
            {
                double mediaBanda = bandas.Value.Average();
                Console.WriteLine($"A média da Banda {bandas.Key} é {mediaBanda}");
            }
        }
    }
}

BoasVindas();
MenuOpcoes();