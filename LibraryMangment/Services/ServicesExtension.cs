using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMangment.Services
{
    public static class ServicesExtension
    {
        private static Message _message = new Message();
        public static Message ErrorOut(string message)
        {
            _message.MessageText = "Something went wrong, try again later!";
            _message.MessageErrorText = message;
            _message.Status = "400";
            return _message;
        }

        public static Message NoProductFound()
        {
            _message.MessageText = "No Questions found!";
            _message.Status = "400";
            return _message;
        }
    }
}