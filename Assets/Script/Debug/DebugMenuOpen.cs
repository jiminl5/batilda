using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DebugMenuOpen : MonoBehaviour {
	public GameObject DebugMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print (DebugMenu.activeSelf);
		if (Input.GetKeyDown (KeyCode.BackQuote)) 
		{
			if (!DebugMenu.activeSelf)
				DebugMenu.SetActive(true);
			else
				DebugMenu.SetActive(false);
		}
	}
}