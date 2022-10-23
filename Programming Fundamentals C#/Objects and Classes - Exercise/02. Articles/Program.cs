using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialArticle = Console.ReadLine().Split(", ");

            Article article = new Article(initialArticle[0], initialArticle[1], initialArticle[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(": ");

                string command = commands[0];
                string content = commands[1];

                switch (command)
                {
                    case "Edit":
                        article.Edit(content);
                            break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(content);
                        break;
                    case "Rename":
                        article.Rename(content);
                        break;
                          
                }                
            }

            Console.WriteLine(article);
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


        public string Edit(string content) => Content = content;
        public string ChangeAuthor(string author) => Author = author;
        public string Rename(string title) => Title = title;

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";

        }
    }
}
