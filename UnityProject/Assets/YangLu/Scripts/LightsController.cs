using UnityEngine;
using System.Collections;

public class LightsController : MonoBehaviour {



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
        timer += Time.deltaTime;
        while (timer > wait)
        {
            light.enabled = !light.enabled;
            timer = 0;
            wait = Random.Range(0f, 1.5f);
        }

	}
}
