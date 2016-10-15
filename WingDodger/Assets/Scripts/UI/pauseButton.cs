using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class pauseButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private bool paused;

    // Use this for initialization
    void Start() {

        paused = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public virtual void OnPointerDown(PointerEventData ped)
    {

        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
        }

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
}
