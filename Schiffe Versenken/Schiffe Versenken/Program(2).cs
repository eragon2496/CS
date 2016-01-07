using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schiffe_versenken
{
    class Program
    {
        internal static string[,] felderAi = new string[10, 10]; //Spielfeld Computer
        internal static string[,] felderSpieler = new string[10, 10]; //Spielfeld Computer
        internal static int Schlachtschiff = 5;
        internal static int Kreuzer = 4;
        internal static int Zerstörer = 3;
        internal static int UBoote = 2;
        internal static int AnzSchl = 1;
        internal static int AnzKr = 2;
        internal static int AnzZer = 3;
        internal static int AnzUB = 4;
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen bei Schiffe versenken - Console Edition");
            Console.WriteLine("Wieviele Schiffe soll jeder zur Verfügung haben?");
            Console.WriteLine("Die KI positioniert ihre Schiffe");
            ErzeugeSpielfeld();
            Console.WriteLine("Positionieren sie ihre Schiffe: ");
            Console.ReadKey();
            KiPositionierung();
            Console.ReadKey();
        }
        static void ErzeugeSpielfeld()
        {
            Console.Write(" " + "|");
            for (int counter = 0; counter < 10; counter++) Console.Write(counter + "|");
            Console.WriteLine();
            char Spalte = 'A';
            for (int counter = 0; counter < 10;counter++ )
            {
                Console.Write(Spalte + "|");
                Spalte++;
                for (int counter2 = 0; counter2 < 10;counter2++)
                {
                    felderSpieler[counter,counter2] = "0";
                    felderAi[counter, counter2] = "0";
                    Console.Write(felderSpieler[counter,counter2] + "|");
                }
                Console.WriteLine();
            }
        }
        internal static int kiKreuzer = 0;
        internal static int kiSchlachtschiffe = 0;
        internal static int kiZerstörer = 0;
        internal static int kiUBoote = 0;
        static void KiPositionierung()
        {
        start:
            if (kiSchlachtschiffe<1)
            {
                kiSchlachtschiffe++;
                KiSchlachtschiffesetzen();
                goto start;
            }
            if (kiKreuzer <2)
            {
                kiKreuzer++;
                KiKreuzersetzen();
                goto start;
            }
            if (kiZerstörer < 3)
            {
                kiZerstörer++;
                KiZerstörersetzen();
                goto start;
            }
            if (kiUBoote < 4)
            {
                kiUBoote++;
                KiUBootesetzen();
                goto start;
            }
            Console.Write(" " + "|");
            for (int counter = 0; counter < 10; counter++) Console.Write(counter + "|");
            Console.WriteLine();
            char Spalte = 'A';
            for (int counter = 0; counter < 10; counter++)
            {
                Console.Write(Spalte + "|");
                Spalte++;
                for (int counter2 = 0; counter2 < 10; counter2++)
                {
                    Console.Write(felderAi[counter, counter2] + "|");
                }
                Console.WriteLine();
            }
        }
        static void KiSchlachtschiffesetzen()
        {
        start_positionierung_ki:
            Random rnd = new Random();
            int kiSpalte;
            int kiZeile;
            int kiRichtung;
            kiSpalte = rnd.Next(0, 9);
            kiZeile = rnd.Next(0, 9);
            kiRichtung = rnd.Next(0, 3);
            kiRichtung = 0;
            if (felderAi[kiZeile, kiSpalte] == "0")
            {
                if (kiRichtung == 0)
                {
                    if (kiZeile < 4) goto start_positionierung_ki;
                    else
                    {
                        felderAi[kiZeile, kiSpalte] = "S";
                        for (int kigrößeSchlachtschiff = 0; kigrößeSchlachtschiff < 4; kigrößeSchlachtschiff++)
                        {
                            kiZeile--;
                            felderAi[kiZeile, kiSpalte] = "S";
                        }
                    }
                }
                if (kiRichtung == 1)
                {
                    if (kiSpalte > 6) goto start_positionierung_ki;
                    else
                    {
                        felderAi[kiZeile, kiSpalte] = "S";
                        for (int kigrößeSchlachtschiff = 0; kigrößeSchlachtschiff < 4; kigrößeSchlachtschiff++)
                        {
                            kiSpalte++;
                            felderAi[kiZeile, kiSpalte] = "S";
                        }
                    }
                }
                if (kiRichtung == 2)
                {
                    if (kiZeile > 5) goto start_positionierung_ki;
                    else
                    {
                        felderAi[kiZeile, kiSpalte] = "S";
                        for (int kigrößeSchlachtschiff = 0; kigrößeSchlachtschiff < 4; kigrößeSchlachtschiff++)
                        {
                            kiZeile++;
                            felderAi[kiZeile, kiSpalte] = "S";
                        }
                    }
                }
                if (kiRichtung == 3)
                {
                    if (kiSpalte < 4) goto start_positionierung_ki;
                    else
                    {
                        felderAi[kiZeile, kiSpalte] = "S";
                        for (int kigrößeSchlachtschiff = 0; kigrößeSchlachtschiff < 4; kigrößeSchlachtschiff++)
                        {
                            kiSpalte--;
                            felderAi[kiZeile, kiSpalte] = "S";
                        }
                    }
                }
            }
            else goto start_positionierung_ki;
        }
        static void KiKreuzersetzen()
        {
        start_positionierung_ki:
            Random rnd = new Random();
            int kiSpalte;
            int kiZeile;
            int kiRichtung;
            kiSpalte = rnd.Next(0, 9);
            kiZeile = rnd.Next(0, 9);
            kiRichtung = rnd.Next(0, 3);
            if (felderAi[kiZeile, kiSpalte] == "0")
            {
                int stopp = 0;
                if (kiRichtung == 0)
                {
                    if (kiZeile < 3) goto start_positionierung_ki;
                    else
                    {
                        do
                        {
                            string line = felderAi[kiZeile, kiSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                kiZeile--;
                            }
                            else goto start_positionierung_ki;
                        } while (stopp != 4);
                        kiZeile = kiZeile + 4;
                        felderAi[kiZeile, kiSpalte] = "K" + kiKreuzer;
                        for (int kigrößeKreuzer = 0; kigrößeKreuzer < 3; kigrößeKreuzer++)
                        {
                            kiZeile--;
                            felderAi[kiZeile, kiSpalte] = "K" + kiKreuzer;
                        }
                    }
                }
                if (kiRichtung == 1)
                {
                    if (kiSpalte > 6) goto start_positionierung_ki;
                    else
                    {
                        do
                        {
                            string line = felderAi[kiZeile, kiSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                kiSpalte++;
                            }
                            else goto start_positionierung_ki;
                        } while (stopp != 4);
                        kiSpalte = kiSpalte - 4;
                        felderAi[kiZeile, kiSpalte] = "K" + kiKreuzer;
                        for (int kigrößeKreuzer = 0; kigrößeKreuzer < 3; kigrößeKreuzer++)
                        {
                            kiSpalte++;
                            felderAi[kiZeile, kiSpalte] = "K" + kiKreuzer;
                        }
                    }
                }
                if (kiRichtung == 2)
                {
                    if (kiZeile > 6) goto start_positionierung_ki;
                    else
                    {
                        do
                        {
                            string line = felderAi[kiZeile, kiSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                kiZeile++;
                            }
                            else goto start_positionierung_ki;
                        } while (stopp != 4);
                        kiZeile = kiZeile - 4;
                        felderAi[kiZeile, kiSpalte] = "K" + kiKreuzer;
                        for (int kigrößeKreuzer = 0; kigrößeKreuzer < 3; kigrößeKreuzer++)
                        {
                            kiZeile++;
                            felderAi[kiZeile, kiSpalte] = "K" + kiKreuzer;
                        }
                    }
                }
                if (kiRichtung == 3)
                {
                    if (kiSpalte < 3) goto start_positionierung_ki;
                    else
                    {
                        do
                        {
                            string line = felderAi[kiZeile, kiSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                kiSpalte--;
                            }
                            else goto start_positionierung_ki;
                        } while (stopp != 4);
                        kiSpalte = kiSpalte + 4;
                        felderAi[kiZeile, kiSpalte] = "K" + kiKreuzer;
                        for (int kigrößeKreuzer = 0; kigrößeKreuzer < 3; kigrößeKreuzer++)
                        {
                            kiSpalte--;
                            felderAi[kiZeile, kiSpalte] = "K" + kiKreuzer;
                        }
                    }
                }
            }
            else goto start_positionierung_ki;
        }
        static void KiZerstörersetzen()
        {
            start_positionierung_ki:
                Random rnd = new Random();
                int kiSpalte;
                int kiZeile;
                int kiRichtung;
                kiSpalte = rnd.Next(0, 9);
                kiZeile = rnd.Next(0, 9);
                kiRichtung = rnd.Next(0, 3);
                if (felderAi[kiZeile, kiSpalte] == "0")
                {
                    int stopp = 0;
                    if (kiRichtung == 0)
                    {
                        if (kiZeile < 2) goto start_positionierung_ki;
                        else
                        {
                            do
                            {
                                string line = felderAi[kiZeile, kiSpalte];
                                if (line.Contains("0"))
                                {
                                    stopp++;
                                    kiZeile--;
                                }
                                else goto start_positionierung_ki;
                            } while (stopp != 3);
                            kiZeile = kiZeile + 3;
                            felderAi[kiZeile, kiSpalte] = "Z" + kiZerstörer;
                            for (int kigrößeZerstörer = 0; kigrößeZerstörer < 2; kigrößeZerstörer++)
                            {
                                kiZeile--;
                                felderAi[kiZeile, kiSpalte] = "Z" + kiZerstörer;
                            }
                        }
                    }
                    if (kiRichtung == 1)
                    {
                        if (kiSpalte > 7) goto start_positionierung_ki;
                        else
                        {
                            do
                            {
                                string line = felderAi[kiZeile, kiSpalte];
                                if (line.Contains("0"))
                                {
                                    stopp++;
                                    kiSpalte++;
                                }
                                else goto start_positionierung_ki;
                            } while (stopp != 3);
                            kiSpalte = kiSpalte - 3;
                            felderAi[kiZeile, kiSpalte] = "Z" + kiZerstörer;
                            for (int kigrößeZerstörer = 0; kigrößeZerstörer < 2; kigrößeZerstörer++)
                            {
                                kiSpalte++;
                                felderAi[kiZeile, kiSpalte] = "Z" + kiZerstörer;
                            }
                        }
                    }
                    if (kiRichtung == 2)
                    {
                        if (kiZeile > 7) goto start_positionierung_ki;
                        else
                        {
                            do
                            {
                                string line = felderAi[kiZeile, kiSpalte];
                                if (line.Contains("0"))
                                {
                                    stopp++;
                                    kiZeile++;
                                }
                                else goto start_positionierung_ki;
                            } while (stopp != 3);
                            kiZeile = kiZeile - 3;
                            felderAi[kiZeile, kiSpalte] = "Z" + kiZerstörer;
                            for (int kigrößeZerstörer = 0; kigrößeZerstörer < 2; kigrößeZerstörer++)
                            {
                                kiZeile++;
                                felderAi[kiZeile, kiSpalte] = "Z" + kiZerstörer;
                            }
                        }
                    }
                    if (kiRichtung == 3)
                    {
                        if (kiSpalte < 2) goto start_positionierung_ki;
                        else
                        {
                            do
                            {
                                string line = felderAi[kiZeile, kiSpalte];
                                if (line.Contains("0"))
                                {
                                    stopp++;
                                    kiSpalte--;
                                }
                                else goto start_positionierung_ki;
                            } while (stopp != 3);
                            kiSpalte = kiSpalte + 3;
                            felderAi[kiZeile, kiSpalte] = "Z" + kiZerstörer;
                            for (int kigrößeZerstörer = 0; kigrößeZerstörer < 2; kigrößeZerstörer++)
                            {
                                kiSpalte--;
                                felderAi[kiZeile, kiSpalte] = "Z" + kiZerstörer;
                            }
                        }
                    }
                else goto start_positionierung_ki;
            }
        }
        static void KiUBootesetzen()
        {
        start_positionierung_ki:
            Random rnd = new Random();
            int kiSpalte;
            int kiZeile;
            int kiRichtung;
            kiSpalte = rnd.Next(0, 9);
            kiZeile = rnd.Next(0, 9);
            kiRichtung = rnd.Next(0, 3);
            if (felderAi[kiZeile, kiSpalte] == "0")
            {
                int stopp = 0;
                if (kiRichtung == 0)
                {
                    if (kiZeile < 1) goto start_positionierung_ki;
                    else
                    {
                        do
                        {
                            string line = felderAi[kiZeile, kiSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                kiZeile--;
                            }
                            else goto start_positionierung_ki;
                        } while (stopp != 2);
                        kiZeile = kiZeile + 2;
                        felderAi[kiZeile, kiSpalte] = "U" + kiUBoote;
                        for (int kigrößeUBoote = 0; kigrößeUBoote < 1; kigrößeUBoote++)
                        {
                            kiZeile--;
                            felderAi[kiZeile, kiSpalte] = "U" + kiUBoote;
                        }
                    }
                }
                if (kiRichtung == 1)
                {
                    if (kiSpalte > 8) goto start_positionierung_ki;
                    else
                    {
                        do
                        {
                            string line = felderAi[kiZeile, kiSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                kiSpalte++;
                            }
                            else goto start_positionierung_ki;
                        } while (stopp != 2);
                        kiSpalte = kiSpalte - 2;
                        felderAi[kiZeile, kiSpalte] = "U" + kiUBoote;
                        for (int kigrößeUBoote = 0; kigrößeUBoote < 1; kigrößeUBoote++)
                        {
                            kiSpalte++;
                            felderAi[kiZeile, kiSpalte] = "U" + kiUBoote;
                        }
                    }
                }
                if (kiRichtung == 2)
                {
                    if (kiZeile > 8) goto start_positionierung_ki;
                    else
                    {
                        do
                        {
                            string line = felderAi[kiZeile, kiSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                kiZeile++;
                            }
                            else goto start_positionierung_ki;
                        } while (stopp != 2);
                        kiZeile = kiZeile - 2;
                        felderAi[kiZeile, kiSpalte] = "U" + kiUBoote;
                        for (int kigrößeUBoote = 0; kigrößeUBoote < 1; kigrößeUBoote++)
                        {
                            kiZeile++;
                            felderAi[kiZeile, kiSpalte] = "U" + kiUBoote;
                        }
                    }
                }
                if (kiRichtung == 3)
                {
                    if (kiSpalte < 1) goto start_positionierung_ki;
                    else
                    {
                        do
                        {
                            string line = felderAi[kiZeile, kiSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                kiSpalte--;
                            }
                            else goto start_positionierung_ki;
                        } while (stopp != 2);
                        kiSpalte = kiSpalte + 2;
                        felderAi[kiZeile, kiSpalte] = "U" + kiUBoote;
                        for (int kigrößeUBoote = 0; kigrößeUBoote < 1; kigrößeUBoote++)
                        {
                            kiSpalte--;
                            felderAi[kiZeile, kiSpalte] = "U" + kiUBoote;
                        }
                    }
                }
            }
            else goto start_positionierung_ki; 
        }
    }
}