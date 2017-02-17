using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperLizard
{
    public class HumanPlayer : Player 
    {//member variables inherited from parent Player class
       
    //constructor
    public HumanPlayer()
        {
           
        }
        //methods
    public override int ChooseWeapon()      //overrides ChooseWeapon method in parent Player class
        {
            Console.WriteLine( name +  ", enter the number for your choice of weapon. \n0 - paper.\n1 - spock. \n2 - rock. \n3 - scissors. \n4 - lizard ");
            int HumanChoice = int.Parse(Console.ReadLine());    
             if (HumanChoice != 0 && HumanChoice != 1 && HumanChoice != 2 && HumanChoice != 3 && HumanChoice != 4)
            {
                Console.WriteLine("Invalid entry. Try again");
                ChooseWeapon();
            }
            return HumanChoice;
        }
        
    }
}