using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Borrow_App
{
    public partial class Book
    {
        public BookInfo Info { get; private set; }
        public bool IsBorrowed { get; private set; }

        public Book(BookInfo info)
        {
            Info = info;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            if (IsBorrowed) throw new InvalidOperationException("A könyv már ki van kölcsönözve.");
            IsBorrowed = true;
        }

        public void Return()
        {
            if (!IsBorrowed) throw new InvalidOperationException("A könyv nem volt kikölcsönözve.");
            IsBorrowed = false;
        }

        public string Print()
        {
            return $"(ID: {Info.Id}) - {Info.Title} - Author: {Info.Author}";
        }
    }


}
