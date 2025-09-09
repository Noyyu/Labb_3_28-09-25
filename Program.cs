using System.Globalization;

namespace Labb_3_28_09_25
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            bool exit = false;

            while (exit == false)
            {
                int     pyramidHeight = -1;
                char    userBlock;
                bool    filled;
                bool    upsideDown;
                bool    randig;

                Console.WriteLine("Här bygger vi pyramider! Du ska vara med!");
                Console.WriteLine("Vi bygger med block, hur många block hög vill du att din pyramid ska vara?");

                //----------------
                // Pyramidens höjd
                //----------------
                while (pyramidHeight == -1)
                {
                    if (int.TryParse(Console.ReadLine(), out pyramidHeight))
                    {
                        Console.Clear();
                        Console.WriteLine("Coolt! Då gör vi din pyramid " + pyramidHeight + " block hög!");
                    }
                    else
                    {
                        Console.WriteLine("försök sakriva ett nymmer");
                        pyramidHeight = -1;
                    }
                }

                //----------------------------------------------------------
                // Typ av tecken som skall användas flör att bygga pyramiden
                //----------------------------------------------------------

                Console.WriteLine("Vilket block vill du bygga din pyramid av?");
                Console.ForegroundColor = ConsoleColor.DarkGray; // Ändrar lite färger för att "simulera" att linen under inte är med i konversationen
                Console.WriteLine("(Mata in ett tecken)");
                Console.ForegroundColor = ConsoleColor.White;
                userBlock = Console.ReadKey().KeyChar;

                Console.Clear();
                Console.WriteLine("Okej! Så du valde " + userBlock + " blocket, Inte blocket jag hade valt men.. Detta är inte min pyramid! :D");


                //-----------------------------
                // Skall pyramiden vara ifylld?
                //-----------------------------
                Console.WriteLine("Vill du ha din pyramid ifylld eller inte?");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Ja: 1 Nej: 2");
                Console.ForegroundColor = ConsoleColor.White;

                if (filled = YesOrNo())
                {
                    Console.Clear();
                    Console.WriteLine("Då fyller vi den!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Då lämnar vi den tom!");
                }


                //---------------------------------
                // Ska vi generera den upp och ner?
                //---------------------------------
                Console.WriteLine("Till sist, vore det inte roligt om vi balanserade dun pyramid på toppen? :D");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Ja: 1 Nej: 2");
                Console.ForegroundColor = ConsoleColor.White;

                if (upsideDown = YesOrNo())
                {
                    Console.Clear();
                    Console.WriteLine("Jag visste att jag tyckte om dig!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Tråkmons..");
                }

                //_--------------------------------------
                // Vill du att pyramiden ska vara randig?
                //_______________________________________
                Console.WriteLine("Bonus val! Vill du att pyramiden ska vara randig?");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Ja: 1 Nej: 2");
                Console.ForegroundColor = ConsoleColor.White;

                if (randig = YesOrNo())
                {
                    Console.Clear();
                    Console.WriteLine("Huhu, randig it is.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Har du något emot randigt?");
                }

                //-----------------------
                // Nu bygger vi pyramiden
                //-----------------------
                Console.WriteLine();
                Console.WriteLine("Men då så, då bygger vi din pyramid!");

                BuildPyramid(pyramidHeight, filled, upsideDown, randig, userBlock);


                //--------------------------------------------------------------------------
                // Slutmeny ger användaren möjlighet att bygga en till pyramid eller avsluta
                //--------------------------------------------------------------------------
                Console.WriteLine("Det va kul! Va fin den blev. Vill du bygga en till? :D");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Ja: 1 Nej: 2");
                Console.ForegroundColor = ConsoleColor.White;

                if (YesOrNo() == true)
                {
                    Console.Clear();
                    Console.WriteLine("Kul! Då gör vi en till :D");
                    exit = false;
                }
                else
                {
                    Console.WriteLine("Okej då.. :(");
                    exit = true;
                }
            }
        }

        //Methods

        //---------------------------
        // Hanterar Ja eller Nej svar
        //---------------------------
        static bool YesOrNo()
        {
            int userInput = -1; //Skulle jag få högre betyg om jag började använda typ "byte" i stället för "int"? 

            while (userInput == -1)
            {
                if (int.TryParse(Console.ReadLine(), out userInput) && userInput == 1)
                {
                    return true;
                }
                else if (userInput == 2)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Skriv 1 eller 2");
                    userInput = -1;
                }
            }
            return false; //Will not be used
        }


        //-----------------------------------------------
        // Bygger pyramiden baserat på inmatade variabler
        //-----------------------------------------------
        static void BuildPyramid(int pyramidHeight, bool filled, bool upsideDown, bool randig, char buildingBlock)
        {
            int buildingBlocksInRow;
            int spacesInRow;
            Console.WriteLine();

            //---------------
            // IFYLLD PYRAMID
            //---------------
            if (filled == true)
            {
                //------------------------------
                // Ifyll upp-och-nervänd pyramid
                //------------------------------
                if (upsideDown == true)
                {
                    for (int i = pyramidHeight; i > 0; i--) // Pyramidens höjd
                    {
                        Console.WriteLine();
                       
                        for (int j = 0; j < (spacesInRow = (pyramidHeight - i)); j++) // Bredd melllanslag 
                        {
                            Console.Write(" ");
                        }
                        
                        for (int k = 0; k < (buildingBlocksInRow = (2 * i - 1)); k++) // Bredd block
                        {
                            if (randig == true && i % 2 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write(buildingBlock);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }

                //------------------------
                // Ifylld rättvänd pyramid
                //------------------------
                else
                {
                    for (int i = 1; i < pyramidHeight + 1; i++) // Pyramidens höjd
                    {
                        Console.WriteLine();

                        for (int j = 0; j < (spacesInRow = (pyramidHeight - i)); j++) // Bredd Mellanslag
                        {
                            Console.Write(" ");
                        }

                        for (int k = 0; k < (buildingBlocksInRow = (2 * i - 1)); k++) // Bredd Block
                        {
                            if (randig == true && i % 2 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write(buildingBlock);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }


            // -----------
            // TOM PYRAMID
            // -----------
            else
            {
                //----------------------------
                // Tom upp-och-nervänd pyramid
                //----------------------------
                if (upsideDown == true)
                {
                    for (int i = pyramidHeight; i > 0; i--) // Pyramidens höjd
                    {
                        Console.WriteLine();

                        for (int j = 0; j < (spacesInRow = (pyramidHeight - i)); j++) // Bredd Mellanslag
                        {
                            Console.Write(" ");
                        }

                        for (int k = 0; k < (buildingBlocksInRow = (2 * i - 1)); k++) // Bredd Block och mellanslag
                        {
                            if (k == 0 || k == (buildingBlocksInRow - 1) || i == pyramidHeight)
                            {
                                if (randig == true && i % 2 == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                                Console.Write(buildingBlock);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }

                }

                //---------------------
                // Tom rättvänd pyramid
                //---------------------
                else
                {
                    for (int i = 1; i < pyramidHeight + 1; i++) //Pyramidens Höjd
                    {
                        Console.WriteLine();

                        for (int j = 0; j < (spacesInRow = (pyramidHeight - i)); j++) // Bredd Mellanslag
                        {
                            Console.Write(" ");
                        }

                        for (int k = 0; k < (buildingBlocksInRow = (2 * i - 1)); k++) // Bredd Block och mellanslag
                        {
                            if (k == 0 || k == (buildingBlocksInRow - 1) || i == pyramidHeight)
                            {
                                if (randig == true && i % 2 == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                }
                                Console.Write(buildingBlock);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
