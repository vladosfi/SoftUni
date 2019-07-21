using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;

namespace WildFarm.Models.Animals
{
    public static class AnimalFactory 
    {
        public static Animal Create(string[] animalArgs)
        {

            string type = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalArgs[3]);

                return new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalArgs[3]);

                return new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = animalArgs[3];

                return new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = animalArgs[3];

                return new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                return new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                return new Tiger(name, weight, livingRegion, breed);
            }

            return null;
        }
    }
}
