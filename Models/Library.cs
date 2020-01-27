using System;
using System.Collections.Generic;

namespace library.Models
{
  class Library
  {
    public string Name { get; set; }
    public string Location { get; set; }
    //only members of the class itself have access to private properties
    private List<Book> AvailableBooks { get; set; } = new List<Book>();
    private List<Book> CheckedOut { get; set; } = new List<Book>();


    public void AddBook(Book book)
    {
      AvailableBooks.Add(book);
    }
    public void Checkout(string selection)
    {
      Book selectedBook = ValidateBook(AvailableBooks, selection);
      if (selectedBook == null)
      {
        Console.WriteLine("Invalid Selection");
        return;
      }
      else
      {
        selectedBook.Available = false;
        CheckedOut.Add(selectedBook);
        AvailableBooks.Remove(selectedBook);
        Console.WriteLine("Check out successful!");
      }
    }
    private Book ValidateBook(List<Book> booklist, string selection)
    {
      int bookIndex = 0;
      bool valid = Int32.TryParse(selection, out bookIndex);
      if (!valid || bookIndex < 1 || bookIndex > booklist.Count)
      {
        return null;
      }
      else
      {
        return booklist[bookIndex - 1];
      }
    }
    public void PrintBooks()
    {
      Console.WriteLine(" Welcome to the Library!\n");
      Console.WriteLine(" Available Books:");
      for (int i = 0; i < AvailableBooks.Count; i++)
      {
        Console.WriteLine($" {i + 1}.) {AvailableBooks[i].Title} - {AvailableBooks[i].Author}");
      }
      Console.WriteLine("\n Select a book number to checkout, (Q)uit, or (R)eturn a book");
    }

    public Library(string name, string location)
    {
      Name = name;
      Location = location;
    }
  }
}