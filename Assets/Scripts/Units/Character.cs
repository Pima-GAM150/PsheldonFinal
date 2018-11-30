using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit {

    public PlayerUnit unitInfo;

	// Use this for initialization
	void Start () {
        this.gameObject.name = unitInfo.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
