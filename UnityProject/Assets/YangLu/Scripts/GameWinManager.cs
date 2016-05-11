using UnityEngine;
using System.Collections;

public class GameWinManager : MonoBehaviour {

    public GameObject player;

    Animator anim;

    float timer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (player.GetComponent<PlayerController>().isWin)
        {
            anim.SetTrigger("GameWin");
            timer += Time.deltaTime;
            if (timer >= 2.3)
            {
                Application.LoadLevel("NextStage");
            }

        }

    }
}
