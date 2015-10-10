using UnityEngine;
using System.Collections;

public class SpellSheetGUI : MonoBehaviour {
	
	public Texture backgroundTexture;

    /* .1f, */
    public float row1_y, row2_y, row3_y;
    /* .05f, .2f, .35f*/
    public float col1_x, col2_x, col3_x =.11f;
    /*.1f, .1f */
    public float button_height, button_width;
    
    private bool spell_actively_selected = false;
    private string activated_spell = "";

    void OnGUI()
	{
		//Background Texture
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), backgroundTexture);


        //Exit/Back Button
        if (GUI.Button(new Rect(5, 5, Screen.width * button_width, Screen.height * button_height), "Exit"))
        {
            Application.LoadLevel("mainMenu");
        }

        //Spell Buttons
        if (GUI.Button(new Rect(Screen.width*col1_x, Screen.height*row1_y, Screen.width * button_width, Screen.height * button_height), "Heart Charm"))
		{
            spell_actively_selected = true;
            activated_spell = "Heart Charm";
        }
		if (GUI.Button(new Rect(Screen.width * col2_x, Screen.height * row1_y, Screen.width * button_width, Screen.height * button_height), "Speed"))
		{
            spell_actively_selected = true;
            activated_spell = "Speed";
        }
		if (GUI.Button(new Rect(Screen.width * col3_x, Screen.height*row1_y, Screen.width * button_width, Screen.height * button_height), "Slow Time"))
		{
            spell_actively_selected = true;
            activated_spell = "Slow Time";
        }

        if (spell_actively_selected == true)
        {
            display_spell_details(activated_spell);
        }
	}

    void display_spell_details(string spell)
    {
        if(GUI.Button(new Rect(Screen.width * .82f, Screen.height * .82f, 90, 40), spell))
        {
            learn_spell(spell);
        }
    }

    void learn_spell(string spell)
    {
        print(spell);
        //spell_actively_selected = false;
    }
	
}

