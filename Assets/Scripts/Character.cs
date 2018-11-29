using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public PlayerUnit unitInfo;

	// Use this for initialization
	void Start () {
        this.gameObject.name = unitInfo.name;
        Debug.Log("My name is " + this.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
