using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class LevelSelectionModal : MonoBehaviour {
	
    public void loadLevel(string level_number)
    {
        Application.LoadLevel("level" + level_number);
    }
    
    public void loadScene(string scene_name)
    {
        Application.LoadLevel(scene_name);
    }

    public void quitApp()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }
}
