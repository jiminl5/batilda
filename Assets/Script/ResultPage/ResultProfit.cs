using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultProfit : MonoBehaviour {

    public Text profit_text;
    private bool profit_text_change;
	// Use this for initialization
	void Start () {
        profit_text_change = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if (this.isActiveAndEnabled && profit_text_change)
        {
            profit_text.text = "Profit: <color=#338D74><b>" + PlayerPrefs.GetInt("temp_coin") + "</b></color>g";
            profit_text_change = false;
        }
	}
}
