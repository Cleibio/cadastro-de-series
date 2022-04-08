namespace CadastroSeries
{
    class Program
    {
        static SeriesArmazenamento armazem = new SeriesArmazenamento();
        static void Main (string[]args)
        {
            string OpcaoUsuario = MenuOpcoesServicos();
            while(OpcaoUsuario.ToUpper() != "X")
            {
                 switch(OpcaoUsuario)
                 {
                     case "1":
                     ListarSeries();
                     break;
                     case "2":
                     CadastroSeries();
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
                     case "6":
                     Console.Clear();
                     break;
                     default:
                     throw new ArgumentException();
                }
                OpcaoUsuario = MenuOpcoesServicos();
            }
        }

        private static string MenuOpcoesServicos()
        {
            Console.WriteLine("----------- REPOSITÓRIO DE SÉRIES ----------");
            Console.WriteLine("Escolha o serviço desejado!");
            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Cadastrar Serie");
            Console.WriteLine("3 - Atualizar Series");
            Console.WriteLine("4 - Excluir Serie");
            Console.WriteLine("5 - Visualizar Serie");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
                
            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;               
        }

        private static void ListarGeneros()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }
        }

        private static void CreateUpdateSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }
           
            Console.Write("Informe o gênero da série que deseja cadastrar: ");
            int OpcaoGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o Nome da série que deseja cadastrar: ");
            string NomeSerie = Console.ReadLine();

            Console.Write("Faça uma breve descrição da série que deseja cadastrar: ");
            string DescricaoSerie = Console.ReadLine();

            Console.Write("Informe o ano de lançamento da série que deseja cadastrar: ");
            int AnoSerie = int.Parse(Console.ReadLine());
        }

        private static void CadastroSeries ()
        {
            Console.WriteLine("-------- PAINEL DE CADASTRO DE SÉRIES ---------");
            ListarGeneros();
            Console.Write("Informe o gênero da série que deseja cadastrar: ");
            int OpcaoGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o Nome da série que deseja cadastrar: ");
            string NomeSerie = Console.ReadLine();

            Console.Write("Faça uma breve descrição da série que deseja cadastrar: ");
            string DescricaoSerie = Console.ReadLine();

            Console.Write("Informe o ano de lançamento da série que deseja cadastrar: ");
            int AnoSerie = int.Parse(Console.ReadLine());
            Series NovaSerie = new Series(id: armazem.IdProximo(),genero: (Genero)OpcaoGenero,titulo:NomeSerie,descricao:DescricaoSerie,ano:AnoSerie);
            armazem.CadastrarSerie(NovaSerie);

        }

        private static void AtualizarSerie(){
            Console.Write("Informe o Id da série que deseja atualizar: ");
            int IdSerieAtualizar = int.Parse(Console.ReadLine());

            ListarGeneros();
            Console.Write("Informe o gênero da série: ");
            int OpcaoGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o Nome da série: ");
            string NomeSerie = Console.ReadLine();

            Console.Write("Faça uma breve descrição da série: ");
            string DescricaoSerie = Console.ReadLine();

            Console.Write("Informe o ano de lançamento da série: ");
            int AnoSerie = int.Parse(Console.ReadLine());

            Series SerieAtualizada = new Series(id: IdSerieAtualizar,genero: (Genero)OpcaoGenero,titulo:NomeSerie,descricao:DescricaoSerie,ano:AnoSerie);
            armazem.AtualizarSerie(IdSerieAtualizar, SerieAtualizada);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Informe o Id da série que deseja atualizar: ");
            int IdExcluirSerie = int.Parse(Console.ReadLine());
            armazem.ExcluirSerie(IdExcluirSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("---------- LISTA DE SÉRIES CADASTRADA NO SISTEMA ----------");
            var lista = armazem.ListarSeries();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada no Sistema!");
                return;
            }
            foreach (var series in lista)
            {
                var StatusSerie = series.CorfirmacaoExclusao();
                Console.WriteLine("{0} - {1} - {2}",series.RetornaIdSerie(),series.RetornaTituloSerie(),StatusSerie ? "Excluído" : "Cadastrado");
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write("Informe o Id da série que deseja visualizar: ");
            int IdSerieVisualizar = int.Parse(Console.ReadLine());
            var serieVisualizar = armazem.RetornaPorId(IdSerieVisualizar);
            Console.WriteLine(serieVisualizar);
        }
        
    }
}