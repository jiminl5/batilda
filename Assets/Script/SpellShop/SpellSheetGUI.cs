using UnityEngine;
using System.Collections;

public class SpellSheetGUI : MonoBehaviour {
	
	public Texture backgroundTexture;
	
	public float button_graphics_Y;
	public float button_back_Y;


	
	void OnGUI()
	{

		var button = GUI.Button(new Rect (Screen.width * .335f, Screen.height * .33f, Screen.width * .33f, Screen.height * .1f), "hello");

		//Background Texture
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
		
		//GUI Buttons
		if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "Audio & Sound"))
		{
			
		}
		if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * button_graphics_Y, Screen.width * .5f, Screen.height * .1f), "Graphics"))
		{
			
		}
		if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * button_back_Y, Screen.width * .5f, Screen.height * .1f), "Back"))
		{
			Application.LoadLevel("mainMenu");
		}
	}
	
}

