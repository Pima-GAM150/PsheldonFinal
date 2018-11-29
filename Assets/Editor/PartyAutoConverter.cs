using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

//This is an editor script for automatically converting an outside asset file into scriptable objects for use.
public class PartyAutoConverter : AssetPostprocessor
{ 
    
  [MenuItem("Pre Production/Parse Party")]
    public static void Parse()
    {
        ParseParty();
    }

    static Dictionary<string, Action> parsers;

    static PartyAutoConverter()
    {
        parsers = new Dictionary<string, Action>();
        parsers.Add("partydata.csv", ParseParty);
    }

    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
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

    static void ParseParty()
    {
        string filePath = Application.dataPath + "/Settings/partydata.csv";
        if (!File.Exists(filePath))
        {
            Debug.LogError("Missing Party Data: " + filePath);
            return;
        }

        string[] readText = File.ReadAllLines("Assets/Settings/partydata.csv");
        filePath = "Assets/Settings/Resources/Party/";
        for (int i = 1; i < readText.Length; i++)
        {
            PlayerUnit playerUnit = ScriptableObject.CreateInstance<PlayerUnit>();
            playerUnit.Load(readText[i]);
            string fileName = string.Format("{0}{1}.asset", filePath, playerUnit.charName);
            AssetDatabase.CreateAsset(playerUnit, fileName);
        }
    }
	
}
