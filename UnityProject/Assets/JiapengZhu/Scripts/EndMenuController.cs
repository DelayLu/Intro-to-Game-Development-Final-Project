using UnityEngine;
using System.Collections;

public class EndMenuController : MonoBehaviour {

    public string control;


    public void Control()
    {
        Application.LoadLevel(control);
    }
}
