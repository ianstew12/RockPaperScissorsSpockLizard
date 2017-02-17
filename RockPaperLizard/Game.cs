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
        private int bestOf;
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
            Console.WriteLine("Welcome to the game. I'll spare you the rules. Enter '1' to play against a computer or'2' to play against another person.");
            int HumanPlayers = int.Parse(Console.ReadLine());                               
            if (HumanPlayers == 1) 
            {
    
                player2 = new Computer();
                Console.WriteLine("Okay, you'll play a computer. Please enter your name.");
                string PlayerName = Console.ReadLine();                     //TODO check input 
                 player1.name = PlayerName;
                Console.WriteLine("Okay, " + player1.name + ". Let's get ready to play.");
            }
            else if (HumanPlayers == 2)
            {
                player2 = new Human();
                Console.WriteLine("Okay, first enter the name of Player One.");
                string PlayerOneName = Console.ReadLine();
                player1.name = PlayerOneName;
                Console.WriteLine("Now enter the name of Player Two.");
                string PlayerTwoName = Console.ReadLine();                   //TODO check user enters characters
                player2.name = PlayerTwoName;
            }
            else { Console.WriteLine("That was not a valid entry. Try again.");             //catch errors 
                SetUpPlayers();
            }
        }
        public void AskBestOf()
        {
            Console.WriteLine("How many games do you want to play best out of? Must be an odd integer.");
            bestOf = int.Parse(Console.ReadLine());
            if (bestOf <=0 || bestOf % 2 != 1)      //TODO check against enter with no value -- look at TryParse
            {                                       // TRY AND CATCH error handling 
                Console.WriteLine("Must be an odd integer (3,5,7...)");
                AskBestOf();
            }
            //use ToWin member variable instead? only do the division once
        }

         public void PlayRound()
        {
            //each player chooses weapon (find a,b)
            player1.ChooseWeapon();                 
            player2.ChooseWeapon();
            
            Console.WriteLine(player1.name + " chose " + weapons[player1.weaponChoice] + " and " + player2.name + " chose " + weapons[player2.weaponChoice]);
            DecideRoundWinner();
            CheckScore();
        }
        
           public void CheckScore()
        {
            if (player1.roundsWon > (bestOf/2))
            {
                Console.WriteLine(player1.name.ToUpper() + " WINS THE GAME!");
                Console.ReadLine();
            }
            else if (player2.roundsWon > (bestOf/2))
            {
                Console.WriteLine(player2.name.ToUpper() + " WINS THE GAME!");
                Console.ReadLine();
            }
            else { PlayRound();
            }
    }
        public void DecideRoundWinner()
        {
            int d = (5 + player1.weaponChoice - player2.weaponChoice) % 5;
            if (d == 1 || d == 2)
            {
                player2.roundsWon += 1;
                Console.WriteLine(player2.name + " wins that round.\n");
            }
            else if (d == 3 || d == 4)
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

    



