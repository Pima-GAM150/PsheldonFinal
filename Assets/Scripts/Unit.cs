using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Unit : MonoBehaviour {

    public UnitData unitData;

    public void Save()
    {
        string json = JsonUtility.ToJson(unitData);

        File.WriteAllText(Application.streamingAssetsPath + "/save.txt", json);
    }

    public void Load( string json )
    {
        unitData = JsonUtility.FromJson<UnitData>(json);
    }
}

[System.Serializable]
public class UnitData
{
    public string name;
    public string job;
    public int lvl;
    public int exp;
    public int[] stats = new int[8];
    public int[] statGrowths = new int[8];

    public UnitData()
    {
        name = "Sample";
        job = "Sample";
        lvl = 1;
        exp = 0;
        for (int i = 1; i < stats.Length; i++)
        {
            stats[i] = 1;
        }
        for (int i = 1; i < statGrowths.Length; i++)
        {
            statGrowths[i] = 0;
        }
    }

    public UnitData(string newName, string newJob, int lvl,
        int exp, int[] stats, int[] statGrowths)
    {
        name = newName;
        job = newJob;
        this.lvl = lvl;
        this.exp = exp;
        this.stats = stats;
        this.statGrowths = statGrowths;
    }
}
