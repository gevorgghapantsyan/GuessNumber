using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    public enum GameMode
    {
        Human = 0,
        Machine = 1
    }

    internal class GuessGame
    {
        private readonly int MaxNum;
        private readonly int MaxTries;
        private readonly GameMode Mode;
        public GuessGame(int MaxNum = 100, int MaxTries = 5, GameMode Mode = GameMode.Human)
        {
            this.MaxNum = MaxNum;
            this.MaxTries = MaxTries;
            this.Mode = Mode;
        }
        private void MachineGuess()
        {
            Console.WriteLine("Make a number a i will try to guess");
            int[] arr = new int[MaxNum];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i + 1;
            }
            int start  = 0;
            int end = arr.Length - 1;
            int tries = 0;
            while(start < end && tries < MaxTries)
            {
                char answer;
                int curr = (start + end) / 2;
                Console.WriteLine($"Is it {arr[curr]}");
                Console.WriteLine("If your number is higher type h if lower type l");
                tries++;
                try
                {
                    answer = Convert.ToChar(Console.ReadLine());
                }
                catch (SystemException)
                {
                    Console.WriteLine("Your input must have at least 1 character");
                    continue;
                }
                if(answer == 'y')
                {
                    Console.WriteLine("I guessed it. Uraaaa!!!");
                    Console.WriteLine($"The number was {arr[curr]}");
                    break;
                }
                else if(answer == 'h')
                {
                    start = curr;
                }
                else if(answer == 'l')
                {
                    end = curr;
                }
                else
                {
                    Console.WriteLine("Invalid character");
                }
            }
            if(tries == MaxTries)
            {
                Console.WriteLine("I couldn't guess your number. I am a bad player");
                Console.WriteLine("You win");
            }
        }
        private void HumanGuess()
        {
            Random random = new Random();
            int num = random.Next(MaxNum);
            int tries = 0;
            Console.WriteLine("I make a number try to guess");
            while (tries < MaxTries)
            {
                int input = Convert.ToInt32(Console.ReadLine()); 
                if (num < input)
                {
                    Console.WriteLine("Your number is higher my friend");
                    tries++;
                }
                else if (num > input)
                {
                    Console.WriteLine("Your number is lower bro");
                    tries++;
                }
                else
                {
                    Console.WriteLine("It's correct madafakkaaaaaaa");
                    Console.WriteLine($"The number was {num}");
                    break;
                }
                
            }
            if(tries == MaxTries) 
            {
                Console.WriteLine("Is that hard for you beach (|)");
                Console.WriteLine($"The number was {num}");
            }
        }
        
        private void StartHelper(GameMode mode)
        {
            if(Mode == GameMode.Human)
            {
                HumanGuess();
            }
            else
            {
                MachineGuess();
            }
        }
        public void Start()
        {
            StartHelper(Mode);
        }
    }
}
