using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown(0) ){
            Debug.Log("Mouse has been clicked.");

            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitInfo.collider != null)
            {
                Debug.Log("Selected " + hitInfo.transform.gameObject.name);
            }
            else
            {
                Debug.Log("No selection.");
            }
        }
	}
}
