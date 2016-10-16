using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class pauseButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private bool paused;
    public GameObject slider;
    public GameObject pauseMenu;
   

    public bool Paused
    {
        get
        {
            return paused;
        }
    }

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
            slider.SetActive(true);
            pauseMenu.SetActive(false);

        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            slider.SetActive(false);
            pauseMenu.SetActive(true);
        }

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
}
