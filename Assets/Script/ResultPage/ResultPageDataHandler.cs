using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultPageDataHandler : MonoBehaviour {

    private int _coin = 0;
    public Text _coinTxt;

    private int _tempCoin = 0;
    public Text _tempCoinTxt;
    private int _coinDisplay = 0;

    private bool not_zero;

    public AudioClip _coinSound;
    private AudioSource audio;

    public int count;
    void Awake()
    {
        count = 0;
        _coin = PlayerPrefs.GetInt("coin") - PlayerPrefs.GetInt("temp_coin");
//        _coinTxt = GameObject.Find("/Misc Canvas/Nav_Panel/Navbar/Background/CoinAmt").GetComponent<Text>();
//        _coinTxt.text = _coin.ToString();

        _tempCoin = PlayerPrefs.GetInt("temp_coin");
        _tempCoinTxt = GameObject.Find("/Right_Canvas/Right_Panel/row2/CoinAmt_Inst").GetComponent<Text>();
        _tempCoinTxt.text = _coinDisplay.ToString();
        //_tempCoinTxt.text = _tempCoin.ToString();

        if (_tempCoin == 0)
            not_zero = false;
        else
            not_zero = true;
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(not_zero && GameObject.Find("results_parchment_right").GetComponent<ResultRight>().countdown_ready
        && (0.0f - Time.time % 0.5f == 0) && Time.timeSinceLevelLoad >= 2.0f)
        {
            _coin += _tempCoin / _tempCoin;
            //_coinTxt.text = _coin.ToString();
            _tempCoin -= 1;
            _coinDisplay += 1;
            _tempCoinTxt.text = _coinDisplay.ToString();
            //tempCoinTxt.text = _tempCoin.ToString();
            audio.PlayOneShot(_coinSound);
            count += 1;
            if (_tempCoin == 0)
            {
                not_zero = false;
            }
        }
    }
}
