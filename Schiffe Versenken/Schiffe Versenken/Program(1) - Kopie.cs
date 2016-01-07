using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schiffe_versenken
{
    class Program
    {
        internal static string[,] felderAi = new string[10, 10]; //Spielfeld Computer
        internal static string[,] felderSpieler = new string[10, 10]; //Spielfeld Spieler
        internal static string[,] felderSpieler2 = new string[10, 10]; //Spielfeld Trefferfeld Spieler
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
            KiPositionierung();
            //Console.WriteLine("Positionieren sie ihre Schiffe: ");
            //SpielerPositionierung();
            Console.ReadKey();
            //KiSchuss();
            //Console.ReadKey();
        }
        static void ErzeugeSpielfeld()
        {
            Console.Write(" " + "|");
            for (int counter = 0; counter < 10; counter++) Console.Write("0" + counter + "|");
            Console.WriteLine();
            char Spalte = 'A';
            for (int counter = 0; counter < 10;counter++ )
            {
                Console.Write(Spalte + "|");
                Spalte++;
                for (int counter2 = 0; counter2 < 10;counter2++)
                {
                    felderSpieler[counter,counter2] = "0";
                    felderSpieler2[counter, counter2] = "00";
                    felderAi[counter, counter2] = "0";
                    Console.Write(felderSpieler[counter,counter2] + "|");
                }
                Console.WriteLine();
            }
        }
        static void Spielfeld()
        {
            Console.Write("  " + "|");
            for (int counter = 0; counter < 10; counter++) Console.Write("0" + counter + "|");
            Console.WriteLine();
            char Spalte = 'A';
            for (int counter = 0; counter < 10; counter++)
            {
                Console.Write(Spalte + "|");
                Spalte++;
                for (int counter2 = 0; counter2 < 10; counter2++)
                {
                    Console.Write(felderSpieler[counter, counter2] + "|");
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
        static void KiSchuss()
        {
            Schuss:
            Random rnd = new Random();
            int kiSpalte;
            int kiZeile;
            kiSpalte = rnd.Next(0, 9);
            kiZeile = rnd.Next(0, 9);
            if (felderSpieler2[kiZeile, kiSpalte] == "0")
            {
                felderSpieler2[kiZeile, kiSpalte] = "X";
                felderSpieler[kiZeile, kiSpalte] = "X";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "S")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TS";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "K1")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TK1";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "K2")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TK2";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "Z1")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TZ1";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "Z2")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TZ2";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "Z3")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TZ3";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "U1")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TU1";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "U2")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TU2";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "U3")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TU3";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else if (felderSpieler2[kiZeile, kiSpalte] == "U4")
            {
                felderSpieler2[kiZeile, kiSpalte] = "TU4";
                felderSpieler[kiZeile, kiSpalte] = "T";
            }
            else goto Schuss;
        }
        internal static int spielerKreuzer = 0;
        internal static int spielerSchlachtschiffe = 0;
        internal static int spielerZerstörer = 0;
        internal static int spielerUBoote = 0;
        static void SpielerPositionierung()
        {
            start:
            if (spielerSchlachtschiffe == 0)
            {
                spielerSchlachtschiffe++;
                SpielerSchlachtschiffesetzen();
                goto start;
            }
            if (spielerKreuzer != 2)
            {
                spielerKreuzer++;
                if (spielerKreuzer == 1) Console.WriteLine("Positionieren Sie als nächstes die Kreuzer. Die haben eine größe von jeweils 4 Feldern.");
                if (spielerKreuzer == 2) Console.WriteLine("Geben Sie die Position für den zweiten Kreuzer an");
                SpielerKreuzersetzen();
                goto start;
            }
        }
        static void SpielerSchlachtschiffesetzen()
        {
        SpielerPositionierung:
            Console.WriteLine("Positionieren Sie zuerst das Schlachtschiff. Das hat eine größe von 5 Feldern.");
            Console.Write("Geben sie die Spalte an: ");
            string eingabe = Console.ReadLine();
            eingabe = eingabe.ToUpper();
            char ch = Convert.ToChar(eingabe);
            int SpielerSpalte = ch - 'A';
            Console.Write("Geben sie die Zeile an: ");
            int SpielerZeile = Convert.ToInt32(Console.ReadLine());
            Console.Write("Geben Sie jetzt die Richtung an. Dabei steht 0 für Oben,\n1 für Rechts, 2 für Unten und 3 für links.");
            int SpielerRichtung = Convert.ToInt32(Console.ReadLine());
            if (felderAi[SpielerZeile, SpielerSpalte] == "0")
            {
                if (SpielerRichtung == 0)
                {
                    if (SpielerZeile < 4)
                    {
                        Console.WriteLine("Schlachtschiff kann hier nicht positioniert werden. Bitte erneut positionieren");
                        Console.Clear();
                        goto SpielerPositionierung;
                    }
                    else
                    {
                        felderAi[SpielerZeile, SpielerSpalte] = "S";
                        for (int kigrößeSchlachtschiff = 0; kigrößeSchlachtschiff < 4; kigrößeSchlachtschiff++)
                        {
                            SpielerZeile--;
                            felderAi[SpielerZeile, SpielerSpalte] = "S";
                        }
                    }
                }
                if (SpielerRichtung == 1)
                {
                    if (SpielerSpalte > 6)
                    {
                        Console.WriteLine("Schlachtschiff kann hier nicht positioniert werden. Bitte erneut positionieren");
                        Console.Clear();
                        goto SpielerPositionierung;
                    }
                    else
                    {
                        felderAi[SpielerZeile, SpielerSpalte] = "S";
                        for (int kigrößeSchlachtschiff = 0; kigrößeSchlachtschiff < 4; kigrößeSchlachtschiff++)
                        {
                            SpielerSpalte++;
                            felderAi[SpielerZeile, SpielerSpalte] = "S";
                        }
                    }
                }
                if (SpielerRichtung == 2)
                {
                    if (SpielerZeile > 5)
                    {
                        Console.WriteLine("Schlachtschiff kann hier nicht positioniert werden. Bitte erneut positionieren");
                        Console.Clear();
                        goto SpielerPositionierung;
                    }
                    else
                    {
                        felderAi[SpielerZeile, SpielerSpalte] = "S";
                        for (int kigrößeSchlachtschiff = 0; kigrößeSchlachtschiff < 4; kigrößeSchlachtschiff++)
                        {
                            SpielerZeile++;
                            felderAi[SpielerZeile, SpielerSpalte] = "S";
                        }
                    }
                }
                if (SpielerRichtung == 3)
                {
                    if (SpielerSpalte < 4)
                    {
                        Console.WriteLine("Schlachtschiff kann hier nicht positioniert werden. Bitte erneut positionieren");
                        Console.Clear();
                        goto SpielerPositionierung;
                    }
                    else
                    {
                        felderAi[SpielerZeile, SpielerSpalte] = "S";
                        for (int kigrößeSchlachtschiff = 0; kigrößeSchlachtschiff < 4; kigrößeSchlachtschiff++)
                        {
                            SpielerSpalte--;
                            felderAi[SpielerZeile, SpielerSpalte] = "S";
                        }
                    }
                }
            }
        }
        static void SpielerKreuzersetzen()
        {
            
        start_positionierung_spieler: 
            Console.Write("Geben sie die Spalte an: ");
            string eingabe = Console.ReadLine();
            eingabe = eingabe.ToUpper();
            char ch = Convert.ToChar(eingabe);
            int SpielerSpalte = ch - 'A';
            Console.Write("Geben sie die Zeile an: ");
            int SpielerZeile = Convert.ToInt32(Console.ReadLine());
            Console.Write("Geben Sie jetzt die Richtung an. Dabei steht 0 für Oben,\n1 für Rechts, 2 für Unten und 3 für links.");
            int SpielerRichtung = Convert.ToInt32(Console.ReadLine());
            if (felderAi[SpielerZeile, SpielerSpalte] == "0")
            {
                int stopp = 0;
                if (SpielerRichtung == 0)
                {
                    if (SpielerZeile < 3) goto start_positionierung_spieler;
                    else
                    {
                        do
                        {
                            string line = felderAi[SpielerZeile, SpielerSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                SpielerZeile--;
                            }
                            else goto start_positionierung_spieler;
                        } while (stopp != 4);
                        SpielerZeile = SpielerZeile + 4;
                        felderAi[SpielerZeile, SpielerSpalte] = "K" + kiKreuzer;
                        for (int kigrößeKreuzer = 0; kigrößeKreuzer < 3; kigrößeKreuzer++)
                        {
                            SpielerZeile--;
                            felderAi[SpielerZeile, SpielerSpalte] = "K" + kiKreuzer;
                        }
                    }
                }
                if (SpielerRichtung == 1)
                {
                    if (SpielerSpalte > 6) goto start_positionierung_spieler;
                    else
                    {
                        do
                        {
                            string line = felderAi[SpielerZeile, SpielerSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                SpielerSpalte++;
                            }
                            else goto start_positionierung_spieler;
                        } while (stopp != 4);
                        SpielerSpalte = SpielerSpalte - 4;
                        felderAi[SpielerZeile, SpielerSpalte] = "K" + kiKreuzer;
                        for (int kigrößeKreuzer = 0; kigrößeKreuzer < 3; kigrößeKreuzer++)
                        {
                            SpielerSpalte++;
                            felderAi[SpielerZeile, SpielerSpalte] = "K" + kiKreuzer;
                        }
                    }
                }
                if (SpielerRichtung == 2)
                {
                    if (SpielerZeile > 6) goto start_positionierung_spieler;
                    else
                    {
                        do
                        {
                            string line = felderAi[SpielerZeile, SpielerSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                SpielerZeile++;
                            }
                            else goto start_positionierung_spieler;
                        } while (stopp != 4);
                        SpielerZeile = SpielerZeile - 4;
                        felderAi[SpielerZeile, SpielerSpalte] = "K" + kiKreuzer;
                        for (int kigrößeKreuzer = 0; kigrößeKreuzer < 3; kigrößeKreuzer++)
                        {
                            SpielerZeile++;
                            felderAi[SpielerZeile, SpielerSpalte] = "K" + kiKreuzer;
                        }
                    }
                }
                if (SpielerRichtung == 3)
                {
                    if (SpielerSpalte < 3) goto start_positionierung_spieler;
                    else
                    {
                        do
                        {
                            string line = felderAi[SpielerZeile, SpielerSpalte];
                            if (line.Contains("0"))
                            {
                                stopp++;
                                SpielerSpalte--;
                            }
                            else goto start_positionierung_spieler;
                        } while (stopp != 4);
                        SpielerSpalte = SpielerSpalte + 4;
                        felderAi[SpielerZeile, SpielerSpalte] = "K" + kiKreuzer;
                        for (int kigrößeKreuzer = 0; kigrößeKreuzer < 3; kigrößeKreuzer++)
                        {
                            SpielerSpalte--;
                            felderAi[SpielerZeile, SpielerSpalte] = "K" + kiKreuzer;
                        }
                    }
                }
            }
            else goto start_positionierung_spieler;
        }
        static void SpielerZerstörersetzen()
        {
            start_positionierung_ki:
                Console.Write("Geben sie die Spalte an: ");
                string eingabe = Console.ReadLine();
                eingabe = eingabe.ToUpper();
                char ch = Convert.ToChar(eingabe);
                int SpielerSpalte = ch - 'A';
                Console.Write("Geben sie die Zeile an: ");
                int SpielerZeile = Convert.ToInt32(Console.ReadLine());
                Console.Write("Geben Sie jetzt die Richtung an. Dabei steht 0 für Oben,\n1 für Rechts, 2 für Unten und 3 für links.");
                int SpielerRichtung = Convert.ToInt32(Console.ReadLine());
                if (felderAi[SpielerZeile, SpielerSpalte] == "0")
                {
                    int stopp = 0;
                    if (SpielerRichtung == 0)
                    {
                        if (SpielerZeile < 2) goto start_positionierung_ki;
                        else
                        {
                            do
                            {
                                string line = felderAi[SpielerZeile, SpielerSpalte];
                                if (line.Contains("0"))
                                {
                                    stopp++;
                                    SpielerZeile--;
                                }
                                else goto start_positionierung_ki;
                            } while (stopp != 3);
                            SpielerZeile = SpielerZeile + 3;
                            felderAi[SpielerZeile, SpielerSpalte] = "Z" + kiZerstörer;
                            for (int kigrößeZerstörer = 0; kigrößeZerstörer < 2; kigrößeZerstörer++)
                            {
                                SpielerZeile--;
                                felderAi[SpielerZeile, SpielerSpalte] = "Z" + kiZerstörer;
                            }
                        }
                    }
                    if (SpielerRichtung == 1)
                    {
                        if (SpielerSpalte > 7) goto start_positionierung_ki;
                        else
                        {
                            do
                            {
                                string line = felderAi[SpielerZeile, SpielerSpalte];
                                if (line.Contains("0"))
                                {
                                    stopp++;
                                    SpielerZeile++;
                                }
                                else goto start_positionierung_ki;
                            } while (stopp != 3);
                            SpielerZeile = SpielerSpalte - 3;
                            felderAi[SpielerZeile, SpielerSpalte] = "Z" + kiZerstörer;
                            for (int kigrößeZerstörer = 0; kigrößeZerstörer < 2; kigrößeZerstörer++)
                            {
                                SpielerSpalte++;
                                felderAi[SpielerZeile, SpielerSpalte] = "Z" + kiZerstörer;
                            }
                        }
                    }
                    if (SpielerRichtung == 2)
                    {
                        if (SpielerZeile > 7) goto start_positionierung_ki;
                        else
                        {
                            do
                            {
                                string line = felderAi[SpielerZeile, SpielerSpalte];
                                if (line.Contains("0"))
                                {
                                    stopp++;
                                    SpielerZeile++;
                                }
                                else goto start_positionierung_ki;
                            } while (stopp != 3);
                            SpielerZeile = SpielerZeile - 3;
                            felderAi[SpielerZeile, SpielerSpalte] = "Z" + kiZerstörer;
                            for (int kigrößeZerstörer = 0; kigrößeZerstörer < 2; kigrößeZerstörer++)
                            {
                                SpielerZeile++;
                                felderAi[SpielerZeile, SpielerSpalte] = "Z" + kiZerstörer;
                            }
                        }
                    }
                    if (SpielerRichtung == 3)
                    {
                        if (SpielerSpalte < 2) goto start_positionierung_ki;
                        else
                        {
                            do
                            {
                                string line = felderAi[SpielerZeile, SpielerSpalte];
                                if (line.Contains("0"))
                                {
                                    stopp++;
                                    SpielerSpalte--;
                                }
                                else goto start_positionierung_ki;
                            } while (stopp != 3);
                            SpielerSpalte = SpielerSpalte + 3;
                            felderAi[SpielerZeile, SpielerSpalte] = "Z" + kiZerstörer;
                            for (int kigrößeZerstörer = 0; kigrößeZerstörer < 2; kigrößeZerstörer++)
                            {
                                SpielerSpalte--;
                                felderAi[SpielerZeile, SpielerSpalte] = "Z" + kiZerstörer;
                            }
                        }
                    }
                    else goto start_positionierung_ki;
                }
        }
    }
}