// See https://aka.ms/new-console-template for more information
using DIOSeries;
using static System.Console;


SerieRepositorio repositorio = new SerieRepositorio();
string opcaoUsuario = "";
do
{
    opcaoUsuario = ObterOpcaoUsuario();
    switch (opcaoUsuario)
    {
        case "1":
            ListarSeries();
            break;
        case "2":
            InserirSerie();
            break;
        case "3":
            AtualizarSerie();
            break;
        case "4":
            ExcluirSerie();
            break;
        case "5":
            VisualizarSerie();
            break;
        case "C":
            Console.Clear();
            break;

        default:
            WriteLine("Opção inválida.");
            break;
    }

} while (opcaoUsuario.ToUpper() != "X");

void VisualizarSerie()
{
    var lista = repositorio.Lista();
    if (lista.Count == 0)
    {
        WriteLine("Nenhuma série cadastrada");
        return;
    }
    WriteLine("Digite o id da série.");
    int indiceSerie = int.Parse(ReadLine());

    var serie = repositorio.RetornaPorId(indiceSerie);
    WriteLine(serie);
}

void ExcluirSerie()
{
    var lista = repositorio.Lista();
    if (lista.Count == 0)
    {
        WriteLine("Nenhuma série cadastrada");
        return;
    }

    WriteLine("Digite o id da série.");
    int indiceSerie = int.Parse(ReadLine());

    repositorio.Exciui(indiceSerie);
}

void AtualizarSerie()
{
    var lista = repositorio.Lista();
    if (lista.Count == 0)
    {
        WriteLine("Nenhuma série cadastrada");
        return;
    }
    WriteLine("Digite o id da série.");
    int indiceSerie = 0;
    try
    {
        indiceSerie = int.Parse(ReadLine());
    }
    catch (System.Exception)
    {
        WriteLine("Indice não encontrado... Pressione enter para continuar");
        ReadLine();
    }

    int index = 1;
    foreach (var i in Enum.GetValues(typeof(Genero)))
    {
        WriteLine($"{index} - {i}");
        index++;
    }

    WriteLine("Digite o numero referente ao gênero listado acima.");
    int entradaGenero = int.Parse(ReadLine());

    WriteLine("Digite o Título da Série.");
    string entradaTitulo = ReadLine();

    WriteLine("Informe o ano de lançamento da série.");
    int entradaAno = int.Parse(ReadLine());

    WriteLine("Digite a Descrição da Série.");
    string entradaDescricao = ReadLine();

    Series atualizaSerie = new Series(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, descricao: entradaDescricao, ano: entradaAno);

    repositorio.Atualiza(indiceSerie, atualizaSerie);

}

void InserirSerie()
{
    WriteLine("Inserindo nova série.");
    int index = 1;
    foreach (var i in Enum.GetValues(typeof(Genero)))
    {
        WriteLine($"{index} - {i}");
        index++;
    }

    WriteLine("Digite o numero referente ao gênero listado acima.");
    int entradaGenero = int.Parse(ReadLine());
  
    WriteLine("Digite o Título da Série.");
    string entradaTitulo = ReadLine();

    WriteLine("Informe o ano de lançamento da série.");
    int entradaAno = int.Parse(ReadLine());

    WriteLine("Digite a Descrição da Série.");
    string entradaDescricao = ReadLine();

    Series novaSerie = new Series(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, descricao: entradaDescricao, ano: entradaAno);

    repositorio.Insere(novaSerie);

}

void ListarSeries()
{
    WriteLine("Listando Séries");
    var lista = repositorio.Lista();
    if (lista.Count == 0)
    {
        WriteLine("Nenhuma série cadastrada");
        return;
    }
    foreach (var serie in lista)
    {
        WriteLine("#ID {0}: - {1}", serie.RetornaID(), serie.RetornaTitulo());
    }
}

static string ObterOpcaoUsuario()
{
    WriteLine();
    WriteLine("DIO Séries a seu dirpor!!!");
    WriteLine("Informe a opção desejada:");

    WriteLine("1 - Listar séries");
    WriteLine("2 - Inserir nova série");
    WriteLine("3 - Atualizar série");
    WriteLine("4 - Excluir série");
    WriteLine("5 - Visualizar série");
    WriteLine("C - Limpar Tela");
    WriteLine("X - Sair");
    WriteLine();
    string opcaoUsuario = ReadLine().ToUpper();
    WriteLine();

    return opcaoUsuario;
}
//Series meuObjeito = new Series();
