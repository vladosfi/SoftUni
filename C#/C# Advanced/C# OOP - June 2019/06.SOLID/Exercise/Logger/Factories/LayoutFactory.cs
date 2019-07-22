using LoggerTask.Layouts;
using LoggerTask.Exceptions;
using LoggerTask.Models.Contracts;
using LoggerTask.Models.Layouts;

namespace LoggerTask.Factories
{
    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            ILayout layout;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new InvalidLayoutTypeException();
            }

            return layout;
        }
    }
}
