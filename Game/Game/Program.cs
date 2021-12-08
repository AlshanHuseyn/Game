using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Game
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Birinci yarismacini daxil edin");
            string playerOne = Console.ReadLine();
            Player player = new Player();
            player.Username = playerOne;

            Console.WriteLine("Ikinci yarismacini daxil edin");
            string playerTwo = Console.ReadLine();
            Player player2 = new Player();
            player2.Username = playerTwo;

            Console.WriteLine("{0} ilk ededi daxil etsin",player.Username);
            int number = Convert.ToInt32(Console.ReadLine());
            bool isWho = true;

            while (Convert.ToInt32(number) > 1)
            {
                string whoIs = isWho ? player2.Username : player.Username;
                Console.WriteLine(whoIs + " eded daxil edir : ");
                int num = Convert.ToInt32(Console.ReadLine());
                checkNumber(number,ref num);
                number = num;
                WhoIsNext(number, ref isWho, player, player2);
            }
            Console.WriteLine(Winner(player, player2));
        }

        public static void checkNumber(int mainNum, ref int number)
        {
            while (!(mainNum - 2 <= number && number < mainNum))
            {
                Console.WriteLine("Zehmet olmasa,{0} ve ya {1} daxil edin!", mainNum - 2, mainNum - 1);
                number = Convert.ToInt32(Console.ReadLine());
            }
        }

        public static void WhoIsNext(int num, ref bool isWho, Player player1, Player player2)
        {
            if (isWho)
            {
                player2.Number = num;
                isWho = false;
            }
            else
            {
                player1.Number = num;
                isWho = true;
            }
        }

        public static string Winner(Player player1,Player player2)
        {
            string winner = "";
            if (player1.Number > 0 && player1.Number == 1 && player1.Number != 0)
                winner = player1.Username;
            else if (player2.Number > 0 && player2.Number == 1 && player2.Number != 0)
                winner = player2.Username;
            return string.Format("{0} qalib geldi",winner);
        }
    }
}
