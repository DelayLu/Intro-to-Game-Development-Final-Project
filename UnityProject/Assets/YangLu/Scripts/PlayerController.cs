using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float playerSpeed = 8f;

	public float mouseSensitivity = 2f;

	public float cameraRange = 60f;

	public Light flashlight;

	public GameObject flashlightObject;
    public GameObject fileObject;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject bigLight;

    public GameObject door;


    public float pickUpRange;
	public bool pickupEnable = false;
    public bool pickedUp = false;
    

    public bool filePickupEnable = false;
    public bool filePickedUp = false;

    public Slider healthSlider;


    public float health;


    public AudioClip walkClip;
    public AudioClip flashlightClip;

    bool lightEnable = false;
    bool isLightOn = false;
	float rotationY = 0f;

    public bool isWin = false;
    bool isDead = false;
    bool damaged = false;

    AudioSource playerAudio; 

    float timer;

	void Start () {
		flashlight.enabled = false;

        health = 100f;

        playerAudio = GetComponent<AudioSource>();

        Cursor.visible = false;
	}

	void Update(){

        timer += Time.deltaTime;




        if (filePickedUp && Vector3.Distance(transform.position, door.transform.position) < 5)
        {
            isWin = true;
        }



        //pick up flashlight
        if (Vector3.Distance(transform.position, flashlightObject.transform.position) < pickUpRange && !pickedUp)
        {
            pickupEnable = true;
        }
        else
        {
            pickupEnable = false;
        }

        if (pickupEnable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                flashlightObject.SetActive(false);
                lightEnable = true;
                pickupEnable = false;
                pickedUp = true;
            }
        }

		//use flashlight
        if (Input.GetKeyDown(KeyCode.F) && !isLightOn && lightEnable)
        {
			flashlight.enabled = !flashlight.enabled;
            playerAudio.clip = flashlightClip;
            playerAudio.Play();
		}
        
        //pick up file
        if (Vector3.Distance(transform.position, fileObject.transform.position) < pickUpRange && !filePickedUp)
        {
            filePickupEnable = true;
        }
        else
        {
            filePickupEnable = false;
        }

        if (filePickupEnable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                

                fileObject.SetActive(false);
                filePickupEnable = false;
                filePickedUp = true;
            }
        }
        
        //light control
        if (filePickedUp)
        {
            light1.SetActive(false);
            light2.SetActive(false);
            light3.SetActive(false);
            light4.SetActive(false);
            bigLight.GetComponent<Light>().color = Color.red;
        }




	}


	void FixedUpdate () {
		//rotation
		float rotationX = Input.GetAxis ("Mouse X") * mouseSensitivity;
		rotationY -= Input.GetAxis ("Mouse Y") * mouseSensitivity;


		transform.Rotate (0, rotationX, 0);

		rotationY = Mathf.Clamp(rotationY, -cameraRange, cameraRange);

		Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);


		//movement
		float vSpeed = Input.GetAxis ("Vertical") * playerSpeed;
		float hSpeed = Input.GetAxis ("Horizontal") * playerSpeed;

		Vector3 speed = new Vector3 (hSpeed, 0, vSpeed);

		speed = transform.rotation * speed;

		CharacterController characterController = GetComponent<CharacterController> ();

		characterController.SimpleMove (speed);

        playerAudio.clip = walkClip;

        if (!(characterController.velocity == Vector3.zero) && !playerAudio.isPlaying)
        {
            
            playerAudio.Play();
            
        }
        else if (characterController.velocity == Vector3.zero)
        {
            //playerAudio.clip = walkClip;
            playerAudio.Stop();
        }

        
	}




    public void TakeDamage(float attackDamage)
    {
        damaged = true;

        health -= attackDamage;

        healthSlider.value = health;

        if (health <= 0 && !isDead)
        {
            Dead();
        }

    }


    void Dead()
    {
        playerSpeed = 0f;
        lightEnable = false;

        Application.LoadLevel("EndMenu1");
    }


    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
