using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class resumeGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public GameObject pauseButton;
    pauseButton pButton;
	// Use this for initialization
	void Start () {

        pButton = pauseButton.GetComponent<pauseButton>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnPointerDown(PointerEventData ped)
    {
        pButton.OnPointerDown(ped);

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
}
