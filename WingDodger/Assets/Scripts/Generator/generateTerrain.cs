using UnityEngine;
using System.Collections;

/// <summary>
/// This script gets attached to a plane, whereby
/// it will apply perlin noise function to the the
/// plane to create a realistic looking terrain that
/// will be used to generate an infinite terrain.
/// </summary>
public class generateTerrain : MonoBehaviour {

    /// <summary>
    /// the maximum height the terrain will have
    /// </summary>
    int heightScale = 5;

    /// <summary>
    /// the level of smoothness
    /// </summary>
    float detailScale = 8f;


    /// <summary>
    /// Code Referenced: https://www.youtube.com/watch?v=dycHQFEz8VI
    /// </summary>
    void Start () {

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        for(int v=0;v<vertices.Length;v++)
        {
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x) / detailScale,
                (vertices[v].z + this.transform.position.z) / detailScale) * heightScale;


        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.gameObject.AddComponent<MeshCollider>();

	}
	
}
