using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour {
	coinHandler coinHandler;
	// Use this for initialization
	void Start () {
		coinHandler = GameObject.Find ("Main Camera").GetComponent<coinHandler> ();
	}
	
	public void AddCoins() {
		GameObject.Find("Main Camera").GetComponent<coinHandler>().Coins += 1000;
		PlayerPrefs.SetInt ("coin", PlayerPrefs.GetInt("coin") + 1000);
		coinHandler.storeCoin();
	}

	public void ResetCoins() {
		PlayerPrefs.SetInt("coin", 0);
		GameObject.Find("Main Camera").GetComponent<coinHandler>().Coins = 0;
		coinHandler.storeCoin();
	}
}
