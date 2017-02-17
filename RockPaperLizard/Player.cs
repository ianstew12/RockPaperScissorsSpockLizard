using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperLizard
{
    public class Player
    {
        public string name;
        public int roundsWon;
        public int weaponChoice;
        
        public Player()
        {
            roundsWon = 0;
        }

        public virtual void ChooseWeapon(){}
    }
}
