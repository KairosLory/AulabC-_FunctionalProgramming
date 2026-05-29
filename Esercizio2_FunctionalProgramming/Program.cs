namespace Esercizio2_FunctionalProgramming
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public Book(string title, string author, string genre, int pages)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Pages = pages;
        }
    }
    internal class Program
    {
        static Func<Book, bool> And(Func<Book, bool> firstPredicate, Func<Book, bool> secondPredicate, Func<Book, bool> thirdPredicate)
        {
            return book => firstPredicate(book) && secondPredicate(book) && thirdPredicate(book);
        }

        static Func<Book, bool  > FilterByPagesOver400 = book => book.Pages > 400;
        static Func<Book, bool> FilterByGenreRomanzo = book => book.Genre == "Romanzo";
        static Func<Book, bool> FilterByAuthorUmbertoEco = book => book.Author == "Umberto Eco";

        static void FilterBooksGeneral(IEnumerable<Book> books, Func<Book, bool> predicate)
        {
            var filteredBooks = books.Where(predicate); // Uso Where della libreria LINQ per filtrare i libri in base alla condizione passata come parametro. Rendendo tutto molto più leggibile di un ulteriore if.
            foreach (var book in filteredBooks)
            {
                Console.WriteLine($"{book.Title} di {book.Author} - Genere: {book.Genre} - Pagine: {book.Pages}");
            }
        }
        static void Main(string[] args)
        {
            // ESERCIZIO 2:  Immaginate di dover sviluppare un’applicazione per la gestione di una libreria.
            // Vi viene chiesto inizialmente di filtrare solo i libri in base a un determinato genere.
            // Poi vi viene chiesto anche di filtrare i libri con più di 400 pagine.
            // Ancora vi viene richiesto di filtrare i dati in base a un determinato autore. 

            // Creo una lista fittizia di libri per mimare un possibile database della libreria
            List<Book> libraryDatabase = new List<Book>
            {
                new Book("Il Signore degli Anelli", "J.R.R. Tolkien", "Fantasy", 1178),
                new Book("1984", "George Orwell", "Romanzo", 328),
                new Book("Il Grande Gatsby", "F. Scott Fitzgerald", "Romanzo", 180),
                new Book("Harry Potter e la Pietra Filosofale", "J.K. Rowling", "Fantasy", 223),
                new Book("Il Codice Da Vinci", "Dan Brown", "Thriller", 454),
                new Book("Il Nome della Rosa", "Umberto Eco", "Romanzo", 512),
                new Book("Il Pendolo di Foucault", "Umberto Eco", "Romanzo", 600)
            };

            FilterBooksGeneral(libraryDatabase, FilterByPagesOver400); // Filtro tutti i libri con più di 400 pagine.
            Console.WriteLine("\n");
            FilterBooksGeneral(libraryDatabase, FilterByGenreRomanzo); // Filtro tutti i libri in base al genere "Romanzo".
            Console.WriteLine("\n");
            FilterBooksGeneral(libraryDatabase, And(FilterByPagesOver400, FilterByGenreRomanzo, FilterByAuthorUmbertoEco)); // Filtro tutti i libri in base a: 1) Pagine > 400, 2) Genere = Romanzo, 3) Autore = Umberto Eco.

            Console.ReadLine(); // Per tenere aperta la console
        }
    }
}
