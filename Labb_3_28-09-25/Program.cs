namespace Labb_3_28_09_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            int pyramidHeight = 10;
            int spaces = -1;
            int stars = -1;


            //height
            for (int i = 1; i < pyramidHeight + 1; i++)
            {
                Console.WriteLine();
                //Width Mellanslag
                for (int j = 0; j < (spaces = (pyramidHeight - i)); j++)
                {
                    Console.Write(" ");
                }
                //width stars
                for (int k = 0; k < (stars = (2 * i - 1)); k++)
                {
                    Console.Write("*");
                }
            }
        }
    }
}
