using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class AnimalDetails : AnimalCharacteristics
    {
        public string AnimalName { get; set; }

        //This holds the animal Characteristics as a single word.. eg. "YNYNYYYYYYNN"
        public string Soundex
        {
            get
            {
                return String.Concat(JungleAnimal,
                                    AnimalLiveInWater,
                                    CanAnimalFly,
                                    InsectAnimal,
                                    PetAnimal,
                                    Mammal,
                                    HaveFeathers,
                                    LargeAnimal,
                                    HoppingAnimal,
                                    ClimbingAnimal);
            }
        }
    }
}