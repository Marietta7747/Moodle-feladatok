﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;

namespace Telefonkönyv
{

    class Person
    {
        public string name { get; set; }
        public string address { get; set; }
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public long mbleNumber { get; set; }
        public char sex { get; set; }
        public string mail { get; set; }
        public string citisionNumber { get; set; }

        public Person(string name, string address, string fatherName, string motherName, long mbleNumber, char sex, string mail, string citisionNumber)
        {
            this.name = name;
            this.address = address;
            this.fatherName = fatherName;
            this.motherName = motherName;
            this.mbleNumber = mbleNumber;
            this.sex = sex;
            this.mail = mail;
            this.citisionNumber = citisionNumber;
        }

        public Person() 
        { 
        
        }

        public void Back()
        {
            Start();
        }
        public void Start()
        {
            Menu();
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t**********WELCOME TO PHONEBOOK*************");
            Console.WriteLine("\n\n\t\t\t\t\t\t\t MENU \t\t\n\n");
            Console.WriteLine("\t\t\t\t\t1.Add New \t2.Display \t3.Exit \n\t\t\t\t\t4.Modify \t5.Search \t6.Delete");

            switch (Console.ReadKey().KeyChar)
            {
                case '1': Addrecord();
                    break;

                case '2': Listrecord();
                    break;

                case '3': Environment.Exit(0);
                    break;

                case '4': Modifyrecord();
                    break;

                case '5': Searchrecord();
                    break;

                case '6': Deleterecord();
                    break;

                default: Console.Clear();
                    Console.WriteLine("\nEnter 1 to 6 only");
                    Console.WriteLine("\nEnter any key");
                    Console.ReadKey();
                    Menu();
                    break;

            }
        }

        public void Addrecord()
        {
            Console.Clear();
            Person p = new Person();

            StreamWriter sw = new StreamWriter("record.txt");

            Console.WriteLine("\nEnter name: ");
            p.name = Console.ReadLine();

            Console.WriteLine("\nEnter the address: ");
            p.address = Console.ReadLine();

            Console.WriteLine("\nEnter father name: ");
            p.fatherName = Console.ReadLine();

            Console.WriteLine("\nEnter mother name: ");
            p.motherName = Console.ReadLine();

            Console.WriteLine("\nEnter phone no: ");
            p.mbleNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter sex: ");
            p.sex = char.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter e-mail: ");
            p.mail = Console.ReadLine();

            Console.WriteLine("\nEnter citizen no: ");
            p.citisionNumber = Console.ReadLine();

            sw.WriteLine($"{p.name};{p.address};{p.fatherName};{p.motherName};{p.mbleNumber};" +
                $"{p.sex};{p.mail};{p.citisionNumber}");

            Console.Clear();
            Console.WriteLine("\nrecord saved");
            sw.Close();

            Console.WriteLine("\n\nEnter any key");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public void Listrecord()
        {
            Console.Clear();
            Person p = new Person();
            string filePath = "record.txt";
            StreamReader sr = new StreamReader("record.txt");

            if (!File.Exists(filePath))
            {
                Console.WriteLine("\nFile opening error in listing :");
                Environment.Exit(1);
            }

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] strings = line.Split(';');

                Console.WriteLine("\n\n\n YOUR RECORD IS\n\n ");
                Console.WriteLine($"Name={strings[0]}\nAddress={strings[1]}\nFather name={strings[2]}\nMother name={strings[3]}\nMobile no={long.Parse(strings[4])}\nSex={char.Parse(strings[5])}\nE-mail={strings[6]}\nCitizen no={strings[7]}");
                Console.ReadKey();
                Console.Clear();
            }

            sr.Close();
            Console.WriteLine("\nEnter any key");
            Console.ReadKey();
            Menu();

    }

        public void Searchrecord()
        {
            Console.Clear();
            Person p = new Person();
            StreamReader sr = new StreamReader("record.txt");

            if (sr == null)
            {
                Console.WriteLine("\n error in openning\a\a\a\a");
                Environment.Exit(1);
            }

            Console.WriteLine("\nEnter name of person to search\n");
            string name = Console.ReadLine();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] strings = line.Split(';');
                if (name == strings[0])
                {
                    Console.WriteLine($"\n\tDetail Information About {name}");
                    Console.WriteLine($"Name={strings[0]}\nAddress={strings[1]}\nFather name={strings[2]}\nMother name={strings[3]}\nMobile no={long.Parse(strings[4])}\nSex={char.Parse(strings[5])}\nE-mail={strings[6]}\nCitizen no={strings[7]}");

                }
                else
                {
                    Console.WriteLine("file not found");
                }
            }

            sr.Close();
            Console.WriteLine("\nEnter any key");
            Console.ReadKey();
            Console.Clear();
            Menu();

        }

        public void Deleterecord()
        {
            Console.Clear();
            Person p = new Person();
            StreamReader sr = new StreamReader("record.txt");
            int flag = 0;
            string name;

            if (sr == null)
            {
                Console.WriteLine("CONTACT'S DATA NOT ADDED YET.");
            }
            else
            {
                StreamWriter sw = new StreamWriter("temp.txt");
                if (sw == null)
                {
                    Console.WriteLine("file opening error");
                }
                else
                {
                    Console.WriteLine("Enter CONTACT'S NAME: ");
                    string name1 = Console.ReadLine();
                    Console.Clear();
                    while(!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] strings = line.Split(';');
                        if (name1 != strings[0])
                        {
                            sw.WriteLine(name1);
                        }
                        if (name1 == strings[0])
                        {
                            flag = 1;
                        }
                    }

                    sr.Close();
                    sw.Close();
                    if (flag != 1)
                    {
                        Console.WriteLine("NO CONTACT'S RECORD TO DELETE");
                        File.Delete("temp.txt");
                    }

                    else
                    {
                        File.Delete("record.txt");
                        File.Move("temp.txt", "record.txt");
                        Console.WriteLine("RECORD DELETED SUCCESSFULLY");
                    }
                }  
            }

            Console.WriteLine("\nEnter any key");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public void Modifyrecord()
        {
            Console.Clear();
            int flag = 0;
            Person p = new Person();
            Person s = new Person();
            string name;

            StreamReader sr = new StreamReader("record.txt");
            if (sr == null)
            {
                Console.WriteLine("CONTACT'S DATA NOT ADDED YET.");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("\nEnter CONTACT'S NAME TO MODIFY: \n");
                name = sr.ReadLine();
                

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] strings = line.Split(';');
                    if(name != strings[0])
                    {
                        Console.WriteLine("\nEnter name: ");
                        s.name = Console.ReadLine();

                        Console.WriteLine("\nEnter the address: ");
                        s.address = Console.ReadLine();

                        Console.WriteLine("\nEnter father name: ");
                        s.fatherName = Console.ReadLine();

                        Console.WriteLine("\nEnter mother name: ");
                        s.motherName = Console.ReadLine();

                        Console.WriteLine("\nEnter phone no: ");
                        s.mbleNumber = long.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter sex: ");
                        s.sex = char.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter e-mail: ");
                        s.mail = Console.ReadLine();

                        Console.WriteLine("\nEnter citizen no: ");
                        s.citisionNumber = Console.ReadLine();

                        flag = 1;
                        break;
                    }
                    Console.Clear();
                }
                if (flag == 1)
                {
                    Console.WriteLine("\nyour data id modified");
                }
                else
                {
                    Console.WriteLine("\ndata is not found");
                }
                sr.Close();
            }

            Console.WriteLine("\nEnter any key");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Person p = new Person();

            p.Start();

            Console.ReadKey();
        }
    }
}
