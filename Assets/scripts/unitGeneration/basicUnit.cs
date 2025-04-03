using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


[CreateAssetMenu(fileName = "Base Stats", menuName = "ScriptableObjects/Base Stats")]
public class basicUnit : ScriptableObject
{
    //base stats
    //public int strength { get; private set; } = 5;
    //public int endurance { get; private set; } = 5;
    //public int agility { get; private set; } = 5;
    //public int will { get; private set; } = 5;
    //public int luck { get; private set; } = 5;

    public class baseStat
    {
        public readonly string statName;
        public readonly int statValue;
        public baseStat(string statName, int statValue)
        {
            this.statName = statName;
            this.statValue = statValue;
        }
    }
public class generalUnit
    {
        public readonly baseStat strength = new baseStat("Strength", 5);        
        public readonly baseStat endurance = new baseStat("Endurance", 5);
        public readonly baseStat agility = new baseStat("Agility", 5);
        public readonly baseStat will = new baseStat("Will", 5);
        public readonly baseStat luck = new baseStat("Luck", 5);

    }

    public class skillsBase 
    {
        public readonly string skillName;
        public readonly string skillAtribute;
        public readonly int skillValue;

        public skillsBase(string skillName, string skillAtribute, int skillValue)
        {
            this.skillName = skillName;
            this.skillAtribute = skillAtribute;
            this.skillValue = skillValue;
        }



    }

    ////skills
    //public skillsBase meleeSkill = new skillsBase("Melee", "str", 1);
    //public skillsBase unarmedSkill = new skillsBase("Unarmed", "str", 1);
    //public skillsBase throwSkill = new skillsBase("Throw", "str", 1);
    //public skillsBase largeGunSkill = new skillsBase("Large Guns", "str", 1);
    //public skillsBase athleticsSkill = new skillsBase("Athletics", "str, end, agl", 1);
    //public skillsBase stealthSkill = new skillsBase("Stealth", "agl, lck", 1);
    //public skillsBase mediumGunSkill = new skillsBase("Medium Guns", "agl", 1);
    //public skillsBase DodgeSkill = new skillsBase("Dodge", "agl, lck", 1);
    //public skillsBase explosiveSkill = new skillsBase("Explosives", "wll", 1);

    //ToDo add other skills
    //public skillsBase  = new skillsBase("", "str", 1);


    // unit specific stat modifiers

    // general unit

}
