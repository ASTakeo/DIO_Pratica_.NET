using System;
using Projeto_Acervo.Classes;
using Projeto_Acervo.Interfaces;

namespace Projeto_Acervo
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();

        static void Main(string[] args)
        {
            string st_OpcaoOperacao;
            string st_MenuPrincipal_Aux;
                        
            string st_MenuPrincipal = MenuPrincipal(out st_OpcaoOperacao, "V", "N");
            st_MenuPrincipal_Aux = st_MenuPrincipal;

            while (st_MenuPrincipal.ToUpper() != "X")
            {
                // Série
                if (st_MenuPrincipal == "1")
                {
                    switch (st_OpcaoOperacao)
                    {
                        case "1":
                            ListarSeries();
                            Console.ReadLine();
                            st_MenuPrincipal = "V";
                            break;

                        case "2":
                            InserirSerie();
                            st_MenuPrincipal = "V";
                            break;

                        case "3":
                            AtualizarSerie();
                            st_MenuPrincipal = "V";
                            break;    

                        case "4":
                            ExcluirSerie();
                            break; 

                        case "5":
                            ConsultarSerie();
                            break;      

                        case "V":
                            Console.Clear();
                            st_MenuPrincipal = MenuPrincipal(out st_OpcaoOperacao, st_MenuPrincipal_Aux, "N");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }   
                }

                // Filme
                else if (st_MenuPrincipal == "2")
                {
                    switch (st_OpcaoOperacao)
                    {
                        case "1":
                            ListarFilmes();
                            Console.ReadLine();
                            st_MenuPrincipal = "V";
                            break;

                        case "2":
                            InserirFilme();
                            st_MenuPrincipal = "V";
                            break;

                        case "3":
                            AtualizarFilme();
                            st_MenuPrincipal = "V";
                            break;    

                        case "4":
                            ExcluirFilme();
                            break; 

                        case "5":
                            ConsultarFilme();
                            break;      

                        case "V":
                            Console.Clear();
                            st_MenuPrincipal = MenuPrincipal(out st_OpcaoOperacao, st_MenuPrincipal_Aux, "N");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }             
                }
                else if ((st_MenuPrincipal == "V") && (st_OpcaoOperacao == "V"))
                {
                   st_MenuPrincipal = MenuPrincipal(out st_OpcaoOperacao, st_MenuPrincipal_Aux, "N"); 
                }
                
                else if (st_MenuPrincipal == "V")
                {
                   st_MenuPrincipal = MenuPrincipal(out st_OpcaoOperacao, st_MenuPrincipal_Aux, "S");
                }
            }
        }

        private static string MenuPrincipal(out string st_OpcaoOperacao, string st_OpcaoMenuAcervo, string sn_Operacao)
        {
            string st_OpcaoMenuAcervo_Aux = st_OpcaoMenuAcervo;
            string st_OpcaoMenuOperacao   = "E";
            
            if (sn_Operacao == "N")
            {
                // Recupera o valor do menu de tipos de Acervo
                st_OpcaoMenuAcervo_Aux = MenuOpcaoAcervo();
            }
           
            switch (st_OpcaoMenuAcervo_Aux)
            {
                case "X":     
                    break;

                case "E":  // Retorno de erro/aviso
                {
                    Console.Clear();
                    st_OpcaoMenuAcervo_Aux = MenuOpcaoAcervo();
                    break;
                }

                // Montando o menú de operações
                default:
                { 
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("DIO - Movimentação do Acervo");
                    Console.WriteLine("Informe a operação desejada:");
                    Console.WriteLine();

                    // Montando o menu de operações (CRUD)
                    foreach (int i in Enum.GetValues(typeof(Operacao)))
                    {
                        Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Operacao), i));
                    }
            
                    Console.WriteLine("V. Voltar");
                    Console.WriteLine();
                    Console.Write("Opção: ");

                    // Recuperando o valor da operação (CRUD)
                    st_OpcaoMenuOperacao = Console.ReadLine().ToUpper();
                    Console.WriteLine();
                    
                    st_OpcaoOperacao = st_OpcaoMenuOperacao;
                    return st_OpcaoMenuAcervo_Aux;
                }
            }
            st_OpcaoOperacao = st_OpcaoMenuOperacao;
            return st_OpcaoMenuAcervo_Aux; 
        }
        
        private static string MenuOpcaoAcervo()
        {  
            string st_OpcaoMenuAcervo = "E";
            int st_OpcaoMenuAcervo_Aux;
            bool sn_OpcaoValida = false;
            
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("DIO - Seja Bem-Vindo");
            Console.WriteLine("Informe a opção de Acervo:");
            Console.WriteLine();
           
            // Montando o menu de tipos de acervos
            foreach (int i in Enum.GetValues(typeof(Acervo)))
            {
                Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Acervo), i));
            }

            Console.WriteLine("X. Sair");
            Console.WriteLine();
            Console.Write("Opção: ");
            
            // Recuperando o valor da tipo de acervo
            st_OpcaoMenuAcervo = Console.ReadLine().ToUpper();
            sn_OpcaoValida     = int.TryParse(st_OpcaoMenuAcervo, out st_OpcaoMenuAcervo_Aux);
                        
            // Operadores AND (&&) OR (||)
            if (((sn_OpcaoValida == false) && (st_OpcaoMenuAcervo != "X")) ||
                ((sn_OpcaoValida) && ((st_OpcaoMenuAcervo_Aux < 0) || (st_OpcaoMenuAcervo_Aux > 2))))
            {
                Console.WriteLine();
                Console.WriteLine("Opção informada inválida.");
                Console.WriteLine();
                Console.Write("Pressione qq. tecla para continuar...");
                Console.ReadLine();
                st_OpcaoMenuAcervo = "E";
            }
            return st_OpcaoMenuAcervo;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Série(s) Cadastrada(s)");
            Console.WriteLine();

            var lista = serieRepositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não há série(s) cadastrada(s).");
                Console.WriteLine();
                Console.Write("Pressione qq. tecla para continuar...");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("{0}. {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
            Console.WriteLine();
            Console.Write("Pressione qq. tecla para continuar...");
        }

        private static void InserirSerie()
        {
            Console.Clear();
            Console.WriteLine("DIO - Acervo de Séries");
            Console.WriteLine("Inserir nova série");
            Console.WriteLine();

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.Write("Informe o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o Título da série             : ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Informe o Ano do lançamento           : ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Informe a Descrição                   : ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id       : serieRepositorio.ProximoId(),
                                        genero   : (Genero)entradaGenero,
                                        titulo   : entradaTitulo,
                                        ano      : entradaAno,
                                        descricao: entradaDescricao);

            serieRepositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine();
            Console.Write("Informe o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o Título da série             : ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Informe o Ano do lançamento           : ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Informe a Descrição                   : ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id       : indiceSerie,
                                            genero   : (Genero)entradaGenero,
                                            titulo   : entradaTitulo,
                                            ano      : entradaAno,
                                            descricao: entradaDescricao);

            serieRepositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine();
            Console.Write("Informe o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            serieRepositorio.Exclui(indiceSerie);
        }

        private static void ConsultarSerie()
        {
            Console.Write("Informe o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = serieRepositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        // -------------- < FILMES > --------------
       
        private static void ListarFilmes()
        {
            Console.WriteLine("Listar Filme(s) Cadastrada(s)");
            Console.WriteLine();

            var lista = filmeRepositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não há filme(s) cadastrada(s).");
                Console.WriteLine();
                Console.Write("Pressione qq. tecla para continuar...");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                
                Console.WriteLine("{0}. {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
            Console.WriteLine();
            Console.Write("Pressione qq. tecla para continuar...");
        }

        private static void InserirFilme()
        {
            Console.Clear();
            Console.WriteLine("DIO - Acervo de Filme");
            Console.WriteLine("Inserir Novo Filme");
            Console.WriteLine();

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine();
            Console.Write("Informe o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o Título da série             : ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Informe o Ano do lançamento           : ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Informe a Descrição                   : ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id       : filmeRepositorio.ProximoId(),
                                        genero   : (Genero)entradaGenero,
                                        titulo   : entradaTitulo,
                                        ano      : entradaAno,
                                        descricao: entradaDescricao);

            filmeRepositorio.Insere(novoFilme);
        }

        private static void AtualizarFilme()
        {
            Console.Write("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}. {1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine();
            Console.Write("Informe o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o Título da série             : ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Informe o Ano do lançamento           : ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Informe a Descrição                   : ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id       : indiceFilme,
                                            genero   : (Genero)entradaGenero,
                                            titulo   : entradaTitulo,
                                            ano      : entradaAno,
                                            descricao: entradaDescricao);

            filmeRepositorio.Atualiza(indiceFilme, atualizaFilme);
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine();
            Console.Write("Informe o ID do filme: ");
            int indicefilme = int.Parse(Console.ReadLine());

			filmeRepositorio.Exclui(indicefilme);
		}

        private static void ConsultarFilme()
        {
            Console.Write("Informe o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

			var filme = filmeRepositorio.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		} 
    }
}