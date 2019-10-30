using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterTest
{
    class BearAdapter : IDog
    {
        private IBear bear;

        public BearAdapter(IBear bear) 
        {
            this.bear = bear;
        }
        public void Bark()
        {
            bear.Roar();
        }

        public void Fetch(object objectToFetch)
        {
            bear.GoTowards(objectToFetch);
            bear.LookAt(objectToFetch);
            if(bear.TryEat(objectToFetch))
                    Console.WriteLine("Yay i ate the " + objectToFetch);

            else
                Console.WriteLine("oops i will not eat this");
        }
    }
}
