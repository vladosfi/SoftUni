using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }
                     

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();



        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.books = new List<Book>(books);
                this.Reset();
            }

            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                currentIndex++;

                if (currentIndex < books.Count)
                {
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
