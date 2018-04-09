using System;

namespace LibraryModel
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Tradutor { get; set; }
        public DateTime Launch { get; set; }
        public double Price { get; set; }
        public string Language { get; set; }
        public string PublishingCompany { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
