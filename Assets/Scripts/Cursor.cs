using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cursor : MonoBehaviour {

    private GameObject selected = null;
    Tilemap tilemap;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown(0) ){
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitInfo.collider != null)
            {
                if (selected == null || selected.name != hitInfo.transform.gameObject.name)
                {
                    selected = hitInfo.transform.gameObject;
                    Debug.Log("Selected " + selected.name);
                }

            } else {
                if (selected != null)
                {
                    Debug.Log("Moving " + selected.name);
                    MoveSelected(selected, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    selected = null;
                } else
                {
                    Debug.Log("Nobody to select.");
                }
                
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            if (selected != null)
            {
                Debug.Log("Deselecting " + selected.name);
                selected = null;
            }
            else
                Debug.Log("Nobody is selected.");
        }
	}

    static void MoveSelected(GameObject selectedObject, Vector2 goal)
    {
        selectedObject.transform.position = goal;
    }
}
