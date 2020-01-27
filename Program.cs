using System;
using library.Models;

namespace library
{
  class Program
  {
    static void Main(string[] args)
    {
      bool inLibrary = true;

      Book book1 = new Book("Book Title One", "Author 1");
      Book book2 = new Book("Book Title Two", "Author 2");
      Book book3 = new Book("Book Title Three", "Author 3");
      Library lib = new Library("here", "there");
      lib.AddBook(book1);
      lib.AddBook(book2);
      lib.AddBook(book3);
      Console.Clear();
      Enum activeMenu = Menus.CheckoutBook;
      while (inLibrary)
      {
        switch (activeMenu)
        {
          case Menus.CheckoutBook:
            lib.PrintBooks();
            break;
          case Menus.ReturnBook:
            lib.PrintCheckedOut();
            break;
        }
        string selection = Console.ReadLine();
        switch (selection.ToLower())
        {
          case "q":
            inLibrary = false;
            break;
          case "a":
            activeMenu = Menus.CheckoutBook;
            break;
          case "r":
            activeMenu = Menus.ReturnBook;
            break;
          default:
            if (activeMenu.Equals(Menus.CheckoutBook))
            {
              lib.CheckoutBook(selection);
            }
            else
            {
              lib.ReturnBook(selection);
            }
            break;
        }
      }
    }

    public enum Menus
    {
      CheckoutBook,
      ReturnBook
    }
  }
}
