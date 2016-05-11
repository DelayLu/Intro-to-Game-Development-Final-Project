using UnityEngine;
using System.Collections;

public class BigLightController : MonoBehaviour {
    

    public GameObject player;

    float blinkingTime;

    Light light;
    float timer;
    float wait;


	// Use this for initialization
	void Start () {
        light = this.GetComponent<Light>();
        wait = 0.1f;
 
	}
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<PlayerController>().filePickedUp)
        {
            light.color = Color.red;
            timer += Time.deltaTime;
            while (timer > wait)
            {
                light.enabled = !light.enabled;
                timer = 0;
                wait = 1f;
            }
        }
        else
        {
            timer += Time.deltaTime;
            while (timer > wait)
            {
                light.enabled = !light.enabled;
                timer = 0;
                wait = Random.Range(0f, 2f);
            }

        }


	}
    

}
