using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles2
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
        
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }

    class Articles2
    {
        static void Main()
        {
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                Article article = new Article(
                    input[0],
                    input[1],
                    input[2] );

                articles.Add(article);
            }

            string orderCriteria = Console.ReadLine();

            List<Article> orderedArticles = new List<Article>();
            if (orderCriteria == "title")
            {
                orderedArticles = articles.OrderBy(a => a.Title).ToList();
            }
            else if (orderCriteria == "content")
            {
                orderedArticles = articles.OrderBy(a => a.Content).ToList();
            }
            else if (orderCriteria == "author")
            {
                orderedArticles = articles.OrderBy(a => a.Author).ToList();
            }

            foreach (var article in orderedArticles)
            {
                Console.WriteLine(article.ToString());
            }
            
        }
    }
}
