using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperLizard
{
    public class Game                         
    {  
        public Player player1;
        public Player player2;
        private int toWin;
        public List<string> weapons; 
        
        public Game()
        {
            player1 = new Human();        
            weapons = new List<string>();      
            weapons.Add("paper");
            weapons.Add("Spock");
            weapons.Add("rock");
            weapons.Add("scissors");
            weapons.Add("lizard");
        }

        public void SetUpPlayers()
        {
            Console.WriteLine("Welcome to the game. I'll spare you the rules. Enter '1' to play against a computer or '2' to play against another person.");
            string playersLine = Console.ReadLine();
            int humanPlayers;
            bool playersEntry = int.TryParse(playersLine, out humanPlayers);        //sets humanPlayers to int.Parse(playersEntry) if it exists
            if (!playersEntry)
            {
                Console.WriteLine("Your entry of '{0}' was not '1' or '2'", playersLine);        //string interpolation (bad example - usually empty)
                SetUpPlayers();
                return;     
            }
            
                                  
            if (humanPlayers == 1) 
            {
                player2 = new Computer();
                Console.WriteLine("Okay, you'll play a computer. Please enter your name.");
                string PlayerName = Console.ReadLine();                      
                 player1.name = PlayerName;
                Console.WriteLine("Okay, " + player1.name + ". Let's get ready to play.");
            }
            else if (humanPlayers == 2)
            {
                player2 = new Human();
                Console.WriteLine("Okay, first enter the name of Player One.");
                string PlayerOneName = Console.ReadLine();
                player1.name = PlayerOneName;
                Console.WriteLine("Now enter the name of Player Two.");
                string PlayerTwoName = Console.ReadLine();                   
                player2.name = PlayerTwoName;
            }
            else { Console.WriteLine("That was not a valid entry. Try again.");             
                SetUpPlayers();
            }
        }
        public void AskBestOf()
        {
            Console.WriteLine("How many games do you want to play best out of? Must be an odd integer.");
            //I'll deal with this using try and catch, instead of the TryParse approach used in SetUpPlayers()
            //but TryParse is probably better ("avoids an exception for the fairly unexceptional case of user error"-stackoverflow)
            int bestOf;
            string gamesLine = Console.ReadLine();
            try
            {
                bestOf = int.Parse(gamesLine);
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter an odd integer");
                AskBestOf();
                return;
            }
            
            if (bestOf <= 0 || bestOf % 2 != 1)      
            {                                       
                Console.WriteLine("Must be an odd integer (3,5,7...)");
                AskBestOf();
            }
            else
            {
                toWin = (bestOf / 2);
            }
        }

         public void PlayRound()
        {
   
            player1.ChooseWeapon();                 
            player2.ChooseWeapon();
            
            Console.WriteLine(player1.name + " chose " + weapons[player1.weaponChoice] + " and " + player2.name + " chose " + weapons[player2.weaponChoice]);
            DecideRoundWinner();
            CheckScore();
        }
        
           public void CheckScore()
        {
            if (player1.roundsWon > toWin)
            {
                Console.WriteLine(player1.name.ToUpper() + " WINS THE GAME!");
                Console.ReadLine();
            }
            else if (player2.roundsWon > toWin)
            {
                Console.WriteLine(player2.name.ToUpper() + " WINS THE GAME!");
                Console.ReadLine();
            }
            else { PlayRound();
            }
    }
        public void DecideRoundWinner()
        {
            int separationsInWeapons = (5 + player1.weaponChoice - player2.weaponChoice) % 5;       //see footnote on algorithm
            if (separationsInWeapons == 1 || separationsInWeapons == 2)
            {
                player2.roundsWon += 1;
                Console.WriteLine(player2.name + " wins that round.\n");
            }
            else if (separationsInWeapons == 3 || separationsInWeapons == 4)
            {
                player1.roundsWon += 1;
                Console.WriteLine(player1.name + " wins that round. \n");
            }
            else
            {
                Console.WriteLine("That round was a tie. Try again.");
                PlayRound();
            }

        }
    }
}



/*          ALGORITHM FOOTNOTE
Andrew sent me the scalabale Java solution here:
https://stackoverflow.com/questions/9553058/scalable-solution-for-rock-paper-scissor
It made sense to me, but I was curious how you would get a new algorithm if you didn't already have the order of the weapons.
If you think about the list of weapons (possibly better stored as array since it won't be updated), and think about the index of each player's selection
as a and b, you have five possibilities for a,b as they relate to each other in the list. they can be the same, 1 apart, 2, apart, 3 apart or 4 apart.
We also know each option ties itself, beats two others, and loses to two others. In my mind, the most obvious way to try to organize the elements was in
such a way that each element beats the two elements immediately after it, then loses to the elements three and four indexes higher. Visually:
(object) - wins - wins - loses - loses  
with "wins" and "loses" describing the result of "object" against the element in those locations
It's easy to try setting this up. Start with any object in index zero, and you know indexes 1,2 must (in either order) be the 
items the object beats.  
You could also set it up where each opject beats the elements in indexes 1 and 3 down, losing to the elements 2 and 4 "down" (to the right):
object-W-L-W-L 
with a winning when d=1 or d=3, b wins when d=2 or d = 4 
if you use the order rock-lizard-sock-scissors-paper.
 */



