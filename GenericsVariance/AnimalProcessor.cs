using System;
using GenericsVariance.Animals;
using GenericsVariance.Collections;

namespace GenericsVariance
{
    public class AnimalProcessor
    {
        public void ProcessAnimals(IBetterCollection<Bird, Animal> animals)
        {
            for (int index = 0; index < animals.Count; index++)
            {
                Console.WriteLine(animals.Get(index).Sound());
                // animals.GetAnimal(index).FlapWings(); // Why does this NOT work...?
            }
        }

        public void ProcessBirds(IBetterCollection<Bird, Animal> animals)
        {
            for (int index = 0; index < animals.Count; index++)
            {
                Console.WriteLine(animals.Get(index).Sound());
                // animals.GetAnimal(index).FlapWings(); // Why does this NOT work...?
            }
        }

        public void InsertAnimals(IBetterCollection<Bird, Animal> animals)
        {
            for (int index = 0; index < 5; index++)
            {
                Bird b = new Bird("Tweety");
                b.Action();
                animals.Set(b); // Why does this work..?

                Cat c = new Cat("Spot");
                c.Action();
                //animals.Set(c); // Why does this work..?
            }
        }

        public void InsertBirds(IBetterCollection<Bird, Animal> birds)
        {
            for (int index = 0; index < 5; index++)
            {
                Bird b = new Bird("Tweety");
                b.Action();
                birds.Set(b);

                Cat c = new Cat("Spot");
                c.Action();
                // birds.SetAnimal(c); // Why does this NOT work...?
            }
        }
    }
}