using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    /// <summary>
    /// The game object that is controlled by the player
    /// </summary>
    public GameObject player;

    /// <summary>
    /// The difference between the player position and the camera position.
    /// </summary>
    private Vector3 offset;



	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;
        //transform.position = player.transform.position + offset;
    }
	    
	// Update is called once per frame
	void LateUpdate () {

        transform.position = player.transform.position + offset;
	}
}
