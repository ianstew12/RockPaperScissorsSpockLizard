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
        
        public Player()
        {
            roundsWon = 0;
        }

        public virtual int ChooseWeapon()   
        {
            return 3;                     // TODO.           will never actually be returned 
        }
    }
}
