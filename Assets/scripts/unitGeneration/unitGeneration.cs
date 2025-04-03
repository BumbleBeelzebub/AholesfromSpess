using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitGeneration : MonoBehaviour
{
    [SerializeField]
    basicUnit basicUnit;


    // -------Still have to implement & test---------


    public class newUnit
    {
        public class unitStat
        {
            public string name;
            public int value;
            public unitStat(string name, int statValue)
            {
                this.name = name;
                this.value = statValue;
            }
        }

        public unitStat str = new(generalUnit.strength.statName, generalUnit.strength.statValue);
        public unitStat agl = new(generalUnit.agility.statName, generalUnit.agility.statValue);
        public unitStat end = new(generalUnit.endurance.statName, generalUnit.endurance.statValue);
        public unitStat wll = new(generalUnit.will.statName, generalUnit.will.statValue);
        public unitStat lck = new(generalUnit.luck.statName, generalUnit.luck.statValue);
       
    }


   public static basicUnit.generalUnit generalUnit;
   public newUnit tempUnit;
    unitClass chosenClass = unitClass.standard;
    private enum unitClass
    {
        standard,
        scout,
        heavy,
        melee
    }
    


    private void GenerateUnit(unitClass newClass)
    {


        newUnit generatedUnit = new newUnit();
        List<int> list = new List<int>();

        switch (newClass)
            {
                case unitClass.standard:
                list = MakeStatValuesIntoList(generatedUnit);
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] += Random.Range(-1, 2);
                }
                generatedUnit = ReturnListToUnit(list, generatedUnit);
                    break;
                case unitClass.scout:
                list = MakeStatValuesIntoList(generatedUnit);
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 1 || i == 3)
                    {
                        list[i] += Random.Range(0, 3);
                    }
                    else
                    {
                        list[i] += Random.Range(-1, 2);
                    }
                    
                }
                generatedUnit = ReturnListToUnit(list, generatedUnit);
                break;
                case unitClass.heavy:
                list = MakeStatValuesIntoList(generatedUnit);
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 0 || i == 2)
                    {
                        list[i] += Random.Range(0, 3);
                    }
                    else
                    {
                        list[i] += Random.Range(-1, 2);
                    }

                }
                generatedUnit = ReturnListToUnit(list, generatedUnit);
                break;
                case unitClass.melee:
                list = MakeStatValuesIntoList(generatedUnit);
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 1 || i == 2)
                    {
                        list[i] += Random.Range(0, 3);
                    }
                    else
                    {
                        list[i] += Random.Range(-1, 2);
                    }

                }
                generatedUnit = ReturnListToUnit(list, generatedUnit);
                break;
                
            }
        
    }


    private List<int> MakeStatValuesIntoList(newUnit newUnit)
    {
        List<int> values = new List<int>
        {
            tempUnit.str.value,
            tempUnit.agl.value,
            tempUnit.end.value,
            tempUnit.wll.value,
            tempUnit.lck.value,

        };
        return values;
    }
    private newUnit ReturnListToUnit(List<int> values, newUnit gen)     
    {
        
        gen.str.value = values[0];
        gen.agl.value = values[1];
        gen.end.value = values[2];
        gen.wll.value = values[3];
        gen.lck.value = values[4];

        return gen;
    }
}

