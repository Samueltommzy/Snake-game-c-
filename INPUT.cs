using System;
using System.Collections;
using System.Windows.Forms;



namespace samSnake
{
    class INPUT
    {
        //load list of available keyboard buttons
        private static Hashtable KeyTable = new Hashtable();
        //checks to see if a button is pressed
        public static bool keyPressed(Keys key)
        {
            if (KeyTable[key] == null)
            {
                return false;
            }
            return (bool) KeyTable[key];
        }
        //detects if a button ic pressed
        public static void changeState(Keys key, bool state)
        {
            KeyTable[key] = state;
        }
    }
}
