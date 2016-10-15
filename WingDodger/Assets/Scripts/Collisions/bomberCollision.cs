using UnityEngine;
using System.Collections;

public class bomberCollision : MonoBehaviour {

    public ParticleSystem hitParticles;

    void Awake()
    {
        Debug.Log(hitParticles);

    }

    void OnCollisionEnter(Collision collision)
    {
        hitParticles.Play();
        GameObject.Find("stealth bomber 2").SetActive(false);
    }
}
