using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperLizard
{
    public class Human : Player 
    { 
        public Human()
        {
        }

    public override void ChooseWeapon()      
        {
            Console.WriteLine( name +  ", enter the number for your choice of weapon. \n0 - paper.\n1 - spock. \n2 - rock. \n3 - scissors. \n4 - lizard ");
            int humanChoice = int.Parse(Console.ReadLine());    
            if (humanChoice != 0 && humanChoice != 1 && humanChoice != 2 && humanChoice != 3 && humanChoice != 4)
            {
                Console.WriteLine("Invalid entry. Try again");
                ChooseWeapon();
            }
            weaponChoice= humanChoice;
        }        
    }
}