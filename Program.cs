using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
namespace Game
{
    class Program
    {
        /// <summary>
        /// Main program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Create animal repository.
            List<AnimalDetails> animals = CreateAnimalData();
            //Get animal details from the user.
            AnimalDetails animalDetails = FetchAnimalCharacteristics();

            //Match the animal details with the characteristics.
            if (animalDetails != null)
            {
                AnimalDetails matchFound = animals.FindAll(delegate (AnimalDetails a) { return a.Soundex == animalDetails.Soundex; }).FirstOrDefault();
                if (matchFound != null)
                    Console.WriteLine("Here is the animal you are looking for : " + matchFound.AnimalName);
                else
                    Console.WriteLine("You Won!!!. We couldn't match any animals. ");
            }
        }

        /// <summary>
        /// Create animal repository.
        /// </summary>
        /// <returns>List<AnimalDetails></returns>
        private static List<AnimalDetails> CreateAnimalData()
        {
            List<AnimalDetails> animals = new List<AnimalDetails>
            {
                PopulateAnimalDetails("Kangaroo", "Y", "N", "N", "N", "N", "Y", "N", "Y", "Y", "N"),
                PopulateAnimalDetails("Wallaby", "Y", "N", "N", "N", "N", "Y", "N", "N", "Y", "N"),
                PopulateAnimalDetails("Koala", "Y", "N", "N", "N", "N", "Y", "N", "N", "Y", "Y"),
                PopulateAnimalDetails("Echidna", "Y", "N", "N", "N", "N", "Y", "Y", "N", "Y", "N"),
                PopulateAnimalDetails("Wombat", "Y", "N", "N", "N", "N", "Y", "N", "N", "N", "N"),
                PopulateAnimalDetails("Dog", "N", "N", "N", "N", "Y", "Y", "N", "N", "N", "N"),
                 PopulateAnimalDetails("Crocodile", "Y", "Y", "N", "N", "N", "Y", "N", "Y", "N", "N"),
                  PopulateAnimalDetails("Crocodile", "Y", "Y", "N", "N", "N", "Y", "N", "Y", "N", "N"),
            };
            return animals;
        }


        /// <summary>
        /// Add animal characteristics.
        /// </summary>
        /// <param name="animalName"></param>
        /// <param name="jungleAnimal"></param>
        /// <param name="animalLiveInWater"></param>
        /// <param name="flyingAnimal"></param>
        /// <param name="insectAnimal"></param>
        /// <param name="petAnimal"></param>
        /// <param name="mammal"></param>
        /// <param name="haveFeathers"></param>
        /// <param name="largeAnimal"></param>
        /// <param name="hoppingAnimal"></param>
        /// <param name="climbingAnimal"></param>
        /// <returns>AnimalDetails</returns>
        /// <remarks>deally a method should have less than 5 parameters... </remarks>
        private static AnimalDetails PopulateAnimalDetails(string animalName, string jungleAnimal,
                                                            string animalLiveInWater, string flyingAnimal, string insectAnimal, string petAnimal,
                                                            string mammal, string haveFeathers, string largeAnimal, string hoppingAnimal,
                                                            string climbingAnimal)
        {
            AnimalDetails animalInfo = new AnimalDetails
            {
                AnimalName = animalName,
                JungleAnimal = jungleAnimal,
                AnimalLiveInWater = animalLiveInWater,
                CanAnimalFly = flyingAnimal,
                InsectAnimal = insectAnimal,
                PetAnimal = petAnimal,
                Mammal = mammal,
                HaveFeathers = haveFeathers,
                LargeAnimal = largeAnimal,
                HoppingAnimal = hoppingAnimal,
                ClimbingAnimal = climbingAnimal
            };
            return animalInfo;
        }

        /// <summary>
        /// Get animal details from the user.
        /// </summary>
        /// <returns></returns>
        private static AnimalDetails FetchAnimalCharacteristics()
        {
            AnimalDetails animalInfo = new AnimalDetails();
            Console.WriteLine("Welcome to guess an animal game!. You can guess any australian animal and the program will try to animal name.");
            Console.WriteLine("Let' Start the game.");
            Console.WriteLine("Please asnwer below questions. You can only enter Y or N for each questions.");

            PropertyInfo[] properties = typeof(AnimalCharacteristics).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name + "?");
                String userEnteredValue = Console.ReadLine().ToUpper();

                if (String.CompareOrdinal(userEnteredValue, "Y") == 0 || String.CompareOrdinal(userEnteredValue, "N") == 0)
                {
                    property.SetValue(animalInfo, userEnteredValue);
                }
                else
                {
                    Console.WriteLine("You have entered an invalid answer. please restart the game.");
                    animalInfo = null;
                    break;
                }
                //String userEnteredValue1;
                //do
                //{
                //    userEnteredValue1 = Console.ReadLine().ToUpper();
                //    if (String.CompareOrdinal(userEnteredValue1, "Y") == 0 || String.CompareOrdinal(userEnteredValue1, "N") == 0)
                //    {
                //        property.SetValue(animalInfo, userEnteredValue1);
                //    }
                //    else
                //    {
                //        Console.WriteLine("You have entered an invalid answer. please enter Y or N to continue..");
                //    }
                //}
                //while ((String.CompareOrdinal(userEnteredValue1, "Y") == 0 || String.CompareOrdinal(userEnteredValue1, "N") == 0));
            }
            return animalInfo;
        }
    }
}