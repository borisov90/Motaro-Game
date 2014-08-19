namespace Game
{
    using System;
    using System.IO;
    class HelpMenu
    {
        public static void Initialize()
        {
            const string FILEPATH = @"..\..\ExternalFiles\help.txt";

            // If any problems with the text file occur
            // the application continues to run executing finally {}
            try
            {
                StreamReader fileReader = new StreamReader(FILEPATH);
                string line = "";

                using (fileReader)
                {
                    Console.WriteLine(fileReader.ReadToEnd());
                }
            }
            catch (IOException IOError)
            {
                Console.WriteLine(IOError.Message);
            }
            catch (OutOfMemoryException memoryError)
            {
                Console.WriteLine(memoryError.Message);
            }
            catch (Exception another)
            {
                Console.WriteLine(another.Message);
            }
            finally
            {

                bool commandCorrect = false;
                while (!commandCorrect)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                    if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        StartMenu.Initialize();
                        commandCorrect = true;
                    }
                }
            }
        }
    }
}
