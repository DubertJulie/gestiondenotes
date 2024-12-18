using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choixMenu;
            int choixValide;

            double valeurNote = 0;
            int noteN = 0;
            double saisieValide;

            List<double> notes = new List<double>();
            bool isNotes = true;

 
            do
            {
                Console.Write("--- Gestion des notes avec menu --- \n\n1---- Saisir les notes \n2---- La plus grande note  \n3---- La plus petite note \n4---- La moyenne des notes \n0---- Quitter \n\n Faites votre choix : ");

                // Contrôle de saisie choix du menu 
                while (!int.TryParse(Console.ReadLine(), out choixValide))
                { Console.WriteLine("Merci de saisir une option du menu !"); }

                choixMenu = choixValide;

                switch (choixMenu)
                {
                    case 0: Environment.Exit(0); break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("--- Saisir les notes ---");
                        do
                        {
                            Console.Write("Merci de saisir la note " + (noteN + 1) + " (sur /20) : ");

                            // Contrôle de saisie (la note n'est pas un double) 
                            while (!double.TryParse(Console.ReadLine(), out saisieValide))
                            { Console.WriteLine("Merci de ne saisir une note en chiffres !");
                              Console.Write("Merci de saisir la note " + (noteN + 1) + " (sur /20) : ");
                            };

                            valeurNote = saisieValide;

                            if (valeurNote <= 20 && valeurNote > 0) {
                            notes.Add(valeurNote);
                            noteN++;
                            } 
                            else if (valeurNote == 999)
                            {
                                isNotes = false;
                            } 
                            else
                            {
                                Console.WriteLine("\t\t Merci de saisir une note sur 20");
                            }
                        } while (isNotes == true);

                        break;

                    case 2:
                        Console.Clear();
                        if (notes.Any()) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("--- La plus grande note --- \n\nLa plus grande note est : ");
                            Console.WriteLine(notes.Max() + "\n");
                            Console.ResetColor();
                        } else
                        {
                            Console.WriteLine("Saisissez une note d'abord !");
                        }
                        
                        break;

                    case 3:
                        if (notes.Any())
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("--- La plus petite note --- \n\nLa plus petite note est : ");
                            Console.WriteLine(notes.Min() + "\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("Saisissez une note d'abord !");
                        }

                        break;

                    case 4:
                        if (notes.Any())
                        {
                            Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("--- La moyenne des notes --- \n\nLa moyenne des notes est de : ");
                        Console.WriteLine(Math.Round(notes.Average(), 2) + "\n");
                        Console.ResetColor();
                        }
                        else
                        {
                        Console.WriteLine("Saisissez une note d'abord !");
                        }
                        break;

                    default: Environment.Exit(0); break;
                }
            }

            while (choixMenu != 0);

            


        }
    }
}