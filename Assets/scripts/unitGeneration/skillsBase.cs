using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillsBase : MonoBehaviour
{
    public string skillName;
    public string skillAtribute;
    public int skillValue;

    public skillsBase (string skillName, string skillAtribute, int skillValue)
    {
        this.skillName = skillName;
        this.skillAtribute = skillAtribute;
        this.skillValue = skillValue;
    }

    

}
