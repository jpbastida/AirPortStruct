﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportStruct
{
    struct AirportBoard
    {
        public DateTime? DateTime;
        public string FlightNumber;
        public string CityPort;
        public string Airline;
        public string Terminal;
        public string FlightStatus;
        public string Gate;
    }

    class Program
    {
        static AirportBoard[] Arrivals = new AirportBoard[5];
        static AirportBoard[] Departures = new AirportBoard[5];

        static void Main(string[] args)
        {
            Console.WindowHeight = 42;
            Console.WindowWidth = 170;
            Console.CursorVisible = false;
            Console.CursorVisible = true;

            PopulateStructuresDeparture();
            PopulateStructuresArrivals();
            BuildScreen();

            int optionMenu = 0;

            while (true)
            {
                Console.CursorTop = 40;
                Console.CursorLeft = 145;
                bool parseSuccessful = int.TryParse(Console.ReadLine(), out optionMenu);
                if (parseSuccessful)
                {
                    if (optionMenu > 0 && optionMenu < 9)
                    {
                        MainMenu(optionMenu);
                    }
                    else
                    {
                        Console.Clear();
                        BuildScreen();
                    }
                }
                else
                {
                    BuildScreen();
                }
            }
        }

        static void PopulateStructuresDeparture()
        {
            Departures[0].DateTime = DateTime.Parse("8:30", System.Globalization.CultureInfo.InvariantCulture);
            Departures[0].FlightNumber = "PS713";
            Departures[0].CityPort = "Istanbul";
            Departures[0].Airline = "UAL";
            Departures[0].Terminal = "D";
            Departures[0].FlightStatus = "departed at 8:35 AM";
            Departures[0].Gate = "G3";

            Departures[1].DateTime = DateTime.Parse("10:10", System.Globalization.CultureInfo.InvariantCulture);
            Departures[1].FlightNumber = "TK456";
            Departures[1].CityPort = "Paris";
            Departures[1].Airline = "Tukish Airways";
            Departures[1].Terminal = "F";
            Departures[1].FlightStatus = "canceled";
            Departures[1].Gate = "A7";

            Departures[2].DateTime = DateTime.Parse("10:10", System.Globalization.CultureInfo.InvariantCulture);
            Departures[2].FlightNumber = "TP8234";
            Departures[2].CityPort = "Prague";
            Departures[2].Airline = "TAP Portugal";
            Departures[2].Terminal = "B";
            Departures[2].FlightStatus = "Gate closed";
            Departures[2].Gate = "D11";

            Departures[3].DateTime = DateTime.Parse("11:25", System.Globalization.CultureInfo.InvariantCulture);
            Departures[3].FlightNumber = "AF3368";
            Departures[3].CityPort = "Paris";
            Departures[3].Airline = "Air France";
            Departures[3].Terminal = "D";
            Departures[3].FlightStatus = "Boarding";
            Departures[3].Gate = "G7";

            Departures[4].DateTime = DateTime.Parse("13:35", System.Globalization.CultureInfo.InvariantCulture);
            Departures[4].FlightNumber = "LH2545";
            Departures[4].CityPort = "Mexico";
            Departures[4].Airline = "Lufthansa";
            Departures[4].Terminal = "B";
            Departures[4].FlightStatus = "Check-in";
            Departures[4].Gate = "G13";
        }

        static void PopulateStructuresArrivals()
        {
            Arrivals[0].DateTime = DateTime.Parse("9:30", System.Globalization.CultureInfo.InvariantCulture);
            Arrivals[0].FlightNumber = "G9260";
            Arrivals[0].CityPort = "Munich";
            Arrivals[0].Airline = "Air Arabia";
            Arrivals[0].Terminal = "D";
            Arrivals[0].FlightStatus = "Arrived";
            Arrivals[0].Gate = "G5";

            Arrivals[1].DateTime = DateTime.Parse("10:15", System.Globalization.CultureInfo.InvariantCulture);
            Arrivals[1].FlightNumber = "DL8518";
            Arrivals[1].CityPort = "Paris";
            Arrivals[1].Airline = "Delta Airlines";
            Arrivals[1].Terminal = "A";
            Arrivals[1].FlightStatus = "Unknown";
            Arrivals[1].Gate = "A11";

            Arrivals[2].DateTime = DateTime.Parse("11:30", System.Globalization.CultureInfo.InvariantCulture);
            Arrivals[2].FlightNumber = "LH2544";
            Arrivals[2].CityPort = "Munich";
            Arrivals[2].Airline = "Lufthansa";
            Arrivals[2].Terminal = "C";
            Arrivals[2].FlightStatus = "Delayed";
            Arrivals[2].Gate = "B3";

            Arrivals[3].DateTime = DateTime.Parse("11:30", System.Globalization.CultureInfo.InvariantCulture);
            Arrivals[3].FlightNumber = "KL3096";
            Arrivals[3].CityPort = "Amsterdam";
            Arrivals[3].Airline = "KLM";
            Arrivals[3].Terminal = "A";
            Arrivals[3].FlightStatus = "on flight";
            Arrivals[3].Gate = "D15";

            Arrivals[4].DateTime = DateTime.Parse("14:00", System.Globalization.CultureInfo.InvariantCulture);
            Arrivals[4].FlightNumber = "IB7982";
            Arrivals[4].CityPort = "Barcelona";
            Arrivals[4].Airline = "Iberia";
            Arrivals[4].Terminal = "D";
            Arrivals[4].FlightStatus = "expected at";
            Arrivals[4].Gate = "G10";
        }

        private static void BuildScreen()
        {
            string[] titles = { "AEROPORT", "DEPARTURES", "ARRIVALS" };
            string[] headTags = { "TIME", "FLIGHT", "CITY/PORT", "AIRLINE", "TERMINAL", "STATUS", "GATE" };
            int[] positions = { 15, 48, 65, 82, 100, 125, 150 };
            int[] dataPositions = { 15, 48, 65, 82, 103, 120, 151 };

            Console.Clear();

            for (int i = 0; i < titles.Length - 1; i++)
            {
                Console.CursorLeft = (Console.WindowWidth - titles[i].Length) / 2;
                Console.WriteLine(titles[i]);
                MakeLine();
            }

            MakeLine(20);
            Console.CursorLeft = (Console.WindowWidth - titles[2].Length) / 2;
            Console.WriteLine(titles[2]);
            MakeLine();
            MakeLine(38);

            Console.CursorTop = 40;
            Console.Write("MENU - 1-Edit  2-Erase   3-Search by Flight  4-Search by time  5-Search Departure  6-Search Arrival  7-Get near flights 8-Help CHOOSE AN OPTION: ");

            Console.SetCursorPosition(0, 5);
            for (int i = 0; i < headTags.Length; i++)
            {
                Console.CursorLeft = positions[i];
                Console.Write(headTags[i]);
            }

            Console.SetCursorPosition(0, 24);
            for (int i = 0; i < headTags.Length; i++)
            {
                Console.CursorLeft = positions[i];
                Console.Write(headTags[i]);
            }

            Console.SetCursorPosition(0, 7);
            for (int i = 0; i < 5; i++)
            {
                if (Departures[i].DateTime != null)
                {
                    Console.CursorLeft = 15;
                    DateTime date = (DateTime)Departures[i].DateTime;
                    Console.Write(date.ToString("HH:mm"));
                    Console.CursorLeft = 48;
                    Console.Write(Departures[i].FlightNumber);
                    Console.CursorLeft = 65;
                    Console.Write(Departures[i].CityPort);
                    Console.CursorLeft = 82;
                    Console.Write(Departures[i].Airline);
                    Console.CursorLeft = 103;
                    Console.Write(Departures[i].Terminal);
                    Console.CursorLeft = 120;
                    Console.Write(Departures[i].FlightStatus);
                    Console.CursorLeft = 151;
                    Console.Write(Departures[i].Gate);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.SetCursorPosition(0, 26);
            for (int i = 0; i < 5; i++)
            {
                if (Arrivals[i].DateTime != null)
                {
                    Console.CursorLeft = 15;
                    DateTime date = (DateTime)Arrivals[i].DateTime;
                    Console.Write(date.ToString("HH:mm"));
                    Console.CursorLeft = 48;
                    Console.Write(Arrivals[i].FlightNumber);
                    Console.CursorLeft = 65;
                    Console.Write(Arrivals[i].CityPort);
                    Console.CursorLeft = 82;
                    Console.Write(Arrivals[i].Airline);
                    Console.CursorLeft = 103;
                    Console.Write(Arrivals[i].Terminal);
                    Console.CursorLeft = 120;
                    Console.Write(Arrivals[i].FlightStatus);
                    Console.CursorLeft = 151;
                    Console.Write(Arrivals[i].Gate);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void MainMenu(int option)
        {
            switch (option)
            {
                case 1:
                    int editOption = 0;

                    while (editOption <= 0 || editOption >= 3)
                    {
                        Console.CursorTop = 40;
                        Console.Write("                                                                                                                                                  ");
                        string stringMessage1 = "Edit - 1-Departures, 2-Arrivals? ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(stringMessage1);
                        Console.CursorLeft = stringMessage1.Length;
                        editOption = int.Parse(Console.ReadLine());

                        if (editOption > 0 && editOption < 3)
                        {
                            EditMenu(editOption);
                        }
                    }
                    break;

                // Delete menu
                #region
                case 2:
                    bool flightFound = false;

                    while (!flightFound)
                    {
                        Console.CursorTop = 40;
                        Console.Write("                                                                                                                                                      ");
                        string stringMessageErase = "Erase in - 1-Departures, 2-Arrivals? ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(stringMessageErase);
                        Console.CursorLeft = stringMessageErase.Length;
                        int editOptionErase = int.Parse(Console.ReadLine());

                        if (editOptionErase > 0 && editOptionErase < 3)
                        {
                            if (editOptionErase == 1)
                            {
                                bool flightExistsErase = false;
                                int indexFlightErase = 0;

                                while (!flightExistsErase)
                                {
                                    Console.CursorTop = 40;
                                    Console.Write("                                                                                                                                              ");
                                    string stringMessage2 = "Departures Erase - CHOOSE A FLIGHT: ";
                                    Console.CursorTop = 40;
                                    Console.CursorLeft = 0;
                                    Console.Write(stringMessage2);
                                    Console.CursorLeft = stringMessage2.Length;
                                    string editFlight = Console.ReadLine();

                                    for (int i = 0; i < 5; i++)
                                    {
                                        if (Departures[i].FlightNumber == editFlight)
                                        {
                                            indexFlightErase = i;
                                            flightExistsErase = true;
                                        }
                                    }
                                }

                                Departures[indexFlightErase].DateTime = null;
                                BuildScreen();
                                flightFound = true;
                            }

                            if (editOptionErase == 2)
                            {
                                bool flightExistsErase = false;
                                int indexFlightErase = 0;

                                while (!flightExistsErase)
                                {
                                    Console.CursorTop = 40;
                                    Console.Write("                                                                                                                                             ");
                                    string stringMessage3 = "Arrivals Erase - CHOOSE A FLIGHT: ";
                                    Console.CursorTop = 40;
                                    Console.CursorLeft = 0;
                                    Console.Write(stringMessage3);
                                    Console.CursorLeft = stringMessage3.Length;
                                    string editFlight = Console.ReadLine();

                                    for (int i = 0; i < 5; i++)
                                    {
                                        if (Arrivals[i].FlightNumber == editFlight)
                                        {
                                            indexFlightErase = i;
                                            flightExistsErase = true;
                                        }
                                    }
                                }

                                Arrivals[indexFlightErase].DateTime = null;
                                BuildScreen();
                                flightFound = true;
                            }
                        }
                    }
                    break;
                #endregion

                case 3:
                    // Search by flight
                    int editOptionSearchByFlight = 0;
                    Console.CursorTop = 40;
                    Console.Write("                                                                                                                                                  ");
                    string stringMessageSearchByFlight = "Edit - 1-Departures, 2-Arrivals? ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessageSearchByFlight);
                    Console.CursorLeft = stringMessageSearchByFlight.Length;

                    editOptionSearchByFlight = int.Parse(Console.ReadLine());
                    SearchByFlightMenu(editOptionSearchByFlight);
                    break;

                case 4:
                    // Search by TIME
                    editOptionSearchByFlight = 0;

                    Console.CursorTop = 40;
                    Console.Write("                                                                                                                                                  ");
                    string stringMessageSearchByTime = "Edit - 1-Departures, 2-Arrivals? ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessageSearchByTime);
                    Console.CursorLeft = stringMessageSearchByTime.Length;

                    editOptionSearchByFlight = int.Parse(Console.ReadLine());
                    SearchByTimeMenu(editOptionSearchByFlight);
                    break;

                case 5:
                    // Search by DEPARTURE
                    bool flightExists = false;
                    int[] indexes = new int[0];

                    Console.CursorTop = 40;
                    Console.Write("                                                                                                                                                     ");
                    string stringMessage = "Departures - WRITE DESTINATION: ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessage);
                    Console.CursorLeft = stringMessage.Length;
                    string destinationFlight = Console.ReadLine();

                    for (int i = 0; i < 5; i++)
                    {
                        if (Departures[i].CityPort == destinationFlight)
                        {
                            Array.Resize(ref indexes, indexes.Length + 1);
                            indexes[indexes.Length - 1] = i;
                            flightExists = true;
                        }
                    }

                    if (flightExists)
                    {
                        Console.Clear();
                        Console.WriteLine("Search results:");
                        Console.WriteLine();

                        for (int j = 0; j < indexes.Length; j++)
                        {
                            Console.WriteLine("TIME : " + Departures[indexes[j]].DateTime.ToString());
                            Console.WriteLine("FLIGHT : " + Departures[indexes[j]].FlightNumber);
                            Console.WriteLine("CITY/PORT : " + Departures[indexes[j]].CityPort);
                            Console.WriteLine("AIRLINE : " + Departures[indexes[j]].Airline);
                            Console.WriteLine("TERMINAL : " + Departures[indexes[j]].Terminal);
                            Console.WriteLine("STATUS : " + Departures[indexes[j]].FlightStatus);
                            Console.WriteLine("GATE : " + Departures[indexes[j]].Gate);

                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No search results.");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    break;

                case 6:
                    // Search by Arrivals
                    flightExists = false;
                    int[] indexesArr = new int[0];

                    Console.CursorTop = 40;
                    Console.Write("                                                                                                                                                     ");
                    stringMessage = "Arrivals - WRITE ORIGIN: ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessage);
                    Console.CursorLeft = stringMessage.Length;
                    string originFlight = Console.ReadLine();

                    for (int i = 0; i < 5; i++)
                    {
                        if (Arrivals[i].CityPort == originFlight)
                        {
                            Array.Resize(ref indexesArr, indexesArr.Length + 1);
                            indexesArr[indexesArr.Length - 1] = i;
                            flightExists = true;
                        }
                    }

                    if (flightExists)
                    {
                        Console.Clear();
                        Console.WriteLine("Search results:");
                        Console.WriteLine();

                        for (int j = 0; j < indexesArr.Length; j++)
                        {
                            Console.WriteLine("TIME : " + Arrivals[indexesArr[j]].DateTime.ToString());
                            Console.WriteLine("FLIGHT : " + Arrivals[indexesArr[j]].FlightNumber);
                            Console.WriteLine("CITY/PORT : " + Arrivals[indexesArr[j]].CityPort);
                            Console.WriteLine("AIRLINE : " + Arrivals[indexesArr[j]].Airline);
                            Console.WriteLine("TERMINAL : " + Arrivals[indexesArr[j]].Terminal);
                            Console.WriteLine("STATUS : " + Arrivals[indexesArr[j]].FlightStatus);
                            Console.WriteLine("GATE : " + Arrivals[indexesArr[j]].Gate);

                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No search results.");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    break;

                case 7:
                    // Search by TIME
                    editOptionSearchByFlight = 0;
                    Console.CursorTop = 40;
                    Console.Write("                                                                                                                                                  ");
                    string stringMessageNearOnes = "Search near flights - 1-Departures, 2-Arrivals? ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessageNearOnes);
                    Console.CursorLeft = stringMessageNearOnes.Length;

                    editOptionSearchByFlight = int.Parse(Console.ReadLine());
                    SearchNearFlights(editOptionSearchByFlight);
                    break;

                case 8:
                    string warningMsn = "WARNING!!!!!!! ALARM ACTIVATED!!!!!!";
                    Console.CursorLeft = (Console.WindowWidth - warningMsn.Length) / 2;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();

                    for (int i = 0; i < 5; i++)
                    {
                        Console.CursorLeft = (Console.WindowWidth - warningMsn.Length) / 2;
                        Console.WriteLine(warningMsn);
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to deactivate the alarm and return...");
                    Console.ReadLine();

                    BuildScreen();
                    break;

                case 9:
                    System.Environment.Exit(-1);
                    break;
            }
        }

        private static void EditMenu(int option)
        {
            switch (option)
            {
                #region
                case 1:
                    bool flightExists = false;
                    int indexFlight = 0;

                    while (!flightExists)
                    {
                        Console.CursorTop = 40;
                        Console.Write("                                                                                                                       ");
                        string stringMessage = "Departures - CHOOSE A FLIGHT: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(stringMessage);
                        Console.CursorLeft = stringMessage.Length;
                        string editFlight = Console.ReadLine();

                        for (int i = 0; i < 5; i++)
                        {
                            if (Departures[i].FlightNumber == editFlight)
                            {
                                indexFlight = i;
                                flightExists = true;
                            }
                        }
                    }

                    if (flightExists)
                    {
                        bool correctDate = false;
                        while (!correctDate)
                        {
                            Console.CursorTop = 40;
                            Console.Write("                                                                                                      ");
                            string editDate = "Edit - Set TIME \"HH:mm\": ";
                            Console.CursorTop = 40;
                            Console.CursorLeft = 0;
                            Console.Write(editDate);
                            DateTime timeDeparture;

                            if (DateTime.TryParse(Console.ReadLine(), out timeDeparture))
                            {
                                Departures[indexFlight].DateTime = timeDeparture;
                                correctDate = true;
                            }
                        }

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editCity = "Edit - Set CITY/PORT: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editCity);
                        Departures[indexFlight].CityPort = Console.ReadLine();

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editAirline = "Edit - Set AIRLINE: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editAirline);
                        Departures[indexFlight].Airline = Console.ReadLine();

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editTerminal = "Edit - Set TERMINAL: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editTerminal);
                        Departures[indexFlight].Terminal = Console.ReadLine();

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editStatus = "Edit - Set STATUS: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editStatus);
                        Departures[indexFlight].FlightStatus = Console.ReadLine();

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editGate = "Edit - Set GATE: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editGate);
                        Departures[indexFlight].Gate = Console.ReadLine();

                        BuildScreen();
                    }
                    break;
                #endregion

                #region
                case 2:
                    bool flightExistsArrivals = false;
                    int indexFlightArrivals = 0;

                    while (!flightExistsArrivals)
                    {
                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string stringMessage = "Arrivals - CHOOSE A FLIGHT: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(stringMessage);
                        Console.CursorLeft = stringMessage.Length;
                        string editFlight = Console.ReadLine();

                        for (int i = 0; i < 5; i++)
                        {
                            if (Arrivals[i].FlightNumber == editFlight)
                            {
                                indexFlightArrivals = i;
                                flightExistsArrivals = true;
                            }
                        }
                    }

                    if (flightExistsArrivals)
                    {
                        bool corretDate = false;
                        while (!corretDate)
                        {
                            Console.CursorTop = 40;
                            Console.Write("                                                                                                      ");
                            string editDate = "Edit - Set TIME \"HH:MM\": ";
                            Console.CursorTop = 40;
                            Console.CursorLeft = 0;
                            Console.Write(editDate);
                            DateTime timeArrival;

                            if (DateTime.TryParse(Console.ReadLine(), out timeArrival))
                            {
                                Arrivals[indexFlightArrivals].DateTime = timeArrival;
                                corretDate = true;
                            }
                        }

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editCity = "Edit - Set CITY/PORT: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editCity);
                        Arrivals[indexFlightArrivals].CityPort = Console.ReadLine();

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editAirline = "Edit - Set AIRLINE: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editAirline);
                        Arrivals[indexFlightArrivals].Airline = Console.ReadLine();

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editTerminal = "Edit - Set TERMINAL: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editTerminal);
                        Arrivals[indexFlightArrivals].Terminal = Console.ReadLine();

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editStatus = "Edit - Set STATUS: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editStatus);
                        Arrivals[indexFlightArrivals].FlightStatus = Console.ReadLine();

                        Console.CursorTop = 40;
                        Console.Write("                                                                                                      ");
                        string editGate = "Edit - Set GATE: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(editGate);
                        Arrivals[indexFlightArrivals].Gate = Console.ReadLine();

                        BuildScreen();
                    }
                    break;
                    #endregion
            }
        }

        private static void SearchByFlightMenu(int option)
        {
            switch (option)
            {
                case 1:
                    bool flightExists = false;
                    int indexFlight = 0;

                    while (!flightExists)
                    {
                        Console.CursorTop = 40;
                        Console.Write("                                                                                                              ");
                        string stringMessageDep = "Departures - WRITE A FLIGHT: ";
                        Console.CursorTop = 40;
                        Console.CursorLeft = 0;
                        Console.Write(stringMessageDep);
                        Console.CursorLeft = stringMessageDep.Length;
                        string editFlightDep = Console.ReadLine();

                        for (int i = 0; i < 5; i++)
                        {
                            if (Departures[i].FlightNumber == editFlightDep)
                            {
                                indexFlight = i;
                                flightExists = true;
                            }
                        }
                    }

                    if (flightExists)
                    {
                        Console.Clear();
                        Console.WriteLine("Search result:");
                        Console.WriteLine();

                        Console.WriteLine("TIME : " + Departures[indexFlight].DateTime.ToString());
                        Console.WriteLine("FLIGHT : " + Departures[indexFlight].FlightNumber);
                        Console.WriteLine("CITY/PORT : " + Departures[indexFlight].CityPort);
                        Console.WriteLine("AIRLINE : " + Departures[indexFlight].Airline);
                        Console.WriteLine("TERMINAL : " + Departures[indexFlight].Terminal);
                        Console.WriteLine("STATUS : " + Departures[indexFlight].FlightStatus);
                        Console.WriteLine("GATE : " + Departures[indexFlight].Gate);

                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No search result:");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    break;

                case 2:
                    flightExists = false;
                    indexFlight = 0;

                    Console.CursorTop = 40;
                    Console.Write("                                                                                                      ");
                    string stringMessage = "Arrivals - WRITE A FLIGHT: ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessage);
                    Console.CursorLeft = stringMessage.Length;
                    string editFlight = Console.ReadLine();

                    for (int i = 0; i < 5; i++)
                    {
                        if (Arrivals[i].FlightNumber == editFlight)
                        {
                            indexFlight = i;
                            flightExists = true;
                        }
                    }

                    if (flightExists)
                    {
                        Console.Clear();
                        Console.WriteLine("Search results:");
                        Console.WriteLine();

                        Console.WriteLine("TIME : " + Arrivals[indexFlight].DateTime.ToString());
                        Console.WriteLine("FLIGHT : " + Arrivals[indexFlight].FlightNumber);
                        Console.WriteLine("CITY/PORT : " + Arrivals[indexFlight].CityPort);
                        Console.WriteLine("AIRLINE : " + Arrivals[indexFlight].Airline);
                        Console.WriteLine("TERMINAL : " + Arrivals[indexFlight].Terminal);
                        Console.WriteLine("STATUS : " + Arrivals[indexFlight].FlightStatus);
                        Console.WriteLine("GATE : " + Arrivals[indexFlight].Gate);

                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No search results.");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    break;
            }
        }//

        private static void SearchByTimeMenu(int option)
        {
            switch (option)
            {
                case 1:
                    bool flightExists = false;
                    int[] indexes = new int[0];

                    Console.CursorTop = 40;
                    Console.Write("                                                                                                               ");
                    string stringMessage = "Departures - WRITE FLIGHT'S TIME: ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessage);
                    Console.CursorLeft = stringMessage.Length;
                    string timeFlight = Console.ReadLine();

                    for (int i = 0; i < 5; i++)
                    {
                        DateTime date = (DateTime)Departures[i].DateTime;
                        string flightsTime = date.ToString("HH:mm");

                        if (flightsTime == timeFlight)
                        {
                            Array.Resize(ref indexes, indexes.Length + 1);
                            indexes[indexes.Length - 1] = i;
                            flightExists = true;
                        }
                    }

                    if (flightExists)
                    {
                        Console.Clear();
                        Console.WriteLine("Search results:");
                        Console.WriteLine();

                        for (int j = 0; j < indexes.Length; j++)
                        {
                            Console.WriteLine("TIME : " + Departures[indexes[j]].DateTime.ToString());
                            Console.WriteLine("FLIGHT : " + Departures[indexes[j]].FlightNumber);
                            Console.WriteLine("CITY/PORT : " + Departures[indexes[j]].CityPort);
                            Console.WriteLine("AIRLINE : " + Departures[indexes[j]].Airline);
                            Console.WriteLine("TERMINAL : " + Departures[indexes[j]].Terminal);
                            Console.WriteLine("STATUS : " + Departures[indexes[j]].FlightStatus);
                            Console.WriteLine("GATE : " + Departures[indexes[j]].Gate);

                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No search results.");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    break;

                case 2:
                    flightExists = false;
                    int[] indexesArr = new int[0];

                    Console.CursorTop = 40;
                    Console.Write("                                                                                                      ");
                    string stringMessageArr = "Arrivals - WRITE FLIGHT'S TIME: ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessageArr);
                    Console.CursorLeft = stringMessageArr.Length;
                    string timeFlightArr = Console.ReadLine();

                    for (int i = 0; i < 5; i++)
                    {
                        DateTime date = (DateTime)Arrivals[i].DateTime;
                        string flightsTime = date.ToString("HH:mm");

                        if (flightsTime == timeFlightArr)
                        {
                            Array.Resize(ref indexesArr, indexesArr.Length + 1);
                            indexesArr[indexesArr.Length - 1] = i;
                            flightExists = true;
                        }
                    }


                    if (flightExists)
                    {
                        Console.Clear();
                        Console.WriteLine("Search results:");
                        Console.WriteLine();

                        for (int j = 0; j < indexesArr.Length; j++)
                        {
                            Console.WriteLine("TIME : " + Arrivals[indexesArr[j]].DateTime.ToString());
                            Console.WriteLine("FLIGHT : " + Arrivals[indexesArr[j]].FlightNumber);
                            Console.WriteLine("CITY/PORT : " + Arrivals[indexesArr[j]].CityPort);
                            Console.WriteLine("AIRLINE : " + Arrivals[indexesArr[j]].Airline);
                            Console.WriteLine("TERMINAL : " + Arrivals[indexesArr[j]].Terminal);
                            Console.WriteLine("STATUS : " + Arrivals[indexesArr[j]].FlightStatus);
                            Console.WriteLine("GATE : " + Arrivals[indexesArr[j]].Gate);

                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No search results.");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    break;
            }
        }//

        private static void SearchNearFlights(int option)
        {
            switch (option)
            {
                case 1:
                    bool flightExists = false;
                    int[] indexes = new int[0];

                    Console.CursorTop = 40;
                    Console.Write("                                                                                                      ");
                    string stringMessage = "Departures - WRITE THE TIME: ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessage);
                    Console.CursorLeft = stringMessage.Length;
                    TimeSpan timeIntro = TimeSpan.Parse(Console.ReadLine());

                    for (int i = 0; i < 5; i++)
                    {
                        DateTime timeDep = (DateTime)Departures[i].DateTime;
                        TimeSpan timeFlight = timeDep.TimeOfDay;
                        TimeSpan span = timeFlight.Subtract(timeIntro);
                        double minutes = span.TotalMinutes;

                        if (minutes > -60 && minutes < 60)
                        {
                            Array.Resize(ref indexes, indexes.Length + 1);
                            indexes[indexes.Length - 1] = i;
                            flightExists = true;
                        }
                    }

                    if (flightExists)
                    {
                        Console.Clear();
                        Console.WriteLine("Search results:");
                        Console.WriteLine();

                        for (int j = 0; j < indexes.Length; j++)
                        {
                            Console.WriteLine("TIME : " + Departures[indexes[j]].DateTime.ToString());
                            Console.WriteLine("FLIGHT : " + Departures[indexes[j]].FlightNumber);
                            Console.WriteLine("CITY/PORT : " + Departures[indexes[j]].CityPort);
                            Console.WriteLine("AIRLINE : " + Departures[indexes[j]].Airline);
                            Console.WriteLine("TERMINAL : " + Departures[indexes[j]].Terminal);
                            Console.WriteLine("STATUS : " + Departures[indexes[j]].FlightStatus);
                            Console.WriteLine("GATE : " + Departures[indexes[j]].Gate);

                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No search results.");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    break;

                case 2:
                    flightExists = false;
                    int[] indexesArr = new int[0];

                    Console.CursorTop = 40;
                    Console.Write("                                                                                                      ");
                    string stringMessageArr = "Arrivals - WRITE THE TIME: ";
                    Console.CursorTop = 40;
                    Console.CursorLeft = 0;
                    Console.Write(stringMessageArr);
                    Console.CursorLeft = stringMessageArr.Length;
                    TimeSpan timeIntroArr = TimeSpan.Parse(Console.ReadLine());

                    for (int i = 0; i < 5; i++)
                    {
                        DateTime timeArr = (DateTime)Arrivals[i].DateTime;
                        TimeSpan timeFlight = timeArr.TimeOfDay;
                        TimeSpan span = timeFlight.Subtract(timeIntroArr);
                        double minutes = span.TotalMinutes;

                        if (minutes > -60 && minutes < 60)
                        {
                            Array.Resize(ref indexesArr, indexesArr.Length + 1);
                            indexesArr[indexesArr.Length - 1] = i;
                            flightExists = true;
                        }
                    }

                    if (flightExists)
                    {
                        Console.Clear();
                        Console.WriteLine("Search results:");
                        Console.WriteLine();

                        for (int j = 0; j < indexesArr.Length; j++)
                        {
                            Console.WriteLine("TIME : " + Arrivals[indexesArr[j]].DateTime.ToString());
                            Console.WriteLine("FLIGHT : " + Arrivals[indexesArr[j]].FlightNumber);
                            Console.WriteLine("CITY/PORT : " + Arrivals[indexesArr[j]].CityPort);
                            Console.WriteLine("AIRLINE : " + Arrivals[indexesArr[j]].Airline);
                            Console.WriteLine("TERMINAL : " + Arrivals[indexesArr[j]].Terminal);
                            Console.WriteLine("STATUS : " + Arrivals[indexesArr[j]].FlightStatus);
                            Console.WriteLine("GATE : " + Arrivals[indexesArr[j]].Gate);

                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No search results.");
                        Console.WriteLine();
                        Console.WriteLine("Press a key to return...");
                        string s = Console.ReadLine();
                        BuildScreen();
                    }
                    break;
            }
        }//

        static void MakeLine()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("_");
            }
        }

        static void MakeLine(int cursorPosition)
        {
            Console.CursorTop = cursorPosition;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("_");
            }
        }
    }
}
