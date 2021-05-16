using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Player1
    {
        public Player1()//Δήλωση κενού constructor
        {

        }

        public Player1(String Name)//Δήλωση constructor με ένα όρισμα
        {
            this.Name = Name;
        }

        public String Name { get; set; }//Αυτόματοι getters και setters

    }
}
