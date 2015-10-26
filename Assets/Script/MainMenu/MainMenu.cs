using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//Background Texture
    //public Texture backgroundTexture;

	//GUI Button Texture
	public Texture texture_Tavern;
	public Texture texture_Potion;
	public Texture texture_Settings;

	//Non-Static Button Coordinate Variable (X)
	public float button_tavern_X = .25f; // Xs are initialized at .25f
	public float button_setting_X = .25f;
	public float button_potion_X = .25f;

	//Non-Static Button Coordinate Variable (Y)
	public float button_tavern_Y;
    public float button_setting_Y;
    public float button_potion_Y;

	//Non-Static Button Size Variable (W)
	public float button_tavern_W;
	public float button_setting_W;
	public float button_potion_W;

	//Non-Static Button Size Variable (H)
	public float button_tavern_H;
	public float button_setting_H;
	public float button_potion_H;

    public string scene_name;

	//Cam Size & Zoom effects
	public float camSize;
	public float camSizeLimit;
	public bool ZoomIn = false;
	public float increment;
	
	void Start()
	{
		camSize = Camera.main.orthographicSize; // initialize camsize
	}

	void Update()
	{
		ZoomCamera ();
	}

    void OnGUI()
    {
        //Background Texture
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        //GUI Buttons
		if (GUI.Button(new Rect(Screen.width * button_tavern_X, Screen.height * button_tavern_Y,
		                        Screen.width * button_tavern_W, Screen.height * button_tavern_H), texture_Tavern, "")) // No Text, Only Texture in the future
        {
			//print (this.transform.position);
			ZoomIn = true;
			//ZoomCamera();
            //Application.LoadLevel(scene_name);
        }
		if (GUI.Button(new Rect(Screen.width * button_setting_X, Screen.height * button_setting_Y,
		                        Screen.width * button_setting_W, Screen.height * button_setting_H), texture_Settings, ""))
        {
			Application.LoadLevel ("options");
        }
		if (GUI.Button(new Rect(Screen.width * button_potion_X, Screen.height * button_potion_Y,
		                        Screen.width * button_potion_W, Screen.height * button_potion_H), texture_Potion, ""))
        {

        }
    }

	void ZoomCamera()
	{
		if (ZoomIn) {
			Camera.main.orthographicSize = 
				Mathf.Lerp (Camera.main.orthographicSize,
				            Camera.main.orthographicSize - increment,
				            Time.deltaTime * 2);

			Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y - 0.048f, transform.position.z); // Fix Camera position while zoom (to Tavern Door)

			print (Camera.main.orthographicSize);

			if (Camera.main.orthographicSize <= 0.1f) {
				ZoomIn = false;
				Application.LoadLevel(scene_name);
			}
		}
	}

}
