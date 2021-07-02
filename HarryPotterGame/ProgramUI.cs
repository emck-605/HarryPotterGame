using HarryPotterGame.PlayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterGame
{
    class ProgramUI
    {
        Player player = new Player();
        private bool isGameOver = false;
        private bool isEndOfGame = false;
        bool hasEncounteredTroll = true;
        bool hasEncounteredDementor = true;
        bool hasEncounteredFluffy = true;
        private bool isInSecondRoom = false;
        private bool isInThirdRoom = false;

        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunningMainMenu = true;
            bool isInFirstRoom = false;
            bool isRunningEndMenu = true;
            while (!isGameOver && !isEndOfGame)
            {
                if (isRunningMainMenu)
                {
                    Console.WriteLine(@"
 _____ _            _   _                        ______     _   _              _____                      
|_   _| |          | | | |                       | ___ \   | | | |            |  __ \                     
  | | | |__   ___  | |_| | __ _ _ __ _ __ _   _  | |_/ /__ | |_| |_ ___ _ __  | |  \/ __ _ _ __ ___   ___ 
  | | | '_ \ / _ \ |  _  |/ _` | '__| '__| | | | |  __/ _ \| __| __/ _ \ '__| | | __ / _` | '_ ` _ \ / _ \
  | | | | | |  __/ | | | | (_| | |  | |  | |_| | | | | (_) | |_| ||  __/ |    | |_\ \ (_| | | | | | |  __/
  \_/ |_| |_|\___| \_| |_/\__,_|_|  |_|   \__, | \_|  \___/ \__|\__\___|_|     \____/\__,_|_| |_| |_|\___|
                                           __/ |                                                          
                                          |___/                                                           ");

                    Console.Write("     You have returned to Hogwarts and must defeat 3 beasts and collect 3 stones to complete the game.\n" +
                        "                -----------------------------------------------------------------------\n" +
                        "                                              1. Start Game\n" +
                        "                                              2. Exit Game\n" +
                        "                -----------------------------------------------------------------------\n");

                    var userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            isInFirstRoom = true;
                            break;
                        case "2":
                            isGameOver = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Operation.");
                            break;
                    }
                }
                while (isInFirstRoom)
                {
                    while (hasEncounteredTroll)
                    {
                        EncounteredMonster("You have entered the castle and found a troll.",
                            "The troll hit you in the head!\n" +
                            "It has defeated you. Press Enter to move on.",
                            "You knocked the troll out with it's club by using the levitation spell! You have retreived the Blue Stone!",
                            AttackType.WingardiumLeviosa);
                        Console.ReadKey();
                        hasEncounteredTroll = false;
                        isInFirstRoom = false;
                        isInSecondRoom = true;
                    }
                }
                while (isInSecondRoom)
                {
                    while (hasEncounteredFluffy)
                    {
                        EncounteredMonster("Your next beast is the Three-Headed dog, Fluffy.",
                            "Fluffy bit your arm off! It has defeated you\n" +
                            "You have failed to collect all three stones.",
                            "You put Fluffy to sleep by casting a music spell! You have retreived the Red Stone!",
                            AttackType.MusicSpell);
                        Console.ReadKey();
                        hasEncounteredFluffy = false;
                        isInSecondRoom = false;
                        isInThirdRoom = true;
                    }
                }
                while (isInThirdRoom)
                {
                    while (hasEncounteredDementor)
                    {
                        EncounteredMonster("Oh no! A Dementor!",
                            "The Dementor consumed your soul!\n" +
                            "It has defeated you. Press Enter to move on.",
                            "You cast away the Dementor with the Expecto Patronum spell! You have retreived the Green Stone!",
                            AttackType.ExpectoPatronum);
                        Console.ReadKey();
                        hasEncounteredDementor = false;
                        isInThirdRoom = false;
                        isGameOver = true;
                    }
                }

                while (isGameOver)
                {
                    if (isRunningEndMenu)
                    {
                        Console.WriteLine(@"
 _____          _          __   _____                        _ 
|  ___|        | |        / _| |  __ \                      | |
| |__ _ __   __| |   ___ | |_  | |  \/ __ _ _ __ ___   ___  | |
|  __| '_ \ / _` |  / _ \|  _| | | __ / _` | '_ ` _ \ / _ \ | |
| |__| | | | (_| | | (_) | |   | |_\ \ (_| | | | | | |  __/ |_|
\____/_| |_|\__,_|  \___/|_|    \____/\__,_|_| |_| |_|\___| (_)
                                                               
                                                               ");

                        Console.Write("                                      You have completed the game!\n" +
                            "               -----------------------------------------------------------------------\n" +
                            "                                             1. Exit Game\n" +
                            "               -----------------------------------------------------------------------\n");

                        var userInput = Console.ReadLine();

                        switch (userInput)
                        {
                            case "1":
                                isEndOfGame = true;
                                isGameOver = false;
                                break;
                            default:
                                Console.WriteLine("Invalid Operation.");
                                break;
                        }
                    }
                }
            }
        }
        private void PlayerChoice(string msg)
        {
            Console.WriteLine(msg);
        }
        private void EncounteredMonster(string Title, string wrongChoice, string RightChoice, AttackType correctAttackType)
        {
            Console.Clear();
            Console.WriteLine(Title + " How will you defeat this beast:\n" +
                                    "1. Use Expecto Patronum\n" +
                                    "2. Use Wingardium Leviosa\n" +
                                    "3. Use Music Spell\n" +
                                    "4. Run away\n");

            var userInput = int.Parse(Console.ReadLine());
            player.Attack = (AttackType)userInput;

            switch (player.Attack)
            {
                case AttackType.ExpectoPatronum:
                    CheckPlayerAttacktype(correctAttackType, wrongChoice, RightChoice);
                    break;
                case AttackType.WingardiumLeviosa:
                    CheckPlayerAttacktype(correctAttackType, wrongChoice, RightChoice);
                    break;
                case AttackType.MusicSpell:
                    CheckPlayerAttacktype(correctAttackType, wrongChoice, RightChoice);
                    break;
                case AttackType.Run_Away:
                    Console.WriteLine("You ran away!");
                    break;
                default:
                    Console.WriteLine("Invalid Operation");
                    break;
            }

        }

        private void CheckPlayerAttacktype(AttackType correctAttackType, string wrongChoice, string rightChoice)
        {
            if (player.Attack != correctAttackType)
            {
                PlayerChoice(wrongChoice);
            }
            else
            {
                Console.WriteLine(rightChoice);
            }
        }
    }
}
