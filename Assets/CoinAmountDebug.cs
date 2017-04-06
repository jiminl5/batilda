using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAmountDebug : MonoBehaviour {
	coinHandler coinHandler;
	// Use this for initialization
	void Start () {
		coinHandler = GameObject.Find ("Main Camera").GetComponent<coinHandler>();
	}

	// Update is called once per frame
	void Update () {
		GetComponent<UnityEngine.UI.Text> ().text = "Coins: " + coinHandler.Coins.ToString();   //PlayerPrefs.GetInt ("coin").ToString(); ;
	}
}
