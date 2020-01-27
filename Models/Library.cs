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
    // CHECKOUT BOOK
    public void CheckoutBook(string selection)
    {
      Book selectedBook = ValidateBook(AvailableBooks, selection);
      if (selectedBook == null)
      {
        Console.WriteLine(" Invalid Selection");
        return;
      }
      else
      {
        selectedBook.Available = false;
        CheckedOut.Add(selectedBook);
        AvailableBooks.Remove(selectedBook);
        Console.WriteLine(" Check out successful!");
      }
    }
    // RETURN BOOK
    public void ReturnBook(string selection)
    {
      Book selectedBook = ValidateBook(CheckedOut, selection);
      if (selectedBook == null)
      {
        Console.WriteLine(" Invalid Selection");
        return;
      }
      else
      {
        selectedBook.Available = true;
        AvailableBooks.Add(selectedBook);
        CheckedOut.Remove(selectedBook);
        Console.Clear();
        Console.WriteLine(" Book Returned!");
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
      Console.WriteLine("\n Select a book number to checkout, (Q) to quit, or (R) to return a book");
    }
    public void PrintCheckedOut()
    {
      Console.WriteLine(" Books Checked Out: ");
      for (int i = 0; i < CheckedOut.Count; i++)
      {
        Console.WriteLine($"{i + 1}.) {CheckedOut[i].Title} - {CheckedOut[i].Author}");
      }
      Console.WriteLine(" Select a book number to return, (Q) to quit, or (A) to see available books.");
    }

    public Library(string name, string location)
    {
      Name = name;
      Location = location;
    }
  }
}