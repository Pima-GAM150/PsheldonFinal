using System;
using UnityEngine;

public class EnemyUnit : ScriptableObject {

    public string enemyName;
    public string charClass;
    public int level;
    public int[] stats = new int[8];
    public int build;
    public int move;


    public void Load(string line)
    {
        string[] elements = line.Split(',');
        enemyName = elements[0];
        charClass = elements[1];
        level = Convert.ToInt32(elements[2]);
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = Convert.ToInt32(elements[3 + i]);
        }
        build = Convert.ToInt32(elements[11]);
        move = Convert.ToInt32(elements[12]);
    }
}
