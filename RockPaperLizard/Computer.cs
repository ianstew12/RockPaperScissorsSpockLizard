using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperLizard
{
    public class Computer : Player 
    {
        public Computer()
        {
            this.name = "ComputerPlayer";           
        }

        public override int ChooseWeapon()      
        {
            Random randomNumber = new Random();
            int computerChoice = randomNumber.Next(0,5);
            return computerChoice;
        }
    }
}
