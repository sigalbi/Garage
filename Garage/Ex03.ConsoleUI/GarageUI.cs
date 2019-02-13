using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private enum ekeyBoard { One = 1, Two, Three, Four, Five, Six, Seven, Esc }; // Set menu keys
        private GarageLogics m_GarageLogic;

        public GarageUI()
        {
            m_GarageLogic = NewObj.NewGarageLogics();
        }

        public void InsertVehicle(string i_lincesNumber)  // this function insert a new vehicle to garage
        {
            if (!m_GarageLogic.CheckIfLincesExicetAndTryToUpdate(i_lincesNumber))  // If the vehicle already exists in the garage
            {
                Console.WriteLine("The Vehicle already exists and change to in process");
            }
            else  // If the vehicle does not exist in the garage
            {
                Console.WriteLine("The Vehicle is not exists");
                MakeANewVehicle(i_lincesNumber);  // call to function that create a new vehicle by lincesNumber
            }
        }

        public void MakeANewVehicle(string i_lincesNumber)  // this function create a new vehicle by lincesNumber
        {
            string inputFromUser;
            Owner_Details newOwner;
            List<string> Quastions;  // this list hold the quastios to be displayed to the user
            bool isNotCorrectInput = true;  // a boolean variable that checks whether the input from the user is correct
            newOwner = NewObj.NewOwnerDetails();
            Console.WriteLine("Please enter the type of Vichle for example <'electric car, gasolin motorcycle> and press 'Enter'");

            while (isNotCorrectInput)  // while the input isnt correct
                try
                {
                    inputFromUser = Console.ReadLine();// Receiving the type of vehicle from the user
                    newOwner.ownerVehicle = NewObj.NewVehicle(inputFromUser);  // create a new owner
                    Quastions = newOwner.QuestionsForOwner();
                    ShowOwnerQuastionsAndCheckAnswear(Quastions, newOwner); // Display the questions related to the vehicle owner to the user
                    newOwner.ownerVehicle.lincesNumber = i_lincesNumber; // updeate the linces number
                    Quastions = Vehicle.QuestionsForVehicle();
                    ShowVehicleQuastionsAndCheckAnswear(Quastions, newOwner); // Display the questions related to the vehicle to the user
                    Quastions = Wheel.QuestionsForWheel();
                    ShowWheelsQuastionsAndCheckAnswear(Quastions, newOwner); // Display the questions related to the wheels to the user
                    Quastions = newOwner.ownerVehicle.engine.QuestionsForEngine();
                    ShowEngineQuastionsAndCheckAnswear(Quastions, newOwner); // Display the questions related to the engine to the user
                    newOwner.ownerVehicle.updateTheFualPrecent();  // call to function that updeat the fual precent 
                    Quastions = newOwner.ownerVehicle.QuestionsForAllVehicles();
                    ShowQuastionsForAllVehicleAndCheckAnswear(Quastions, newOwner); // Display the questions related to the vehicle to the user
                    m_GarageLogic.AddOwnerToGarage(newOwner);
                    isNotCorrectInput = false;
                }
                catch (ArgumentException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
        }

        public void ShowOwnerQuastionsAndCheckAnswear(List<string> i_quastions, Owner_Details io_newOwner)  // this function display the owner questions and checks inputs
        {
            int numberOfQuestion = 1;  // count the number of question
            bool isNotCorrectInput = true; // a boolean variable that checks whether the input from the user is correct
            string inputFormUser;

            foreach (string question in i_quastions)  // For each question in the list of questions
            {
                while (isNotCorrectInput)  // while the input isnt correct
                {
                    try
                    {
                        isNotCorrectInput = true;
                        Console.WriteLine(question);  // display the question to user
                        inputFormUser = Console.ReadLine();
                        io_newOwner.CheckOwnerDetailsInput(inputFormUser, numberOfQuestion);  // send the input to a check function
                        io_newOwner.updateOwnerDetailsInput(inputFormUser, numberOfQuestion);  // Update user details
                        isNotCorrectInput = false;
                    }
                    catch (Exception wrrongLogicInput)
                    {
                        Console.WriteLine("Iligale input");
                        Console.WriteLine(wrrongLogicInput.Message);
                    }
                }
                numberOfQuestion++;
                isNotCorrectInput = true;
            }
        }

        public void ShowVehicleQuastionsAndCheckAnswear(List<string> i_quastions, Owner_Details io_newOwner) // this function display the Vehicle questions and checks inputs
        {
            int numberOfQuestion = 1;  // count the number of question
            bool isNotCorrectInput = true; // a boolean variable that checks whether the input from the user is correct
            string inputFormUser;

            foreach (string question in i_quastions) // For each question in the list of questions
            {
                while (isNotCorrectInput)  // while the input isnt correct
                {
                    try
                    {
                        isNotCorrectInput = true;
                        Console.WriteLine(question);  // display the question to user
                        inputFormUser = Console.ReadLine();
                        io_newOwner.ownerVehicle.CheckVehicleInput(inputFormUser, numberOfQuestion); // send the input to a check function
                        io_newOwner.ownerVehicle.UpdateVehicleInput(inputFormUser, numberOfQuestion);  // updeate the vehicle details
                        isNotCorrectInput = false;
                    }
                    catch (Exception wrrongLogicInput)
                    {
                        Console.WriteLine("Iligale input");
                        Console.WriteLine(wrrongLogicInput.Message);
                    }
                }
                numberOfQuestion++;
                isNotCorrectInput = true;
            }
        }

        public void ShowWheelsQuastionsAndCheckAnswear(List<string> i_quastions, Owner_Details io_newOwner)  // this function display the wheels questions and checks inputs
        {
            int numberOfQuestion = 1;  // count the number of question
            bool isNotCorrectInput = true;  // a boolean variable that checks whether the input from the user is correct
            string inputFormUser;

            foreach (string question in i_quastions) // For each question in the list of questions
            {
                while (isNotCorrectInput) // while the input isnt correct
                {
                    try
                    {
                        isNotCorrectInput = true;
                        Console.WriteLine(question); // display the question to user
                        inputFormUser = Console.ReadLine();
                        io_newOwner.ownerVehicle.UpdateWheels(inputFormUser, numberOfQuestion); // call to function that updeate the wheels details and return an Ex if the input worng
                        isNotCorrectInput = false;
                    }
                    catch (FormatException wrrongLogicInput)
                    {
                        Console.WriteLine("Iligale input");
                        Console.WriteLine(wrrongLogicInput.Message);
                    }
                    catch (ArgumentException wrrongLogicInput)
                    {
                        Console.WriteLine("Iligale input");
                        Console.WriteLine(wrrongLogicInput.Message);
                    }
                }
                numberOfQuestion++;
                isNotCorrectInput = true;
            }
        }

        public void ShowEngineQuastionsAndCheckAnswear(List<string> i_quastions, Owner_Details io_newOwner)  // this function display the Engine questions and checks inputs
        {
            int numberOfQuestion = 1; // count the number of question
            bool isNotCorrectInput = true;  // a boolean variable that checks whether the input from the user is correct
            string inputFormUser;

            foreach (string question in i_quastions) // For each question in the list of questions
            {
                while (isNotCorrectInput) // while the input isnt correct
                {
                    try
                    {
                        isNotCorrectInput = true;
                        Console.WriteLine(question); // display the question to user
                        inputFormUser = Console.ReadLine();
                        io_newOwner.ownerVehicle.engine.CheckInputAndUpdateForEngine(inputFormUser, numberOfQuestion);  // call to function that updeate the engine details and return an Ex if the input worng
                        isNotCorrectInput = false;
                    }
                    catch (FormatException wrrongLogicInput)
                    {
                        Console.WriteLine("Iligale input");
                        Console.WriteLine(wrrongLogicInput.Message);
                    }
                    catch (ArgumentException wrrongLogicInput)
                    {
                        Console.WriteLine("Iligale input");
                        Console.WriteLine(wrrongLogicInput.Message);
                    }
                }
                numberOfQuestion++;
                isNotCorrectInput = true;
            }
        }

        public void ShowQuastionsForAllVehicleAndCheckAnswear(List<string> i_quastions, Owner_Details io_newOwner) // this function display the All Vehicle questions and checks inputs
        {
            int numberOfQuestion = 1; // count the number of question
            bool isNotCorrectInput = true; // a boolean variable that checks whether the input from the user is correct
            string inputFormUser;

            foreach (string question in i_quastions) // For each question in the list of questions
            {
                while (isNotCorrectInput) // while the input isnt correct
                {
                    try
                    {
                        isNotCorrectInput = true;
                        Console.WriteLine(question); // display the question to user
                        inputFormUser = Console.ReadLine();
                        io_newOwner.ownerVehicle.CheckInputAndUpdateForAllVehicles(inputFormUser, numberOfQuestion); // send the input to a check function
                        isNotCorrectInput = false;
                    }
                    catch (FormatException wrrongLogicInput)
                    {
                        Console.WriteLine("Iligale input");
                        Console.WriteLine(wrrongLogicInput.Message);
                    }
                    catch (ArgumentException wrrongLogicInput)
                    {
                        Console.WriteLine("Iligale input");
                        Console.WriteLine(wrrongLogicInput.Message);
                    }
                }
                numberOfQuestion++;
                isNotCorrectInput = true;
            }
        }

        public void MainMenu()  // this function displays the main menu
        {
            string inputFromUser;
            bool notFinishProg = true;
            int inputFromUserInInt; // a Boolean variable that tells if the program is finished

            while (notFinishProg)  // while the program is not finished
            {
                Console.Clear();
                Console.Write(@"
****        Hello and welcome to David and Sigal's garage  :)      ****

To insert a vehicle into the garage, please press < 1 >

To view a list of vehicles license numbers in the garage, please press < 2 >

To change the condition of a vehicle in the garage, please press < 3 >

To inflate a vehicle air tires to the maximum, please press < 4 >

To fuel a vehicle that powered by fuel, please press < 5 >

To recharge electric vehicle, please press < 6 >

To view the full data of a vehicle by license number, please press < 7 >

To exit the program, please press < 8 >

");
                inputFromUser = Console.ReadLine();
                inputFromUserInInt = checkMenuInput(inputFromUser);  // call to function that cheeck user input
                if (inputFromUserInInt == (int)ekeyBoard.Esc)  // if the user want to exit
                {
                    notFinishProg = false;
                }
                SentToFunctionSwitch(inputFromUserInInt);  // call to function that starts what the user has selected
            }
        }

        public int checkMenuInput(string i_inputFromUser)  // this function cheeck user input at the main menu and return the input in int
        {
            int inputFromUser = 0;
            bool notCorrectInput = true; // a Boolean variable that tells if the user input is correct
            bool successParse;  // a Boolean variable that tells if the parss was successful

            while (notCorrectInput) // while the user input isnt correct
            {
                successParse = int.TryParse(i_inputFromUser, out inputFromUser);  // try to parss the input to int
                if (successParse)  // if the parss success
                {
                    if (inputFromUser < 1 || inputFromUser > 8)  // check if the user input isnt in range
                    {
                        Console.WriteLine("You have to choose a number bettwen 1 - 8");
                        i_inputFromUser = Console.ReadLine();
                    }
                    else
                    {
                        notCorrectInput = false;
                    }
                }
                else  // if the user input isnt a number
                {
                    Console.WriteLine("You have to choose a number bettwen 1 - 8");
                    i_inputFromUser = Console.ReadLine();
                }
            }
            return inputFromUser;
        }

        public void SentToFunctionSwitch(int i_inputFromUser)  // this function starts what the user has selected in the main menu
        {
            switch (i_inputFromUser)
            {
                case (int)ekeyBoard.One:  // The user chose option number 1
                    {
                        InsertVehicleToGarage();  // call to function that insert a new vehicle to garage
                        break;
                    }
                case (int)ekeyBoard.Two: // The user chose option number 2
                    {
                        ShowListOfVehicles();  // call to function that display the vichels list
                        break;
                    }
                case (int)ekeyBoard.Three: // The user chose option number 3
                    {
                        ChangeVehicleStatus();  // call to function that change vehicle status
                        break;
                    }
                case (int)ekeyBoard.Four: // The user chose option number 4
                    {
                        InflateVehicleAirTiresToTheMaximum();  // call to function that inflate vehicle air tires to the maximum
                        break;
                    }
                case (int)ekeyBoard.Five: // The user chose option number 5
                    {
                        FuelVehicleThatPoweredByFuel(); // call to function that fuel a vehicle that powered by fuel
                        break;
                    }
                case (int)ekeyBoard.Six: // The user chose option number 
                    {
                        RechargeElectricVehicle(); // call to function that recharge an electric vehicle
                        break;
                    }
                case (int)ekeyBoard.Seven: // The user chose option number 7
                    {
                        ShowFullDataOfVehicle();  // call to function that show the full data of vehicle
                        break;
                    }
                case (int)ekeyBoard.Esc: // The user chose option number 8
                    {
                        Console.Clear();
                        Console.WriteLine("GoodBye...");
                        break;
                    }
            }
        }

        public void InsertVehicleToGarage()  // this function insert a new vehicle to garage
        {
            string inputLicenseNumberFromUser;
            bool isNotCorrectInpt = true; // a Boolean variable that says whether the input from the user is correct

            Console.Clear();
            while (isNotCorrectInpt) // while the input from the user isnt correct
            {
                try
                {
                    Console.WriteLine("Please inseart a license number or 'Q' to go back to menu and press 'Enter'");
                    inputLicenseNumberFromUser = Console.ReadLine();
                    if (inputLicenseNumberFromUser.CompareTo("Q") != 0) // if the user dont want to exit
                    { 
                        InsertVehicle(inputLicenseNumberFromUser);  // call to function that insert a Vehicle by license number
                    }
                    isNotCorrectInpt = false;
                }
                catch (ArgumentException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }

        public void ShowListOfVehicles() // this function display the vichels list 
        {
            string inputFromUser;
            bool inputNotCorrect = true; // a Boolean variable that says whether the input from the user is correct
            List<string> listOfLicense =null;

            Console.Clear();
            while (inputNotCorrect) // while the input from the user isnt correct
            {
                try
                {
                    Console.WriteLine("Please select the sort type to display vehicle license numbers <NONE,INPROCESS,FIXED,PAIDUP> or 'Q' to go back to menu");
                    inputFromUser = Console.ReadLine();
                    if (inputFromUser.CompareTo("Q") != 0) // if the user dont want to exit
                    {
                        listOfLicense = m_GarageLogic.ShowListOfVehicles(inputFromUser);  // call to function that shows the list of vehicles according to the filter the user has selected
                    }
                    if(listOfLicense != null)  // if the list isnt empty
                    {
                        foreach(string license in listOfLicense)
                        {
                            Console.WriteLine(license); // Writing the vehicle license
                        }
                    }
                    Console.WriteLine("Press 'enter' to continue");
                    Console.ReadLine();
                    inputNotCorrect = false;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }

        public void ChangeVehicleStatus() // this function change vehicle status 
        {
            string inputLicenseFromUser;
            string inputStatusFromUser;
            bool isntCurrectInput = true; // a Boolean variable that says whether the input from the user is correct

            Console.Clear();
            while (isntCurrectInput) // while the input from the user isnt correct
            {
                try
                {
                    Console.WriteLine("Please inseart a license number or press 'Q' to return to the main manu");
                    inputLicenseFromUser = Console.ReadLine();
                    if (inputLicenseFromUser.CompareTo("Q") != 0) // if the user dont want to exit
                    {
                        Console.WriteLine("Please inseart the vehicle status < INPROCESS / FIXED / PAIDUP > and press 'Enter'");
                        inputStatusFromUser = Console.ReadLine();
                        m_GarageLogic.ChangeVehicleStatus(inputLicenseFromUser,inputStatusFromUser);  // call to function changes the vehicle status by license number and new status from the user
                        Console.WriteLine("succssed to change status of Vehicle");
                        Console.WriteLine("Press 'enter' to continue");
                        Console.ReadLine();
                    }
                    isntCurrectInput = false;
                }
                catch (ArgumentException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }
        
        public void InflateVehicleAirTiresToTheMaximum() // this function inflate vehicle air tires to the maximum 
        {
            string inputFromUser;
            bool isntCurrectInput = true; // a Boolean variable that says whether the input from the user is correct

            Console.Clear();
            while (isntCurrectInput) // while the input from the user isnt correct
            {
                try
                {
                    Console.WriteLine("Please inseart a license number or press 'Q' to return to the main manu");
                    inputFromUser = Console.ReadLine();
                    if (inputFromUser.CompareTo("Q") != 0) // if the user dont want to exit
                    {
                        m_GarageLogic.InflateVehicleAirTiresToTheMaximum(inputFromUser);  // call to function that inflating tires to the maximum by number of vehicles
                        Console.WriteLine("succssed to inflate vehicle air tires to max");
                        Console.WriteLine("Press 'enter' to continue");
                        Console.ReadLine();
                    }
                    isntCurrectInput = false;
                }
                catch (ArgumentException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }

        public void FuelVehicleThatPoweredByFuel() // this function fuel a vehicle that powered by fuel
        {
            bool isntCurrectInput = true;  // a Boolean variable that says whether the input from the user is correct
            string inputLicenseFromUser;
            string fualTypeFromUser;
            string quantityToFillFromUser;

            Console.Clear();
            while (isntCurrectInput) // while the input from the user isnt correct
            {
                try
                {
                    Console.WriteLine("Please inseart a license number or press 'Q' to return to the main manu");
                    inputLicenseFromUser = Console.ReadLine();
                    if (inputLicenseFromUser.CompareTo("Q") != 0) // if the user dont want to exit
                    {
                        Console.WriteLine("Please inseart a fual type { SOLER, OCTAN95, OCTAN96, OCTAN98 } and press 'Enter'");
                        fualTypeFromUser = Console.ReadLine();
                        Console.WriteLine("Please enter a quantity to fill in and press 'Enter'");
                        quantityToFillFromUser = Console.ReadLine();
                        m_GarageLogic.FuelVehicleThatPoweredByFuel(inputLicenseFromUser, fualTypeFromUser, quantityToFillFromUser);  // call to function that fual the vehicle and return Ex if inputs worngs
                        Console.WriteLine("fuel was successeful ");
                        Console.WriteLine("Press 'enter' to continue");
                        Console.ReadLine();
                        isntCurrectInput = false;
                    }
                    isntCurrectInput = false;
                }
                catch (ValueOutOfRangeException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
                catch (ArgumentException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }

        public void RechargeElectricVehicle() // this function recharge an electric vehicle
        {
            bool isntCurrectInput = true; // a Boolean variable that says whether the input from the user is correct
            string inputLicenseFromUser;
            string quantityToFillFromUser;

            Console.Clear();
            while (isntCurrectInput) // while the input from the user isnt correct
            {
                try
                {
                    Console.WriteLine("Please inseart a license number or press 'Q' to return to the main manu");
                    inputLicenseFromUser = Console.ReadLine();
                    if (inputLicenseFromUser.CompareTo("Q") != 0)  // if the user dont want to exit
                    {
                        Console.WriteLine("Please enter a quantity to fill in and press 'Enter'");
                        quantityToFillFromUser = Console.ReadLine();
                        m_GarageLogic.RechargeElectricVehicle(inputLicenseFromUser, quantityToFillFromUser); // call to function that charge the vehicle and return Ex if inputs worngs
                        Console.WriteLine("fuel was successeful ");
                        Console.WriteLine("Press 'enter' to continue");
                        Console.ReadLine();
                    }
                    isntCurrectInput = false;
                }
                catch (ValueOutOfRangeException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
                catch (ArgumentException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }

        public void ShowFullDataOfVehicle() // this function show the full data of vehicle
        {
            List<string> AllDetailsToPrint = null; 
            bool isntCurrectInput = true; // a Boolean variable that says whether the input from the user is correct
            string inputLicenseFromUser;

            Console.Clear();
            while (isntCurrectInput) // while the input from the user isnt correct
            {
                try
                {
                    Console.WriteLine("Please inseart a license number or press 'Q' to return to the main manu");
                    inputLicenseFromUser = Console.ReadLine();
                    if (inputLicenseFromUser.CompareTo("Q") != 0)  // if the user dont want to exit
                    {
                        AllDetailsToPrint = m_GarageLogic.ShowFullDataOfVehicle(inputLicenseFromUser);  // call to function that return the list of data
                    }
                    if (AllDetailsToPrint != null) // if the list isnt empty
                    {
                        foreach (string detaile in AllDetailsToPrint)  // for each data in the list
                        {
                            Console.WriteLine(detaile);  // output the data
                        }
                    }
                    isntCurrectInput = false;
                    Console.WriteLine("Press 'Enter' to continue");
                    Console.ReadLine();
                }
                catch (ArgumentException Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }
    }
}
