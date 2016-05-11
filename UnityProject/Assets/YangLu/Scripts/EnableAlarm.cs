using UnityEngine;
using System.Collections;

public class EnableAlarm : MonoBehaviour {


    public GameObject player;

    public AudioClip alarmClip;
    AudioSource alarmAudio; 

	// Use this for initialization
	void Start () {
        alarmAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<PlayerController>().filePickedUp && !alarmAudio.isPlaying)
        {
            alarmAudio.Play();
        }
	}
}
