using SpotyEnter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotyEnter
{
    public class MidiaAudio
    {
        public string Titulo { get; private set; }
        public int AnoLancamento { get; private set; }
        public double Duracao { get; private set; }

        public MidiaAudio(string titulo, int anoLancamento,  double duracao)
        {
            Titulo = titulo;
            AnoLancamento = anoLancamento;
            Duracao = duracao;
        }

        public virtual string ExibirDetalhes()
        {
            return $"[{AnoLancamento}] {Titulo} ({Duracao} min)";
        }

        public void Reproduzir()
        {
            Console.WriteLine($"Tocando agora: {Titulo}...");
        }
    }

    public class Musica : MidiaAudio, IDownload
    {
        public string Artista { get; private set; }
        public string Genero { get; private set; }

        public Musica(string titulo, int anoLancamento, double duracao, string artista, string genero)
            : base(titulo, anoLancamento, duracao)
        {
            Artista = artista;
            Genero = genero;
        }

        public override string ExibirDetalhes()
        {
            return $"Musica: {base.ExibirDetalhes()} - Artista: {Artista} | Genero: {Genero}";
        }

        public void BaixarOffline()
        {
            Console.WriteLine($"Download Concluido! A música {Titulo} de {Artista} agora está disponivel offline");
        }

    } 

    public class Podcast : MidiaAudio
    {
        public string Apresentador { get; private set; }
        public int Episodio { get; private set; }

        public Podcast(string titulo, int anoLancamento, double duracao, string apresentador, int episodio) 
            : base(titulo, anoLancamento, duracao)
        {
            Apresentador = apresentador;
            Episodio = episodio;
        }

        public override string ExibirDetalhes()
        {
            return $"Podcast: {base.ExibirDetalhes()} - Apresentador: {Apresentador} | Ep: {Episodio}";
        }

    }
}
