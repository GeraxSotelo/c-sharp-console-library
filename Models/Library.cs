using System;
using System.Collections.Generic;

namespace library.Models
{
  class Library
  {
    public string Name { get; set; }
    public string Location { get; set; }
    //only members of the class itself have access to private properties
    private List<Book> Books { get; set; } = new List<Book>();



    public void AddBook(Book book)
    {
      Books.Add(book);
    }
    public void PrintBooks()
    {
      Console.Clear();
      Console.WriteLine("Welcome to the Library!\n");
      Console.WriteLine("Available Books:");
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1}.) {Books[i].Title} - {Books[i].Author}");
      }
    }

    public Library(string name, string location)
    {
      Name = name;
      Location = location;
    }
  }
}