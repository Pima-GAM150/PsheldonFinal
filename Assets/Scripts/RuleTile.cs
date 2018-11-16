using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class RuleTile: Tile {

    public string tileType;
    public bool isPassable;
    public bool isFlyable;
    public int moveCost;
    public int defBonus;
    public int dodgeBonus;
	
}
