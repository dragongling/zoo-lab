using Zoo.Core;
using Zoo.Core.Animals;
using Zoo.Core.Employees;

namespace Zoo.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var zooApp = new ZooApp();
            var zooMoscow = new Core.Zoo("Moscow");
            var zooPetersburg = new Core.Zoo("Petersburg");
            zooApp.AddZoo(zooMoscow);
            zooApp.AddZoo(zooPetersburg);

            var lion = new Lion();
            var elephant = new Elephant();
            var bison = new Bison();
            var penguin = new Penguin();
            var parrot = new Parrot();
            var turtle = new Turtle();
            var snake = new Snake();            

            var bigEnclosure = new Enclosure("Big reserve", zooMoscow, 10000);
            zooMoscow.AddEnclosure(bigEnclosure);
            zooMoscow.FindAvailableEnclosure(bison);
            zooMoscow.FindAvailableEnclosure(elephant);
            zooMoscow.FindAvailableEnclosure(parrot);
            zooMoscow.FindAvailableEnclosure(turtle);            

            var snakeTerrarium = new Enclosure("Terrarium", zooPetersburg, 4);
            var penguinChamber = new Enclosure("Penguins", zooPetersburg, 20);
            var lionCage = new Enclosure("Lion reserve", zooPetersburg, 5000);
            zooPetersburg.AddEnclosure(snakeTerrarium);
            zooPetersburg.AddEnclosure(penguinChamber);
            zooPetersburg.AddEnclosure(lionCage);

            zooPetersburg.FindAvailableEnclosure(lion);
            zooPetersburg.FindAvailableEnclosure(penguin);
            zooPetersburg.FindAvailableEnclosure(snake);

            var keeperMoscow = new ZooKeeper("Gavrilow", "Boris");
            keeperMoscow.AddAnimalExperience(bison);
            keeperMoscow.AddAnimalExperience(elephant);
            keeperMoscow.AddAnimalExperience(parrot);
            keeperMoscow.AddAnimalExperience(turtle);
            zooMoscow.HireEmployee(keeperMoscow);

            var vetMoscow = new Veterinarian("Ivanova", "Ekaterina");
            vetMoscow.AddAnimalExperience(bison);
            vetMoscow.AddAnimalExperience(elephant);
            vetMoscow.AddAnimalExperience(parrot);
            vetMoscow.AddAnimalExperience(turtle);
            zooMoscow.HireEmployee(vetMoscow);

            var keeperPeter = new ZooKeeper("Anischenko", "Ivan");
            keeperPeter.AddAnimalExperience(lion);
            keeperPeter.AddAnimalExperience(penguin);
            keeperPeter.AddAnimalExperience(snake);
            zooPetersburg.HireEmployee(keeperPeter);

            var vetPeter = new Veterinarian("Zaliznyuk", "Tatyana");
            vetPeter.AddAnimalExperience(lion);
            vetPeter.AddAnimalExperience(penguin);
            vetPeter.AddAnimalExperience(snake);
            zooPetersburg.HireEmployee(vetPeter);

            zooMoscow.FeedAnimals();
            zooPetersburg.FeedAnimals();
            zooMoscow.HealAnimals();
            zooPetersburg.HealAnimals();
        }
    }
}
