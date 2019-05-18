using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> Books;
        
        public Library(params Book[] books)
        {
            //this.Books = new SortedSet<Book>(books, new BookComparator());
            this.Books = new List<Book>(books);
            Books.Sort(new BookComparator());
        }  

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in this.Books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
