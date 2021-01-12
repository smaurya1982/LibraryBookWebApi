using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMangment.Models;

namespace LibraryMangment.Services
{
   public interface IBookRepository
    {
        IEnumerable<Book> GetAllBook();
        Book Get(int Id);
        Message InserBook(BookViewModel value);
        Message UpdateBook(BookViewModel value);
        Message DeleteBook(int ID);


    }
}
