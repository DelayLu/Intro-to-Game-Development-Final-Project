using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RequestController : MonoBehaviour {


    public GameObject player;

    Text text;




	// Use this for initialization
	void Start () {


        text = GetComponent<Text>();
        text.text = "Find the file(0/1)";

	}
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<PlayerController>().filePickedUp)
        {
            text.text = "Find the file(1/1)\nGuardians coming\nRUN!!";
        }


	}
}
