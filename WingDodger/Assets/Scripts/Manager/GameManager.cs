using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text score;
    public GameObject pauseButton;
    public GameObject stealthBomber;
    public GameObject obstaclesGenerator;

    pauseButton pButton;
    bomberCollision bCollision;
    generator treeGenerator;

    int points;

	// Use this for initialization
	void Start () {

        pButton = pauseButton.GetComponent<pauseButton>();
        bCollision = stealthBomber.GetComponent<bomberCollision>();
        treeGenerator = obstaclesGenerator.GetComponent<generator>();
        points = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if(!pButton.Paused && !bCollision.Crashed)
        {
            points++;
            score.text = points.ToString();
        }

        
        if(points == 100)
            treeGenerator.obstacleAmount += 50;


        if (points == 1000)
            treeGenerator.obstacleAmount += 100;

        if (points == 10000)
            treeGenerator.obstacleAmount += 50;

        if (points == 100000)
            treeGenerator.obstacleAmount += 75;

        if (points == 1000000)
            treeGenerator.obstacleAmount += 100;

	}


}
