using Logger2.Factory.Contracts;
using Logger2.Layouts;
using Logger2.Layouts.Contracts;
using System;

namespace Logger2.Appenders.Factory
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout Create(string type)
        {
            if (type == "SimpleLayout")
            {
                return new SimpleLayout();
            }
            if (type == "XmlLayout")
            {
                return new XmlLayout();
            }
            else
            {
                throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
