using System;
using library.Models;

namespace library
{
  class Program
  {
    static void Main(string[] args)
    {
      Book book1 = new Book("Book Title One", "Author 1");
      Book book2 = new Book("Book Title Two", "Author 2");
      Book book3 = new Book("Book Title Three", "Author 3");
      Library lib = new Library("here", "there");
      lib.AddBook(book1);
      lib.AddBook(book2);
      lib.AddBook(book3);
      lib.PrintBooks();
    }
  }
}
