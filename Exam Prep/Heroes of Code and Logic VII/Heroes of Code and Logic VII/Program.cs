using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public Hero(string n, int hp , int mp)
        {
            this.Name = n;
            this.MP = mp;
            this.HP = hp;
        }
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string currName = tokens[0];
                int currHP = int.Parse(tokens[1]);
                int currMP = int.Parse(tokens[2]);

                Hero currHero = new Hero(currName, currHP, currMP);
                heroes[currName] = currHero;
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(" - ");
                string command = tokens[0];

                if (command == "CastSpell")
                {
                    string currName = tokens[1];
                    int MP_Needed = int.Parse(tokens[2]);   
                    string spellName = tokens[3];

                    if (heroes[currName].MP >= MP_Needed)
                    {
                        heroes[currName].MP -= MP_Needed;
                        Console.WriteLine($"{currName} has successfully cast {spellName} and now has {heroes[currName].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{currName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if(command == "TakeDamage")
                {
                    string currName = tokens[1];
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];

                    heroes[currName].HP -= damage;

                    if (heroes[currName].HP > 0)
                    {
                        Console.WriteLine($"{currName} was hit for {damage} HP by {attacker} and now has {heroes[currName].HP} HP left!");
                    }
                    else
                    {
                        heroes.Remove(currName);
                        Console.WriteLine($"{currName} has been killed by {attacker}!");
                    }
                }
                else if(command == "Recharge")
                {
                    string currName = tokens[1];
                    int amount = int.Parse(tokens[2]);

                    int oldMP = heroes[currName].MP;

                    heroes[currName].MP += amount;

                    if (heroes[currName].MP > 200)
                    {
                        Console.WriteLine($"{currName} recharged for {200 - oldMP} MP!");
                        heroes[currName].MP = 200;    
                    }
                    else
                    {
                        Console.WriteLine($"{currName} recharged for {amount} MP!");
                    }
                }
                else if(command == "Heal")
                {
                    string currName = tokens[1];
                    int amount = int.Parse(tokens[2]);

                    int oldHP = heroes[currName].HP;

                    heroes[currName].HP += amount;

                    if (heroes[currName].HP > 100)
                    {
                        Console.WriteLine($"{currName} healed for {100 - oldHP} HP!");
                        heroes[currName].HP = 100;
                    }
                    else
                    {
                        Console.WriteLine($"{currName} healed for {amount} HP!");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in heroes)
            {
                Hero currHero = item.Value;

                Console.WriteLine($"{currHero.Name}");
                Console.WriteLine($"  HP: {currHero.HP}");
                Console.WriteLine($"  MP: {currHero.MP}");
            }


        }
    }
}
