using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TilemapInput : MonoBehaviour {

	public Tilemap tilemap;
	public List<TileInfo> placedTiles = new List<TileInfo>();

	public Transform testTarget;

	void Start() {

		// go through each position in the tilemap grid
		foreach ( Vector3Int tilePos in tilemap.cellBounds.allPositionsWithin ) {

			// get the rule tile at that position, if it exists (null otherwise)
			RuleTile tileAtPos = tilemap.GetTile<RuleTile>( tilePos );

			// check if a tile has been placed at this position
			if( tileAtPos ) {

				// create a new class to store information about the tile at this position and add it to a list to remember it
				TileInfo tileInfo = new TileInfo {
					worldPos = tilemap.CellToWorld( tilePos ),
					specificTile = tileAtPos
				};

				placedTiles.Add( tileInfo );
			}
		}
	}

	// detect clicks from the Event System through the main camera's Physics 2D Raycaster
	public TileInfo GetClosestTileToPosition( Vector3 pos ) {

		print("Clicked!" );

		// go through each of the placed tiles and find the one closest to where you've clicked
		float closestDistance = Mathf.Infinity;
		TileInfo closestTile = null;
		foreach( TileInfo tile in placedTiles ) {
			float sqrDistToTile = (pos - tile.worldPos).sqrMagnitude;
			if( sqrDistToTile < closestDistance ) {
				closestDistance = sqrDistToTile;
				closestTile = tile;
			}
		}

		return closestTile;
	}
}

public class TileInfo {
	public Vector3 worldPos;
	public RuleTile specificTile;
}