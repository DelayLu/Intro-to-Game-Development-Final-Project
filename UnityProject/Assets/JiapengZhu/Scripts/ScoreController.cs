using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public GameObject controllerObject;

	private Text text;
	private int score;

	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
		score = 0;
		text.text = "Score: ";
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: ";
		score = controllerObject.GetComponent<GameController> ().score;
		text.text += score.ToString();
	}

    public int getScore()
    {
        return score;
    }
}
