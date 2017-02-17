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

        public override void ChooseWeapon()      
        {
            Random randomNumber = new Random();
            int computerChoice = randomNumber.Next(0,5);
            weaponChoice= computerChoice;
        }
    }
}
