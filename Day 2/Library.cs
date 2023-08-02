using System;


namespace Day2{
    class Library{

        public string Name {get; set;}
        public string Address {get; set;}

        public List<Book> Books {get; }

        public List<MediaItem> MediaItems {get;}

        public Library(string name, string address){
            Name = name;
            Address = address;
            Books = new List<Book>();
            MediaItems = new List<MediaItem>();
        }

        public void AddBook(Book book){
            Books.Add(book);
        }

        public void RemoveBook(Book book){
            Books.Remove(book);
        }

        public void AddMediaItem(MediaItem mediaItem){
            MediaItems.Add(mediaItem);
        }

        public void RemoveMediaItem(MediaItem mediaItem){
            MediaItems.Remove(mediaItem);
        }

        public void PrintCatalog(){
        Console.WriteLine($"Catalog for Library: {Name}, Address: {Address}");
        Console.WriteLine("\nBooks:");
        foreach (Book book in Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Publication Year: {book.PublicationYear}");
        }

        Console.WriteLine("\nMedia Items:");
        foreach (MediaItem item in MediaItems)
        {
            Console.WriteLine($"Title: {item.Title}, Type: {item.MediaType}, Duration: {item.Duration} minutes");
        }
    } 

    public List<Book> SearchBoks(string keyword){
        keyword = keyword.ToLower(); //convert keyword to lowercase
        List<Book> results = new List<Book>();
        foreach (Book book in Books)
        {
            if(book.Title.ToLower().Contains(keyword) || book.Author.ToLower().Contains(keyword) || book.ISBN.ToLower().Contains(keyword) || book.PublicationYear.ToString().Contains(keyword)){
                results.Add(book);
            }
        }

        return results;

    }

    public List<MediaItem> SearchMediaItems(string keyword){
        keyword = keyword.ToLower(); //convert keyword to lowercase
        List<MediaItem> results = new List<MediaItem>();
        foreach (MediaItem item in MediaItems)
        {
            if(item.Title.ToLower().Contains(keyword) || item.MediaType.ToLower().Contains(keyword) || item.Duration.ToString().Contains(keyword)){
                results.Add(item);
            }
        }

        return results;

    }

    class Book{
        
        public string Title {get; set;}
        public string Author {get; set;}
        public string ISBN {get; set;}
        public int PublicationYear {get; set;}

        public Book(string title, string author, string isbn, int publicationYear){
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
        }

        public ToString (){
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, Publication Year: {PublicationYear}";
        
    }

    class MediaItem{
        public string Title {get; set;}
        public string MediaType {get; set;}
        public int Duration {get; set;}

        public MediaItem(string title, string mediaType, int duration){
            Title = title;
            MediaType = mediaType;
            Duration = duration;
        }

        public ToString (){
            return $"Title: {Title}, Type: {MediaType}, Duration: {Duration} minutes";}
        
    }



    }}}