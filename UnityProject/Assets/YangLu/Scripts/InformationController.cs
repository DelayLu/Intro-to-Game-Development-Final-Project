using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InformationController : MonoBehaviour {


    public GameObject player;

    Text text;

    bool showFlashlightText;
    bool showFileText;

    /*
    void Awake()
    {
        
    }
    */




	// Use this for initialization
	void Start () {
        // Set up the reference.
        text = GetComponent<Text>();

        showFlashlightText = true;
        showFileText = true;
	}
	
	// Update is called once per frame
	void Update () {

        //pick up flashlight information
        if (player.GetComponent<PlayerController>().pickupEnable && showFlashlightText)
        {
            text.text = "Press E to pick up flashlight";
        }
        else if (!player.GetComponent<PlayerController>().pickupEnable)
        {
            text.text = "";
        }

        if (player.GetComponent<PlayerController>().pickedUp && showFlashlightText)
        {
            text.text = "Press F to use flashlight";
        }

        if (player.GetComponent<PlayerController>().pickedUp && Input.GetKeyDown(KeyCode.F))
        {
            text.text = "";
            showFlashlightText = false;
        }

        
        //pick up file information
        if (player.GetComponent<PlayerController>().filePickupEnable)
        {
            showFileText = true;
            text.text = "Press E to pick up file";

            if (Input.GetKeyDown(KeyCode.E))
            {
                text.text = "";
                showFileText = false;
            }
        }
        else if (!player.GetComponent<PlayerController>().filePickupEnable)
        {
            showFileText = false;
        }
        

	}
}
