using UnityEngine;
using System.Collections;

public  class BomberController : MonoBehaviour {

    /// <summary>
    /// The speed the plane traverses the terrain.
    /// </summary>
    public float planeVelocity;

    /// <summary>
    /// The speed the plane will roate at.
    /// </summary>
    public float rotationSpeed;

    /// <summary>
    /// The rigid body of the plane.
    /// </summary>
    public Rigidbody rigidBody;

 

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        float currSpeed = Time.deltaTime * rotationSpeed;
        this.transform.Translate(Input.acceleration.x * planeVelocity * Vector3.right * Time.deltaTime,Space.World);
        transform.Rotate(Vector3.up, currSpeed * Input.acceleration.x);
    } 
}
