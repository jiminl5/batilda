using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Texture backgroundTexture;

    public float button_setting_Y;
    public float button_exit_Y;

    public string scene_name;

    void OnGUI()
    {
        //Background Texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        //GUI Buttons
        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "PLAY"))
        {
            Application.LoadLevel(scene_name);
        }
        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * button_setting_Y, Screen.width * .5f, Screen.height * .1f), "Setting"))
        {
			Application.LoadLevel ("options");
        }
        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * button_exit_Y, Screen.width * .5f, Screen.height * .1f), "Exit"))
        {

        }
    }

}
