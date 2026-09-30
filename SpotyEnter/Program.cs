using SpotyEnter.Interfaces;

namespace SpotyEnter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MidiaAudio> playlist = new List<MidiaAudio>();

            bool rodando = true;
            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("SPOTY<ENTER> - SUA PLAYLIST DE PROGRAMAÇÃO");
                Console.WriteLine("1 - Adicionar musica");
                Console.WriteLine("2 - Adicionar podcast");
                Console.WriteLine("3 - Listar Playlist");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                try
                {
                    switch (opcao)
                    {
                        case "1":
                            Console.WriteLine("\n --NOVA MUSICA--");
                            Console.Write("Titulo: ");
                            string tituloMusica = Console.ReadLine();
                            Console.Write("Ano de lançamento: ");
                            int anoMusica = int.Parse(Console.ReadLine());
                            Console.Write("Duração: ");
                            double duracaoMusica = double.Parse(Console.ReadLine());
                            Console.Write("Artista: ");
                            string artistaMusica = Console.ReadLine();
                            Console.Write("Genero: ");
                            string generoMusica = Console.ReadLine();

                            Musica novaMusica = new Musica(tituloMusica, anoMusica, duracaoMusica, artistaMusica, generoMusica);
                            playlist.Add(novaMusica);

                            Console.WriteLine("Musica adicionada na playlist");
                            break;
                        case "2":
                            Console.WriteLine("\n --NOVO PODCAST--");
                            Console.Write("Titulo: ");
                            string tituloPoscast = Console.ReadLine();
                            Console.Write("Ano de lançamento: ");
                            int anoPodcast = int.Parse(Console.ReadLine());
                            Console.Write("Duração: ");
                            double duracaoPoscast = double.Parse(Console.ReadLine());
                            Console.Write("Apresentador: ");
                            string apresentadorPodcast = Console.ReadLine();
                            Console.Write("Episódio: ");
                            int episodioPodcast = int.Parse(Console.ReadLine());

                            Podcast novoPodcast = new Podcast(tituloPoscast,anoPodcast,duracaoPoscast,apresentadorPodcast,episodioPodcast);
                            playlist.Add(novoPodcast);
                            break;
                        case "3":
                            Console.WriteLine("\n === SUA PLAYLIST ===");
                            if(playlist.Count == 0){
                                Console.WriteLine("Sua playlist está vazia");
                            }
                            else
                            {
                                foreach(var midia in playlist)
                                {
                                    Console.WriteLine(midia.ExibirDetalhes());

                                    if(midia is IDownload midiaBixavel)
                                    {
                                        midiaBixavel.BaixarOffline();
                                    }
                                    Console.WriteLine("-------------------------");
                                }
                            }
                            break;
                        case "4":
                            rodando = false;
                            Console.WriteLine("Saindo do sistema...");
                            break;
                        default:
                            Console.WriteLine("Opção invalida");
                            break;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("ERRO: Voce digitou texto onde deveria ser numero");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO INESPERADO: {ex.Message}");
                }

                if( rodando)
                {
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                }
            }
        }
      
    }
}
