using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : ScriptableObject {

    public string charName;
    public string charClass;
    public string gender;
    public int level;
    public int exp;
    public int[] stats = new int[8];
    public int build;
    public int move;
    public int[] statGrowths = new int[8];

    public void Load(string line)
    {
        string[] elements = line.Split(',');
        charName = elements[0];
        charClass = elements[1];
        gender = elements[2];
        level = Convert.ToInt32(elements[3]);
        exp = Convert.ToInt32(elements[4]);
        for(int i = 0; i < stats.Length; i++)
        {
            stats[i] = Convert.ToInt32(elements[5 + i]);
        }
        build = Convert.ToInt32(elements[13]);
        move = Convert.ToInt32(elements[14]);
        for(int i = 0; i < stats.Length; i++)
        {
            statGrowths[i] = Convert.ToInt32(elements[15 + i]);
        }
    }

	
}
