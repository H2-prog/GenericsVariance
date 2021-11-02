using System;
using GenericsVariance.Animals;
using GenericsVariance.Collections;

namespace GenericsVariance
{
    class Program
    {
        static void Main(string[] args)
        {
            // No problem, since Collection implements 
            // ICollectionGet and ICollectionSet
            //Collection<Bird> birds = new Collection<Bird>();
            //ICollectionGet<Bird> birdsGet = birds;
            //ICollectionSet<Bird> birdsSet = birds;

            BetterCollection<Bird, Animal> birds = new BetterCollection<Bird, Animal>();
            IBetterCollection<Bird, Animal> birdCollection = birds;
            //ICollectionGet<Bird> birdsGet = birds;
            //ICollectionSet<Bird> birdsSet = birds;

            // No problem, since Collection implements 
            // ICollectionGet and ICollectionSet
            //Collection<Animal> animals = new Collection<Animal>();
            //ICollectionGet<Animal> animalsGet = animals;
            //ICollectionSet<Animal> animalsSet = animals;

            BetterCollection<Bird, Animal> animals = new BetterCollection<Bird, Animal>();
            IBetterCollection<Bird, Animal> animalCollection = animals;


            AnimalProcessor processor = new AnimalProcessor();

            // How many of these work...?
            /* Case A, Case D, Case E and Case H will not work
             * Case A expect it to be a ICollectionGet<Animal>
             * Case D expect it to be a ICollectionGet<Bird>
             * Case F expect it to be a ICollectionSet<Animal>
             * Case H expect it to be a ICollectionSet<Bird>
            */

            // https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance
            // https://agirlamonggeeks.com/2019/05/29/vs-in-generic-interfaces-contravariance-vs-covariance-the-easier-part-1/
            // Covariance:
            //  - Enables you to use a more derived type than originally specified.
            //  - out keyword, means that T can be only returned as method results or property
            // Danske ord:
            // Den kan bruges til klasser der er nedarvet, fra en base klasse. 
            // ----------------------------------------------------------------------------------------------------
            // Contravariance:
            //  - Enables you to use a more generic (less derived) type than originally specified.
            //  - in keyword, means that T can be only passed as a parameter to a method
            // Danske ord:
            // Den kan bruges til base klasser, som har nedarvninge af andre klasser
            processor.ProcessAnimals(birdCollection);
            processor.ProcessAnimals(animalCollection);
            //processor.ProcessAnimals(birdsGet);   // Case A - Only works as a co-variant (by adding out keyword)
            //processor.ProcessAnimals(animalsGet); // Case B

            processor.ProcessBirds(birdCollection);
            //processor.ProcessBirds(animalCollection);
            //processor.ProcessBirds(birdsGet);     // Case C
            //processor.ProcessBirds(animalsGet);   // Case D - will not work... (Delete this)

            //processor.InsertAnimals(birdCollection);
            processor.InsertAnimals(animalCollection);
            //processor.InsertAnimals(birdsSet);    // Case E - Will not work... (Delete this)
            //processor.InsertAnimals(animalsSet);  // Case F

            processor.InsertBirds(birdCollection);
            processor.InsertBirds(animalCollection);
            //processor.InsertBirds(birdsSet);      // Case G
            //processor.InsertBirds(animalsSet);    // Case H - Only works as a contra-variant (by adding in keyword)

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
