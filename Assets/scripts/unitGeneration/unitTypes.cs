using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class unitTypes : basicUnit
{

    public int unitSTR;
    public int unitEND;
    public int unitAGL;
    public int unitWLL;
    public int unitLCK;


    // standard unit

   

    public void GenerateStandardUnit()
    {
        

        List<int> Stats = new List<int> { strength, endurance, agility, will, luck };
        List<int> currentStats = new List<int> { unitSTR, unitEND, unitAGL, unitWLL, unitLCK };

        for (int i = 0; i < 5; i++)
        {
            currentStats[i] = Stats[i];
            
        }

      
            for (int j = 0; j < 5; j++)
            {
                if (currentStats[j] < 8 || currentStats[j] > 4)
                {
                    currentStats[j] = currentStats[j] + Random.Range(-1, 2);
                }
                else
                {
                    continue;
                }
            }
        
        //    foreach (int i in currentStats)
        //{
        //    Debug.Log(i);
        //}

    }

    public void GenerateScoutUnit()
    {
        List<int> Stats = new List<int> { strength, endurance, agility, will, luck };
        List<int> currentStats = new List<int> { unitSTR, unitEND, unitAGL, unitWLL, unitLCK };

        for (int i = 0; i < 5; i++)
        {
            currentStats[i] = Stats[i] - 1;

        }
        for (int j = 0; j < 5; j++)
        {
            if (j == 2 || j == 3)
            {
                if (currentStats[j] < 9 || currentStats[j] > 5)
                {
                    currentStats[j] = currentStats[j] + Random.Range(-1, 2);
                }
                else
                {
                    continue;
                }
            }
            else if (currentStats[j] < 7 || currentStats[j] > 3)
            {
                currentStats[j] = currentStats[j] + Random.Range(-1, 2);
            }
            else
            {
                continue;
            }
        }
    }

    public void GenerateHeavyUnit()
    {
        List<int> Stats = new List<int> { strength, endurance, agility, will, luck };
        List<int> currentStats = new List<int> { unitSTR, unitEND, unitAGL, unitWLL, unitLCK };

        for (int i = 0; i < 5; i++)
        {
            currentStats[i] = Stats[i] - 1;

        }
        for (int j = 0; j < 5; j++)
        {
            if (j == 0 || j == 1)
            {
                if (currentStats[j] < 9 || currentStats[j] > 5)
                {
                    currentStats[j] = currentStats[j] + Random.Range(-1, 2);
                }
                else
                {
                    continue;
                }
            }
            else if (currentStats[j] < 7 || currentStats[j] > 3)
            {
                currentStats[j] = currentStats[j] + Random.Range(-1, 2);
            }
            else
            {
                continue;
            }
        }
    }

    public void GenerateMeleeUnit()
    {
        List<int> Stats = new List<int> { strength, endurance, agility, will, luck };
        List<int> currentStats = new List<int> { unitSTR, unitEND, unitAGL, unitWLL, unitLCK };

        for (int i = 0; i < 5; i++)
        {
            currentStats[i] = Stats[i] - 1;

        }
        for (int j = 0; j < 5; j++)
        {
            if (j == 2 || j == 1)
            {
                if (currentStats[j] < 9 || currentStats[j] > 5)
                {
                    currentStats[j] = currentStats[j] + Random.Range(-1, 2);
                }
                else
                {
                    continue;
                }
            }
            else if (currentStats[j] < 7 || currentStats[j] > 3)
            {
                currentStats[j] = currentStats[j] + Random.Range(-1, 2);
            }
            else
            {
                continue;
            }
        }
    }

}
