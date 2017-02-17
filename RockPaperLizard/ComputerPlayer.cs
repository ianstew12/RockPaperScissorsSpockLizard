using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperLizard
{
    public class ComputerPlayer : Player 
    {//member variables inherited from parent Player class
        //constructor
        public ComputerPlayer()
        {
            name = "ComputerPlayer";
            
        }
        //methods
        public override int ChooseWeapon()      //overrides ChooseWeapon method in parent Player class
        {
            Random RandomNumber = new Random();
            int ComputerChoice = RandomNumber.Next(0,5);
            return ComputerChoice;
        }
    }
}
