using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class basicUnit : MonoBehaviour
{
    //base stats
    public int strength { get; private set; } = 5;
    public int endurance { get; private set; } = 5;
    public int agility { get; private set; } = 5;
    public int will { get; private set; } = 5;
    public int luck { get; private set; } = 5;

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
}
