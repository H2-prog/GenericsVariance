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
            Collection<Bird> birds = new Collection<Bird>();
            ICollectionGet<Bird> birdsGet = birds;
            ICollectionSet<Bird> birdsSet = birds;

            // No problem, since Collection implements 
            // ICollectionGet and ICollectionSet
            Collection<Animal> animals = new Collection<Animal>();
            ICollectionGet<Animal> animalsGet = animals;
            ICollectionSet<Animal> animalsSet = animals;


            AnimalProcessor processor = new AnimalProcessor();

            // How many of these work...?
            /* Case A, Case D, Case E and Case H will not work
             * Case A expect it to be a ICollectionGet<Animal>
             * Case D expect it to be a ICollectionGet<Bird>
             * Case F expect it to be a ICollectionSet<Animal>
             * Case H expect it to be a ICollectionSet<Bird>
            */

            // https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance
            // Covariance:
            //  - Enables you to use a more derived type than originally specified.
            // Danske ord:
            // Den kan bruges til klasser der er nedarvet, fra en base klasse
            processor.ProcessAnimals(birdsGet);   // Case A - Only works as a co-variant (by adding out keyword)
            processor.ProcessAnimals(animalsGet); // Case B

            processor.ProcessBirds(birdsGet);     // Case C
            processor.ProcessBirds(animalsGet);   // Case D - will not work...

            processor.InsertAnimals(birdsSet);    // Case E - Will not work...
            processor.InsertAnimals(animalsSet);  // Case F

            // https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance
            // Contravariance:
            //  - Enables you to use a more generic (less derived) type than originally specified.
            // Danske ord:
            // Det modsatte af Covariance,
            // Den kan bruges til base klasser, som har nedarvninge af andre klasser
            processor.InsertBirds(birdsSet);      // Case G
            processor.InsertBirds(animalsSet);    // Case H - Only works as a contra-variant (by adding in keyword)

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
