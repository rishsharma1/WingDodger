using UnityEngine;
using System.Collections;

public class simpleMove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(0, 0, 3);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0, 0, -1);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right);
        }
    }
}