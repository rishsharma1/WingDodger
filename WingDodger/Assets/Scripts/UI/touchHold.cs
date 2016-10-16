using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class touchHold : MonoBehaviour {

    public Image ButtonBackground;
    public Slider abilitySlider;
    public GameObject pauseButton;

    Rigidbody rBody;
    GameObject stealthBomber;
    BomberController bController;
    pauseButton pButton;

    bool holding;
    bool velocityReset;
   
    

    // Use this for initialization
    void Start () {

        stealthBomber = GameObject.Find("stealth bomber 2");
        rBody = stealthBomber.GetComponent<Rigidbody>();
        pButton = pauseButton.GetComponent<pauseButton>();

        SetTransparency(0);
        holding = false;
        velocityReset = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!pButton.Paused)
        {

            if (holding)
            {
                if (abilitySlider.value <= 0.0f && !velocityReset)
                {
                    rBody.velocity *= 2;
                    velocityReset = true;
                }
                abilitySlider.value -= 0.005f;

            }

            else
            {
                abilitySlider.value += 0.0005f;
                velocityReset = false;
            }
        }
        else
        {

        }


    }


    public void  SetTransparency(float transparency)
    { //transparency is a value in the [0,1] range
        Color color = ButtonBackground.color;
        color.a = transparency;
        ButtonBackground.color = color;
    }

    /// <summary>
    /// When pressing on the screen touch area
    /// </summary>
    public void touchHoldingScreen()
    {

        //DebugConsole.Log(""+abilitySlider.value, "normal");

        if (!holding && abilitySlider.value > 0.0f )
        {
            rBody.velocity *= 0.5f;
        }


        holding = true;

    }

    /// <summary>
    /// When letting go from pressing on the screen touch area
    /// </summary>
    public void letGoScreen()
    {
        if (abilitySlider.value > 0.0f)
        {
            rBody.velocity *= 2f;

        }
        holding = false;
    }
}
