namespace DiceJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gameSumPlayer = 0;
            int gameSumConsole = 0;
            int currentPoints = 3;
            int timesPlayed = 0;
            int pointsBet = 0; 
            string userName = "";
            string userInput = "";

            Console.WriteLine("Welcomee to... [BlackJack!]");
            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();
            Console.WriteLine("Welcome " + userName + " Lets play a game..."); 
            Console.WriteLine("Try and get as close to 21 as possible... type [draw] to draw a card and [stay] to hold your current hand");
            

            
            while (userInput!="stop" && currentPoints>=1)//As long as the player doesnt write stop or runs out of points, the game will run
            {
                if (timesPlayed>0&&gameSumConsole==0)//if the player has played before and the game has reset, welcome them back
                {
                    Console.WriteLine("Welcome back " + userName + "... You currently have " + currentPoints + " points...I wish you luck >:)");
                }

                Random rand = new Random();//The dice :D
                int dice = rand.Next(1, 14);

                if (gameSumConsole <= 17) //The dealer, as long as the dealer has less than or has 17, keep drawing
                {
                    if (dice == 11 || dice == 12 || dice == 13)//if the dealer draws a knight, queen or king, its equivilent to 10
                    {
                        dice = 10;
                    }
                    gameSumConsole += dice;
                    continue;
                }

                if (userInput == "yes"||userInput=="")//if the player has agreed to keep playing or hasnt said anything yet, start the sequence
                {
                    Console.WriteLine("How much do you want to bet? You currently have: " + currentPoints);
                    pointsBet = int.Parse(Console.ReadLine());
                    Console.WriteLine("You may now draw... Good luck~");
                }
                if (gameSumPlayer>21)
                {
                    Console.WriteLine("You got fat, sad for u");
                }
                if (gameSumPlayer==21)
                {
                    Console.WriteLine("Blackjack!");
                }

                if (gameSumPlayer < 21)
                {
                    userInput = Console.ReadLine();
                }

                if (userInput == "draw" && gameSumPlayer < 21)
                {
                    
                    if (dice== 11 || dice == 12 || dice == 13)
                    {
                        if (dice == 11)
                        {
                            Console.WriteLine("You got a Knight");
                        }
                        else if (dice == 12)
                        {
                            Console.WriteLine("You got a Queen");
                        }
                        else
                        {
                            Console.WriteLine("You got a King");
                        }
                        
                        dice = 10;
                    }
                    else if (dice == 1)
                    {
                        Console.WriteLine("You got an Ace, do you want a 1 or a 11?");
                        dice = int.Parse(Console.ReadLine());
                        Console.WriteLine("You have chosen a " + dice);
                    }
                    else
                    {
                        Console.WriteLine("You got a " + dice);
                    }
                    gameSumPlayer += dice;
                    Console.WriteLine("Current Number: "+gameSumPlayer);
                    continue;
                }
                else if (userInput=="stay")
                {
                    Console.WriteLine("You have decided to hold at your current number " + gameSumPlayer);
                }
                
                if (gameSumPlayer > gameSumConsole && gameSumPlayer <= 21 && gameSumPlayer!=21)
                {
                    Console.WriteLine("You have won this round " + userName + ", Congrats!");
                    currentPoints+=pointsBet*2;
                }
                else if (gameSumPlayer == 21 && gameSumConsole!=21) 
                {
                    Console.WriteLine("You have won the biggest amount! Congrats, you're a winner!");
                    currentPoints+=(pointsBet*4);
                }
                else if(gameSumConsole==21 && gameSumPlayer!=21)
                {
                    Console.WriteLine("Aw... the house won,sorry");
                    currentPoints-=4*pointsBet;
                }
                else if (gameSumConsole > gameSumPlayer && gameSumConsole <= 21)
                {
                    Console.WriteLine("You have lost this round " + userName + ", Sucks to be you");
                    currentPoints=-2*pointsBet;
                }
                else if (gameSumConsole == gameSumPlayer && gameSumConsole <= 21)
                {
                    Console.WriteLine("Its a draw :<");
                }
                else 
                {
                    Console.WriteLine("Both of you lost, dang...");
                    currentPoints-=pointsBet;
                }
                timesPlayed++;

                if (currentPoints > 1)
                {
                    Console.WriteLine("Do you wish to keep playing?");
                    userInput = Console.ReadLine();
                }

                if (userInput=="yes"&&currentPoints>1)
                {
                    gameSumPlayer = 0;
                    gameSumConsole = 0;
                    continue;
                }
                else
                {
                    Console.WriteLine("You ran out of points...");
                    Console.WriteLine("Please come again~");
                    Console.WriteLine("We'll see you again " + userName + "...");
                    userInput = "stop";
                }
                
            }

        }
    }
}
