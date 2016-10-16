using UnityEngine;
using System.Collections;

public class bomberCollision : MonoBehaviour {

    public ParticleSystem hitParticles;
    private bool crashed;

    public bool Crashed
    {
        get
        {
            return crashed;
        }
    }

    void Start()
    {
        crashed = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        crashed = true;
        hitParticles.Play();
        GameObject.Find("stealth bomber 2").SetActive(false);
        
    }
}
