using UnityEngine;
using System.Collections;


/// <summary>
/// This class generates 'infinite' terrain
/// based off the stealth bomber's location and will
/// destory tiles and add tiles as the player moves 
/// through the terrain.
/// Technique learned from: https://www.youtube.com/watch?v=dycHQFEz8VI
/// </summary>
public class InfiniteTerrain : MonoBehaviour {

    /// <summary>
    /// The prefab we are using to build up our landscape
    /// </summary>
    public GameObject terrainPlane;
    /// <summary>
    /// the gameobject that is being used by the player.
    /// </summary>
    public GameObject stealthBomber;

    int planeSize = 10;
    int tileX = 10;
    int tileZ = 10;

    Vector3 startPos;

    Hashtable tiles = new Hashtable();


	// Use this for initialization
	void Start () {

        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

		InitialiseTiles (updateTime);
	}
	
	// Update is called once per frame
	void Update () {

        //determine how far the stealth bomber
        //has moved since last terrain update
        int xMove = (int)(stealthBomber.transform.position.x - startPos.x);
        int zMove = (int)(stealthBomber.transform.position.z - startPos.z);

		// Update the tiles in the world in accordance with the players position
		updateTiles (xMove, zMove);

	
	}


	/// <summary>
	/// Initialises the tiles when the player spawns into the game,
	/// making sure the player is covered with terrain around them.
	/// </summary>
	/// <param name="updateTime">Update time.</param>
	void InitialiseTiles(float updateTime) {


		for(int x = -tileX; x < tileX; x++)
		{
			for(int z = -tileZ; z < tileZ; z++)
			{

				Vector3 pos = new Vector3((x * planeSize + startPos.x),
					0,
					(z * planeSize + startPos.z));
				GameObject t = (GameObject)Instantiate(terrainPlane, pos,Quaternion.identity);

				// Naming the tiles so they can be referenced later
				string tName = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
				t.name = tName;
				TerrainTile tile = new TerrainTile(t, updateTime);
				tiles.Add(tName, tile);
			}
		}
	}

	/// <summary>
	/// Updates the tiles in the world depending on the players location.
	/// It also gets rid of tiles that have not been updated.	
	/// </summary>
	/// <param name="xMove">X move.</param>
	/// <param name="zMove">Z move.</param>
	void updateTiles(int xMove, int zMove) {
		

		if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
		{

			float updateTime = Time.realtimeSinceStartup;

			int bomberPosX = (int)(Mathf.Floor(stealthBomber.transform.position.x / planeSize) * planeSize);
			int bomberPosZ = (int)(Mathf.Floor(stealthBomber.transform.position.z / planeSize) * planeSize);


			for(int x = -tileX; x < tileX; x++)
			{

				for(int z = -tileZ; z < tileZ; z++)
				{

					Vector3 pos = new Vector3((x * planeSize + bomberPosX),
						0,
						(z * planeSize + bomberPosZ));
					string tName = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

					if(!tiles.ContainsKey(tName))
					{
						GameObject t = (GameObject)Instantiate(terrainPlane, pos,
							Quaternion.identity);
						t.name = tName;
						TerrainTile tile = new TerrainTile(t, updateTime);
						tiles.Add(tName, tile);
					}
					else
					{
						(tiles[tName] as TerrainTile).creationTime = updateTime;
					}
				}
			}

			Hashtable newTerrain = new Hashtable();

			foreach(TerrainTile tile in tiles.Values)
			{
				if(tile.creationTime != updateTime)
				{
					Destroy(tile.tile);
				}
				else
				{
					newTerrain.Add(tile.tile.name, tile);
				}
			}

			tiles = newTerrain;
			startPos = stealthBomber.transform.position;
		}

	}
}
