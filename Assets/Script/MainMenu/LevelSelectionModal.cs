using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class LevelSelectionModal : MonoBehaviour {
	
    public void loadLevel(string level_number)
    {
        Application.LoadLevel("level" + level_number);
    }
    
}
