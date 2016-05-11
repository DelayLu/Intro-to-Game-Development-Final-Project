using UnityEngine;
using System.Collections;

public class WinManager : MonoBehaviour {

    public GameObject gameControllerObj;

    Animator anim;

    float timer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	//based on realtime
    void FixedUpdate()
    {
        if (gameControllerObj.GetComponent<GameController>().gameWin)
        {
            anim.SetTrigger("GameWin");
            timer += Time.deltaTime;
            if (timer >= 0.6)
            {
                Application.LoadLevel("GameWin");
            }

        }

    }
}
