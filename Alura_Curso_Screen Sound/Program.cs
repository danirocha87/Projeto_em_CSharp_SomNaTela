//Nome do projeto_ Screen Sound

using System.ComponentModel;


//variavel com letra minuscula 
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound Dani & Dani";



//aqui estou criando uma lista de bandas
//List<string> listaDasBandas = new List<string>();
//aqui mostro uma forma de criar uma lista ja com itens nela 
//List<string> listaDasBandas = new List<string>{"u2", "Calipson", "Beatles"};


//aqui ao inves de usar List eu uso dicionario
// escrevo dicionario
//o tipo da chave<> sera de  string porque vai receber nome 
//o valor sera as notas, mas ira receber varios notas então tive que fazer uma Lista com as notas inteiras INT
// depois escrevo o nome que quero neste caso bandasRegistradas
Dictionary<string, List<int>> bandasRegistradas= new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 08, 06 });
bandasRegistradas.Add("the beetles", new List<int> ());



//funcao com letra maiuscula
void ExibirLogo()
{
    //isso de colocar o @ na frente se chama Verbatim Literal
    Console.WriteLine(@"
██████╗░░█████╗░███╗░░██╗██╗    ██████╗░░█████╗░███╗░░██╗██╗
██╔══██╗██╔══██╗████╗░██║██║    ██╔══██╗██╔══██╗████╗░██║██║
██║░░██║███████║██╔██╗██║██║    ██║░░██║███████║██╔██╗██║██║
██║░░██║██╔══██║██║╚████║██║    ██║░░██║██╔══██║██║╚████║██║
██████╔╝██║░░██║██║░╚███║██║    ██████╔╝██║░░██║██║░╚███║██║
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝    ╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═╝");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{

    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda.");
    Console.WriteLine("Digite 2 para mostrar uma banda.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a média de uma banda.");
    Console.WriteLine("Digite -1 para sair.");

    Console.Write("\nDigite a sua opção:");
    //usei o ! porque nao quero receber um valor nulo, mas sim uma string
     string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica) 
    
    { case 1: RegistrarBanda();
            break;
      case 2: MostrarBandasRegistradas();
            break;
      
      case 3:AvaliarUmaBanda();
            break;
      case 4: MediaDaBanda();
            break;
      case -1: Console.WriteLine("Você escolheu sair, até breve! " + opcaoEscolhida);
            break;
     default: Console.WriteLine("Opção invalida!");
            break;
    
    }
}
void RegistrarBanda() 
{ 
    // clear para limpar o console
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    //aqui estou listando o nome das bandas que recebi do usuario 
    //listaDasBandas.Add(nomeDaBanda);

    //aqui estou mostrando como usar dicionario ao inves de List
    //aqui eu colo o que quero que tenha neste caso o nome das bandas
    //e uma lista vazia com as notas inteiras que ainda não temos
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso.");
    
    //aqui coloco para a plicaçacao esperar um pouco antes de reiniciar
    Thread.Sleep(1000);
   
    // clear para limpar o console
    Console.Clear();
    
    //aqui chamo a função para exibir novamente
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("lista de todas as bandas registradas");

    //faço o for para percorrer toda minha lista de bandas e mostrar ela.
    // faço o count para contar todas as bandas
    //for (int i = 0; i < listaDasBandas.Count; i++)
    // {
    //   Console.WriteLine($"Banda: {listaDasBandas[i]}\n");
    // }

    //Agora vou mostrar outra forma de fazer a lista com foreach
    //foreach (string banda in listaDasBandas)

    //aqui vou fazer o foreach com o dicionario
    // coloco o nome que tenho agora que é bandasRegistradas
    //para pegar só as chaves que é o nome da banda colocamos o .keys
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    //aqui eu criei uma variavel para saber a quantidade de letras tem no meu titulo
    int quantidadeDeLetras = titulo.Length;
    //aqui estou criando uma string vazia para adicionar um caracter que é o *
    //o Empty.PadLeft é para colocar itens a esquerda
    string asteristicos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteristicos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteristicos + "\n");
}


void AvaliarUmaBanda()
{
    // para criar esta funcçao precisamos
    //primeiro digital qual a banda deseja avaliar
    //se a banda existir no dicionario. atibuir uma nota
    //se não volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        //aqui eu uso o parse porque o readline só recebe string
        //e coloco o ! porque precisa ser algum valor não aceito nulo.
        int nota = int.Parse(Console.ReadLine()!);
        // aqui eu peguei todas as bandas que tenho
        //[] peguei a lista com o nome da banda
        // .ADD e adicionei o valor da nota.
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}!");
        // aqui uso para esperar alguns segundos
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
            
            
            }
    else 
    {
        Console.WriteLine($"\n A banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void MediaDaBanda() 
{
    Console.Clear();
    ExibirTituloDaOpcao("A média da banda é:");
    Console.WriteLine("Qual o nome da banda que deseja saber a média?");
    string nomeDaBanda = Console.ReadLine()!;

    //esse if uso para saber ser o nome da banda existe na minha lista
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        //faço essa lista para pegar todas as notas registradas
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];

        //tem uma funcao no c# que ja faz a media das notas chamado Average()
        Console.WriteLine($"\n À média da banda {nomeDaBanda} é  {notasDaBanda.Average()}.");
        Console.WriteLine("Digite uma tecla para voltar ao menu princiapl.");
        Console.ReadKey();
        Console.Clear() ;
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"\n A banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
        



}

ExibirOpcoesDoMenu();


