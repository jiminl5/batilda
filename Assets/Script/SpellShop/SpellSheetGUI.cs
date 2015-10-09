using UnityEngine;
using System.Collections;

public class SpellSheetGUI : MonoBehaviour {
	
	public Texture backgroundTexture;

    public float row1_y, row2_y, row3_y;
    public float col1_x, col2_x, col3_x =.11f;
    public float button_height, button_width;

    void OnGUI()
	{
		//Background Texture
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), backgroundTexture);
		
		//GUI Buttons
		if (GUI.Button(new Rect(Screen.width*col1_x, Screen.height*row1_y, Screen.width * button_width, Screen.height * button_height), "Heart Charm"))
		{
			
		}
		if (GUI.Button(new Rect(Screen.width * col2_x, Screen.height * row1_y, Screen.width * button_width, Screen.height * button_height), "Speed Skill"))
		{
			
		}
		if (GUI.Button(new Rect(Screen.width * col3_x, Screen.height*row1_y, Screen.width * button_width, Screen.height * button_height), "Slow Time"))
		{

		}
	}
	
}

