using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	public int score;
	private bool gameOver;

    public GameObject scoreControllerObj;

    public bool gameWin;

    float timer, timer2;


	//public GUIText scoreText;

	void Start(){
		score = 0;
		gameOver = false;
		updateScore ();
		StartCoroutine (spawnWaves());
        timer2 = 0;

	}

    void Update()
    {
        if (gameOver)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                Application.LoadLevel("EndMenu2");
            }
        }
        
        if (scoreControllerObj.GetComponent<ScoreController>().getScore() >= 200)
        {
            gameWin = true;

        }

       
    }

	IEnumerator spawnWaves()
    {
		yield return new WaitForSeconds (startWait);
		while(true)
        {
			for(int i = 0; i < hazardCount; i++)
            {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition,spawnRotation);	
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

		}
	}

	public void addScore(int newScore){
		score += newScore;
		updateScore ();
	}

	void updateScore(){
		//scoreText.text = "Score: " + score;
	}
	public void GameOver ()
	{
		gameOver = true;
	}
}
