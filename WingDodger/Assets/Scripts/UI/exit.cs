using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class exit : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnPointerDown(PointerEventData ped)
    {
        Application.Quit();
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
}
