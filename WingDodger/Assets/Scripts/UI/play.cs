using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class play : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void OnPointerDown(PointerEventData ped)
    {
        Application.LoadLevel("WingDodger");
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {

    }
}
