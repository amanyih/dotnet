using System;


namespace Day2{
    class Program{
    static void Main( string[] args){
        //Task 1 : Shapes
        Shape circle = new Circle("Circle", 5);
        Shape rectangle = new Rectangle("Rectangle", 5, 10);
        Shape triangle = new Triangle("Triangle", 5, 10);


        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);

        //Task 2 : Library
        Library library = new Library("Library1", "Address1");

        Book book1 = new Book("Book1 Title", "Author1", "ISBN123", 2000);
        Book book2 = new Book("Book2 Title", "Author2", "ISBN456", 2010);
        MediaItem mediaItem1 = new MediaItem("MediaItem1 Title", "DVD", 120);
        MediaItem mediaItem2 = new MediaItem("MediaItem2 Title", "CD", 60);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddMediaItem(mediaItem1);
        library.AddMediaItem(mediaItem2);

        library.PrintCatalog();
        
    }

    static void PrintShapeArea(Shape shape){
        Console.WriteLine($"Area of {shape.Name} is {shape.CalculateArea()}");
    }
}
}
