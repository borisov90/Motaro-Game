namespace Game
{
    using System;
    using System.IO;
    using System.Security;
    public class DrawItem
    {
        /* Gets the following parameters:
         * The number of the col where the cursor should be pointed
         * The number of the row where the cursor should be pointed
         */
        public static void Draw(int col, int row, string stringToWrite, ConsoleColor colorText = ConsoleColor.White)
        {
            //try
            //{
                Console.SetCursorPosition(col, row);
                Console.ForegroundColor = colorText;
                Console.Write(stringToWrite);
            //}
            //catch (ArgumentOutOfRangeException outOfRange)
            //{
            //    Console.Error.WriteLine(outOfRange.Message);
            //}
            //catch (SecurityException security)
            //{
            //    Console.Error.WriteLine(security.Message);
            //}
            //catch (IOException IO)
            //{
            //    Console.Error.WriteLine(IO.Message);
            //}
            //catch (Exception unknown)
            //{
            //    Console.Error.WriteLine(unknown.Message);
            //}
        }
        public static void Draw(int col, int row, char charToWrite, ConsoleColor colorText = ConsoleColor.White)
        {
            //try
            //{
                Console.SetCursorPosition(col, row);
                Console.ForegroundColor = colorText;
                Console.Write(charToWrite);
            //}
            //catch (ArgumentOutOfRangeException outOfRange)
            //{
            //    Console.Error.WriteLine(outOfRange.Message);
            //}
            //catch (SecurityException security)
            //{
            //    Console.Error.WriteLine(security.Message);
            //}
            //catch (IOException IO)
            //{
            //    Console.Error.WriteLine(IO.Message);
            //}
            //catch (Exception unknown)
            //{
            //    Console.Error.WriteLine(unknown.Message);
            //}
        }
    }
}
