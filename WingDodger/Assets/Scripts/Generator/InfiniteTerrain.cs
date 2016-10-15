using UnityEngine;
using System.Collections;


class TerrainTile
{
    public GameObject tile;
    public float creationTime;

    public TerrainTile(GameObject t, float ct)
    {
        tile = t;
        creationTime =  ct;
    }

}


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
    int halfTileX = 10;
    int halfTileZ = 10;

    Vector3 startPos;

    Hashtable tiles = new Hashtable();


	// Use this for initialization
	void Start () {

        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for(int x = -halfTileX; x < halfTileX; x++)
        {
            for(int z = -halfTileZ; z < halfTileZ; z++)
            {

                Vector3 pos = new Vector3((x * planeSize + startPos.x),
                                   0,
                                   (z * planeSize + startPos.z));
                GameObject t = (GameObject)Instantiate(terrainPlane, pos,
                                            Quaternion.identity);
                string tName = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                Debug.Log(tName);
                t.name = tName;
                TerrainTile tile = new TerrainTile(t, updateTime);
                tiles.Add(tName, tile);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        //determine how far the stealth bomber
        //has moved since last terrain update
        int xMove = (int)(stealthBomber.transform.position.x - startPos.x);
        int zMove = (int)(stealthBomber.transform.position.z - startPos.z);

        if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
        {

            float updateTime = Time.realtimeSinceStartup;

            int bomberPosX = (int)(Mathf.Floor(stealthBomber.transform.position.x / planeSize) * planeSize);
            int bomberPosZ = (int)(Mathf.Floor(stealthBomber.transform.position.z / planeSize) * planeSize);


            for(int x = -halfTileX; x < halfTileX; x++)
            {

                for(int z = -halfTileZ; z < halfTileZ; z++)
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
