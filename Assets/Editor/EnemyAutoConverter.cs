using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class EnemyAutoConverter : AssetPostprocessor {

	[MenuItem("Pre Production/Parse Enemies")]
    public static void Parse()
    {
        ParseEnemies();
    }

    static Dictionary<string, Action> parsers;

    static EnemyAutoConverter()
    {
        parsers = new Dictionary<string, Action>();
        parsers.Add("enemydata.csv", ParseEnemies);
    }

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPath)
    {
        for (int i = 0; i < importedAssets.Length; i++)
        {
            string fileName = Path.GetFileName(importedAssets[i]);
            if (parsers.ContainsKey(fileName))
                parsers[fileName]();
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    static void ParseEnemies()
    {
        string filePath = Application.dataPath + "/Settings/enemydata.csv";
        if (!File.Exists(filePath))
        {
            Debug.LogError("Missing Enemy Data: " + filePath);
            return;
        }

        string[] readText = File.ReadAllLines("Assets/Settings/enemydata.csv");
        filePath = "Assets/Settings/Resources/Enemies/";
        for (int i = 1; i < readText.Length; i++)
        {
            EnemyUnit enemyUnit = ScriptableObject.CreateInstance<EnemyUnit>();
            enemyUnit.Load(readText[i]);
            string fileName = string.Format("{0}{1}.asset", filePath, enemyUnit.charClass);
            AssetDatabase.CreateAsset(enemyUnit, fileName);
        }
    }
}
