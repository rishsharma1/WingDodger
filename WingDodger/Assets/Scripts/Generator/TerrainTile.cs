using UnityEngine;
using System.Collections;

public class TerrainTile : MonoBehaviour {

	public GameObject tile;
	public float creationTime;


	public TerrainTile(GameObject t, float ct)
	{
		tile = t;
		creationTime =  ct;
	}

}
