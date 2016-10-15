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
    /// The side to side movement speed, its best if this
    /// is less than the rotation speed for smooth rotations.
    /// </summary>
    public  float lateralVelocity;

    /// <summary>
    /// The rigid body of the plane.
    /// </summary>
    public Rigidbody rigidBody;

    float tiltThreshold = 0.100f;
 

	// Use this for initialization
	void Start () {

        DebugConsole.isVisible = true;
        rigidBody.velocity = planeVelocity*Vector3.forward;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        DebugConsole.Log(Input.acceleration.x.ToString(),"normal");
        
   

        float currSpeed = Time.deltaTime * rotationSpeed;

        // rigidBody.AddForce(Input.acceleration.x * lateralVelocity * Vector3.right * Time.deltaTime,ForceMode.Impulse);
        //rigidBody.AddForce(planeVelocity * Vector3.forward*Time.deltaTime);
        rigidBody.position += Input.acceleration.x * lateralVelocity * Vector3.right * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * currSpeed * Input.acceleration.x);
        rigidBody.rotation *= deltaRotation;
        
    } 
}
