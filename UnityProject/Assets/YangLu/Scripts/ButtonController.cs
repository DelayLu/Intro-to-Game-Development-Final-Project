using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public string scene;


    void Start()
    {
        Cursor.visible = true;
    }

    public void GoTo()
    {
        if(scene.Equals("quit"))
        {
            Application.Quit();
        }
        else
        {
            Application.LoadLevel(scene);
        }
    }
}
