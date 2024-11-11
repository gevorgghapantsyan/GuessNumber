namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameMode mode;
            Console.WriteLine
               ("Hello this is game called Guess Number\n" +
                "Please select game mode\n" +
                "Guesses Human(Type 0)\tGuesses Machine(Type 1)");
            mode = (GameMode)Convert.ToInt32(Console.ReadLine());

            if (mode == GameMode.Human)
            {
                var gm = new GuessGame(Mode: mode);
                gm.Start();
            }
            else if (mode == GameMode.Machine)
            {
                var gm = new GuessGame(Mode: mode);
                gm.Start();
            }
            else
            {
                Console.WriteLine("Invalid value");
            }


        }
    }
}