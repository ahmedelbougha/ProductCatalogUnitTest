using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Services
{
    class Email
    {
        private string _from;
        private string _to;
        private string _subject;
        private string _body;

        public Email(string from, string to, string subject, string body)
        {
            _from = from;
            _to = to;
            _subject = subject;
            _body = body;
        }

        public bool SendEmail()
        {
            //format the message


            return true;
        }
    }
}
