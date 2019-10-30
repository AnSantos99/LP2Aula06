using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterTest
{
    class BrownBear : IBear
    {
        Random rnd;

        public BrownBear(bool hibernating = false) 
        {
            rnd = new Random();
        }


        public bool Hibernating { get; set; }

        public void GoTowards(object objectToWalkTowards)
        {
            if (!Hibernating) 
                Console.WriteLine("Bear moving towards " + objectToWalkTowards);
        }

        public void LookAt(object objectToLookAt)
        {
            if (!Hibernating)
                Console.WriteLine("Bear looking at " + objectToLookAt);
        }

        public void Roar()
        {
            if (Hibernating) Console.WriteLine("ZZZzzzz");
            else Console.WriteLine("Roaaaaaaaar!!");
        }

        public bool TryEat(object objectToEat)
        {
            if (!Hibernating && rnd.NextDouble() < 0.7)
                return true;
            return false;
                
        }
    }
}
