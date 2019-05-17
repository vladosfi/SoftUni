using System;
using System.Text;

namespace _05.HTML
{
    class HTML
    {
        static void Main()
        {
            int counter = 0;
            StringBuilder html = new StringBuilder();

            while (true)
            {
                string input = Console.ReadLine();
                counter++;

                if (input == "end of comments")
                {
                    break;
                }

                if (counter == 1)
                {
                    html.AppendLine("<h1>");
                    html.Append('\t');
                    html.AppendLine(input);
                    html.AppendLine("</h1>");
                }
                else if(counter == 2)
                {
                    html.AppendLine("<article>");
                    html.Append('\t');
                    html.AppendLine(input);
                    html.AppendLine("</article>");
                }
                else
                {
                    html.AppendLine("<div>");
                    html.Append('\t');
                    html.AppendLine(input);
                    html.AppendLine("</div>");
                }
            }

            Console.WriteLine(html);
        }
    }
}
