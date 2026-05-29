using System.Text.RegularExpressions;

namespace Esercizio1_FunctionalProgramming
{
    internal class Manga
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsInInventory { get; set; }

        public Manga(string title, string author, string genre, bool isInInventory)
        {
            Title = title;
            Author = author;
            Genre = genre;
            IsInInventory = isInInventory;
        }

    }
    internal class Program
    {
        static void PrintMangaInInventory(List<Manga> mangaList) // 2.Ho creato una prima funzione che stampa i manga in inventario, ora pongo il caso che un cliente voglia tra quelli in inventario solo gli gli shonen
        {
            foreach (var manga in mangaList)
            {
                if (manga.IsInInventory)
                {
                    Console.WriteLine($"{manga.Title} di {manga.Author} è nell'inventario.");
                }
            }
        }

        static void PrintMangaInInventoryGeneral(List<Manga> mangaList, Predicate<Manga> predicate) // 3. Ora la generalizzo per ogni possibile richiesta
        {
            foreach (var manga in mangaList)
            {
                if (predicate(manga))
                {
                    Console.WriteLine($"{manga.Title} di {manga.Author} è nell'inventario.");
                }
            }
        }

        static bool IsInInventory(Manga manga) => manga.IsInInventory; // 7. Creo delle regole nominate. In questo caso lascio manga.IsInInventory perchè è un boolean
        static bool IsShonen(Manga manga) => manga.Genre == "Shonen";
        static Predicate<Manga> And(Predicate<Manga> firstPredicate, Predicate<Manga> secondPredicate) => Manga => firstPredicate(Manga) && secondPredicate(Manga); // 8. Creo una funzione che combina due regole con l'operatore AND

        static void Main(string[] args)
        {
            // ESERCIZIO 1: 1.Riprodurre ciò che è stato fatto a lezione, ponendo molta attenzione ai passaggi e ai problemi affrontati e risolti. In particolare:
            //              2.partire da una funzione specifica
            //              3.generalizzarla
            //              4.capire che il problema non è il ciclo ma la regola
            //              5.introdurre Func<T, bool> Nell'esercizio ho usato il vecchio Predicate<T> che è un delegato predefinito in C# che rappresenta una funzione che prende un argomento di tipo T e restituisce un booleano al posto di Func<T, bool>
            //              6.usare lambda
            //              7.creare regole nominate
            //              8.combinare regole

            List<Manga> mangaList = new List<Manga>()
            {
                new Manga("One Piece", "Eiichiro Oda", "Shonen", true),
                new Manga("Bleach", "Tite Kubo", "Shonen", true),
                new Manga("Jujutsu Kaisen", "Gege Akutami", "Shonen", false),
                new Manga("I Diari della Speziale", "Natsu Hyuuga", "Isekai", true),
                new Manga("Sailor Moon", "Naoko Takeuchi", "Shojo", false)
            };

            PrintMangaInInventory(mangaList); // 2. Stampo i manga in inventario
            Console.WriteLine("\n");
            PrintMangaInInventoryGeneral(mangaList, m => m.IsInInventory); // 3. + 4. + 6. Generalizzo la funzione di sopra, ora può accogliere qualsiasi regola, in questo caso la stessa di prima, ma ora posso anche fare altre richieste, ad esempio voglio solo gli shonen in inventario
            Console.WriteLine("\n");
            PrintMangaInInventoryGeneral(mangaList, And(IsInInventory, IsShonen)); // 8. Ora voglio solo gli shonen che ci sono in inventario, quindi combino le due regole con l'operatore AND

            Console.ReadLine(); // Per tenere aperta la console
        }
    }
}
