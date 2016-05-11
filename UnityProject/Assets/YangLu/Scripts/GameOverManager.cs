using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    public GameObject player;
  
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (player.GetComponent<PlayerController>().health <= 0)
        {
            anim.SetTrigger("GameOver");

            
        }
    }
}
