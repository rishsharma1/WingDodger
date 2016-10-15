using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class generator : MonoBehaviour
{
    
    public Transform player;
    // Boundaries need to be large enough
    public float horizontalBoundaries;
    // Amount could used to control the difficulty of the game
    public int obstacleAmount;
    public Transform obstacles;
    
    
    private Queue<Transform> obstacleQueue;

    // Use this for initialization
    void Start()
    {

        obstacleQueue = new Queue<Transform>(obstacleAmount);

        for (int i = 0; i < obstacleAmount; i++)
        {
            int randomSize = Random.Range(2, 5);
            int randomeRotation = Random.Range(-30, 30);
                Transform temp = (Transform)Instantiate(obstacles, new Vector3(0, -1, 0), Quaternion.Euler(0, 0, randomeRotation));
                temp.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
                obstacleQueue.Enqueue(temp);
        }

        for (int i = 0; i < obstacleAmount; i++)
        {
            generate();
        }

    }


    void generate()
    {
        Vector3 nextPosition;
        // Area of obstacles can appear
        float xSpread = Random.Range(player.position.x - horizontalBoundaries, player.position.x + horizontalBoundaries);
        // Obstacles shouldn't suddenly appear in front of the player, 100 is used for this.
        float zSpread = Random.Range(player.position.z + 100, player.position.z + 400);

        Transform obstacle = obstacleQueue.Dequeue();
        nextPosition = obstacle.position;
        nextPosition.x = xSpread;
        nextPosition.z = zSpread;
        obstacle.position = nextPosition;
        obstacleQueue.Enqueue(obstacle);
    }



    // Update is called once per frames
    void Update()
    {
        // If obstacles are out of the area, take them back
        if (obstacleQueue.Peek().position.z < player.position.z 
            || obstacleQueue.Peek().position.x > player.position.x + horizontalBoundaries 
            || obstacleQueue.Peek().position.x < player.position.x - horizontalBoundaries)
        {
            generate();
        }
    }
}