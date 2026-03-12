using System;
using System.Collections.Generic;

namespace F1_2026
{
    public class Persona
    {
        public string Nazionalita { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
    }

    public class Pilota : Persona
    {
        public int Esperienza { get; set; }
        public int Sorpasso { get; set; }
        public int Su_bagnato { get; set; }
        public int Gestione_gomme { get; set; }
        public int Gestione_carburante { get; set; }
        public int Partenza { get; set; }
        public int Difesa { get; set; }
    }

    public class Scuderia
    {
        public string Nome { get; set; }
        public int Velocità { get; set; }
        public int Accelerazione { get; set; }
        public int Frenata { get; set; }
        public int Powerunit { get; set; }
        public int affidabilità { get; set; }
    }

    public class Piazzamento
    {
        public int Posizione { get; set; }
        public Pilota Pilota { get; set; }
        public Scuderia scuderia { get; set; }
    }

    public class Stagione
    {
        public int Anno { get; set; }

        public List<Pilota> Pilota { get; set; } = new List<Pilota>();

        public List<Scuderia> Scuderia { get; set; } = new List<Scuderia>();

        public List<Piazzamento> ClassificaFinale { get; set; } = new List<Piazzamento>();

        public void AggiungiPiazzamento(Pilota pilota, Scuderia scuderia, int posizione)
        {
            Piazzamento piazzamento = new Piazzamento
            {
                Pilota = pilota,
                scuderia = scuderia,
                Posizione = posizione
            };
            ClassificaFinale.Add(piazzamento);
        }
        public void Ottieni_pilota(Scuderia scuderia)
        {
            foreach (Piazzamento p in ClassificaFinale)
            {
                if (p.scuderia == scuderia)
                {
                    Console.WriteLine($"Il pilota della scuderia {scuderia.Nome} è {p.Pilota.Nome} {p.Pilota.Cognome}");
                    return;
                }
            }
            Console.WriteLine($"Nessun pilota trovato per la scuderia {scuderia.Nome}");
        }

        public void Nuovo_piazzamento(string NomePlitoa, int NuovaPosizione)
        {
            Piazzamento piazzamento = new Piazzamento
            {
                Pilota = new Pilota { Nome = NomePlitoa },
                Posizione = NuovaPosizione
            };
            foreach (Piazzamento p in ClassificaFinale)
            {
                if (p.Pilota.Nome == NomePlitoa)
                {
                    p.Posizione = NuovaPosizione;
                    Console.WriteLine($"Il nuovo piazzamento di {NomePlitoa} è {NuovaPosizione}");
                    return;
                }
            }
        }
    }
}
