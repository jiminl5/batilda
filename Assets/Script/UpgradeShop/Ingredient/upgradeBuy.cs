using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class upgradeBuy : MonoBehaviour {

    public int CoinAmt;

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = CoinAmt.ToString();
	}

    public void Payment()
    {
        if (PlayerPrefs.GetInt("coin") > CoinAmt)
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - CoinAmt);
            GameObject.Find("Main Camera").GetComponent<coinHandler>().Coins -= CoinAmt;
        }
        GameObject.Find("Main Camera").GetComponent<coinHandler>().storeCoin();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("coin") < CoinAmt ||
            this.transform.parent.GetChild(0).GetComponent<Slider>().maxValue >= 7.0f)
        {
            this.transform.parent.GetChild(1).GetComponent<Button>().interactable = false;
        }
        else if (PlayerPrefs.GetInt("coin") > CoinAmt)
        {
            this.transform.parent.GetChild(1).GetComponent<Button>().interactable = true;
        }
    }
}
