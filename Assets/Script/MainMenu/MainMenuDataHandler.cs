using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuDataHandler : MonoBehaviour {

    private int _coin = 0;
    public Text _coinTxt;

    // Use this for initialization
    void Awake () {
        _coin = PlayerPrefs.GetInt("coin");
        _coinTxt = GameObject.Find("/MainCanvas/Navbar/Background/CoinAmt").GetComponent<Text>();
        _coinTxt.text = _coin.ToString();
    }

}
