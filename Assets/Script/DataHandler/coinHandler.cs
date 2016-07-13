using UnityEngine;
using System.Collections;

public class coinHandler : MonoBehaviour {

    private int _coin;

	// Use this for initialization
	void Start () {
        _coin = getCoinFromDb();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /*
    void OnGUI()
    {
        GUI.color = Color.red;
        GUIStyle _style = GUI.skin.GetStyle("Label");
        _style.alignment = TextAnchor.UpperCenter;
        _style.fontSize = 20;
        GUI.Label(new Rect(20, 20, 500, 200), "COINS: " + _coin.ToString(), _style);
    }
    */
    public int Coins { // Amt of Coins e.g. Coins++ means add 1 to coin used in Level.cs
        get { return _coin;}
        set { _coin = value; }
    }

    static string Md5Sum(string s)
    {
        s += GameObject.Find("xxmd5").transform.GetChild(0).name;
        print(s);
        System.Security.Cryptography.MD5 hash = System.Security.Cryptography.MD5.Create();
        byte[] data = hash.ComputeHash(System.Text.Encoding.Default.GetBytes(s));

        System.Text.StringBuilder _builder = new System.Text.StringBuilder();
        for(int i = 0; i < data.Length; i++)
        {
            _builder.Append(data[i].ToString("X2"));
        }
        return _builder.ToString();
    }

    public void saveVal(int val)
    {
        string tmpV = Md5Sum(val.ToString());
        PlayerPrefs.SetString("coin_hash", tmpV);
        PlayerPrefs.SetInt("coin", val);
    }

    private int decrpyt(string val)
    {
        int tmpV = 0;
        if(val == "") {
            saveVal(tmpV);
        }
        else
        {
            if (val.Equals(Md5Sum(PlayerPrefs.GetInt("coin").ToString())))
            {
                tmpV = PlayerPrefs.GetInt("coin");
            }
            else {
                saveVal(0); // since data is different or corrupt
            }
        }
        return tmpV; // 0 or coin value
    }

    private int getCoinFromDb()
    {
        return decrpyt(PlayerPrefs.GetString("coin_hash"));
    }

    public void storeCoin()
    {
        saveVal(_coin);
    }
}
