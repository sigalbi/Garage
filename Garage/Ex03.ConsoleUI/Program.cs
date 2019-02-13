/* B17 Ex03
 * Sigal Bindman I.D 305280968
 * David Tsap I.D 307894857
 * This program is a small garage management system.
 */

using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageUI garage = new GarageUI();

            garage.MainMenu(); // Activate the garage program
        }
    }
}
