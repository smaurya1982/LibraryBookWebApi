using LibraryMangment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMangment.Services;

namespace LibraryMangment.Services
{
    public class BookRepository : IBookRepository
    {
        LibraryMangment_dbEntities libraryDBEntities = new LibraryMangment_dbEntities();
        Book book = new Book();
        Message _message = new Message();
        bool isstatus;

        public IEnumerable<Book> GetAllBook()
        {
            var _book= libraryDBEntities.Books.ToList();
            if (_book != null)
                return _book;
            else
                _message.MessageText = "Book not found!";
            return null;
            
        }

        public Book Get(int Id)
        {
            var _book= libraryDBEntities.Books.Where(d => d.Book_ID == Id).FirstOrDefault();
            //var _book= libraryDBEntities.Books.FirstOrDefault(x => x.Book_ID == Id);
            if (_book != null)
                return _book;
            else
                return null;
        }


        public Message InserBook(BookViewModel value)
        {
            if (value != null)
            {
                book.Book_Name = value.Book_Name;
                book.Author = value.Author;
                book.Options = value.Options;

                libraryDBEntities.Books.Add(book);
                libraryDBEntities.SaveChanges();
                isstatus = true;

                if (isstatus)
                {
                    _message.MessageText = "Book created successfully.";
                    _message.Status = "200";
                    return _message;
                }
                else
                {
                    _message.MessageText = "Book insert Faild!";
                    _message.Status = "400";
                    return _message;
                }
            }
            _message.MessageErrorText = "Book insert failed!";
            _message.Status = "400";
            return _message;

        }

        public Message UpdateBook(BookViewModel value)
        {

            var bookupdate = libraryDBEntities.Books.Where(p => p.Book_ID == value.Book_ID).FirstOrDefault<Book>();
            if (bookupdate != null)
                {
                bookupdate.Book_Name = value.Book_Name;
                bookupdate.Author = value.Author;
                bookupdate.Options = value.Options;
                libraryDBEntities.SaveChanges();
                isstatus = true;
                if (isstatus)
                    {
                        _message.MessageText = "Book updated successfully.";
                        _message.Status = "200";
                        return _message;
                    }
                    else
                    {
                        _message.MessageText = "Book updated Faild!";
                        _message.Status = "400";
                        return _message;
                    }
                }
                else
                {
                    _message.MessageErrorText = "Book Faild to update.";
                    _message.Status = "400";
                    return _message;
                }
            


        }
            public Message DeleteBook(int ID)
            {
            Book book = libraryDBEntities.Books.Where(p => p.Book_ID == ID).FirstOrDefault();
            if (book != null)
            {

                libraryDBEntities.Books.Remove(book);
                libraryDBEntities.SaveChanges();
                isstatus = true;
                if (isstatus)
                {
                    _message.MessageText = "Book deleted successfully.";
                    _message.Status = "200";
                    return _message;
                }
                else
                {
                    _message.MessageText = "Book delete Faild!";
                    _message.Status = "400";
                    return _message;
                }
            }
            else
            {
                _message.MessageText = "Record not found!";
                _message.Status = "400";
                return _message;
            }


        }
        }
    }