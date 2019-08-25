using Logger2.Layouts.Contracts;
using System;
using System.Text;

namespace Logger2.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format => this.XmlFormat();

        private string XmlFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>");
            sb.AppendLine("   <date>{0}<date>");
            sb.AppendLine("   <level>{1}<level>");
            sb.AppendLine("   <message>{2}<message>");
            sb.AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
