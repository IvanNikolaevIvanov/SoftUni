using System;
using System.Collections.Generic;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < countOfArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                Article article = new Article(input[0], input[1], input[2]);

                articles.Add(article);
            }

            foreach (var item in articles)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }


        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";

        }
    }
}
