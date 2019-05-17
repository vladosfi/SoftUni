using System;

namespace _02.Articles
{
    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
    class Articles
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ");
            Article article = new Article(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(": ");

                if (input[0] == "Edit")
                {
                    article.Edit(input[1]);
                }
                else if (input[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(input[1]);
                }
                else if (input[0] == "Rename")
                {
                    article.Rename(input[1]);
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}
