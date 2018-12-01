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
                // check if we clicked down on a tilemap that can accept input
                TilemapInput tilemap = hitInfo.collider.GetComponent<TilemapInput>();

                // if you've selected something already and clicked on a tilemap, then ask the tilemap input to handle where it should be placed
                if (tilemap && selected != null )
                {
                    
                    if( tilemap ) {
                        TileInfo closestTileToClick = tilemap.GetClosestTileToPosition( hitInfo.point );

                        // if you want, you can check whether the destination is a valid one here; closestTileToClick.specificTile is a reference to your RuleTile data

                        MoveSelected( selected, closestTileToClick.worldPos );
                        selected = null;
                    }
                }
                else if ((selected == null || selected.name != hitInfo.transform.gameObject.name) && hitInfo.transform.gameObject.tag =="Unit")
                {
                    selected = hitInfo.transform.gameObject;
                    Debug.Log("Selected " + selected.name);
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
