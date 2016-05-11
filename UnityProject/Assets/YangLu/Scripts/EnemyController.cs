using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public GameObject player;

    public float speed;

    public float rotationSpeed;

    public float attackDamage;
    public float attackRange;


    public float timeBetweenAttacks = 1f;
    public float damage = 10f;


    public AudioClip attackClip;
    AudioSource attackAudio; 


    float timer;



    // Use this for initialization
    void Start()
    {
        attackAudio = GetComponent<AudioSource>();
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer > timeBetweenAttacks && Vector3.Distance(transform.position, player.transform.position) <= attackRange && !attackAudio.isPlaying)
        {
            Attack();
            attackAudio.Play();
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        transform.GetComponent<Rigidbody>().MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime));


        if (player.GetComponent<PlayerController>().filePickedUp)
        {
            transform.GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }

    }




    void Attack()
    {
        timer = 0f;

        if (player.GetComponent<PlayerController>().health > 0)
        {
            player.GetComponent<PlayerController>().TakeDamage(attackDamage);
        }



    }
}
