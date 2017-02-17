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

    public override int ChooseWeapon()      
        {
            Console.WriteLine( name +  ", enter the number for your choice of weapon. \n0 - paper.\n1 - spock. \n2 - rock. \n3 - scissors. \n4 - lizard ");
            //+ foreach (string weapon in weapons) 
            //{Console.WriteLine(i + weapon /n}                     does i exist here?
            int HumanChoice = int.Parse(Console.ReadLine());    
             if (HumanChoice != 0 && HumanChoice != 1 && HumanChoice != 2 && HumanChoice != 3 && HumanChoice != 4)
            {
                Console.WriteLine("Invalid entry. Try again");
                ChooseWeapon();
            }//HumanChoice: example of when you declare a variable within a block of code, that variable is only "alive
             //within that block of code
            return HumanChoice;
        }
        
    }
}