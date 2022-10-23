using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._1_Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var heroes = new List<Hero>();

            for (int i = 0; i < n; i++)
            {
                string[] newHero = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Hero hero = new Hero();
                hero.Name = newHero[0];
                hero.HP = int.Parse(newHero[1]);
                hero.MP = int.Parse(newHero[2]);

                heroes.Add(hero);

            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "End")
                {
                    break;
                }

                string command = commands[0];

                switch (command)
                {
                    case "CastSpell":
                        CastSpell(commands[1], int.Parse(commands[2]), commands[3], heroes);
                        break;
                    case "TakeDamage":
                        TakeDamage(commands[1], int.Parse(commands[2]), commands[3], heroes);
                        break;
                    case "Recharge":
                        Recharge(commands[1], int.Parse(commands[2]), heroes);
                        break;
                    case "Heal":
                        Heal(commands[1], int.Parse(commands[2]), heroes);
                        break;
                }

            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine($"  HP: {hero.HP}");
                Console.WriteLine($"  MP: {hero.MP}");

            }

        }

        static void Heal(string name, int ammount, List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                if (hero.Name == name)
                {
                    int originalHP = hero.HP;

                    hero.HP += ammount;

                    if (hero.HP > 100)
                    {
                        hero.HP = 100;

                        Console.WriteLine($"{hero.Name} healed for {100 - originalHP} HP!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} healed for {ammount} HP!");
                    }
                }
            }
        }

        static void Recharge(string name, int ammount, List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                if (hero.Name == name)
                {
                    int originalMP = hero.MP;
                    
                    hero.MP += ammount;

                    if (hero.MP > 200)
                    {
                        hero.MP = 200;

                        Console.WriteLine($"{hero.Name} recharged for {200 - originalMP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} recharged for {ammount} MP!");
                    }
                }
            }
        }

        static void TakeDamage(string name, int damage, string attacker, List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                if (hero.Name == name)
                {
                    hero.HP -= damage;
                    
                    if (hero.HP > 0)
                    {
                        Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.HP} HP left!");
                    }
                    else
                    {
                       Console.WriteLine($"{hero.Name} has been killed by {attacker}!");

                        heroes.Remove(hero);

                        break;
                        
                    }
                }
            }

            
        }

        static void CastSpell(string name, int manaNeeded, string spellName, List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                if (hero.Name == name)
                {
                    var curHero = hero;

                    if (curHero.MP >= manaNeeded)
                    {
                        curHero.MP -= manaNeeded;
                        hero.MP = curHero.MP;
                        Console.WriteLine($"{name} has successfully cast {spellName} and now has {curHero.MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{curHero.Name} does not have enough MP to cast {spellName}!");
                    }
                }

            }
        }
    }

    class Hero
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

    }
}
