using UnityEngine;
using System.Collections;

public class meatHandler : MonoBehaviour
{

    private int _meat;

    // Use this for initialization
    void Start()
    {
        _meat = getMeatFromDb();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Meat
    {
        get { return _meat; }
        set { _meat = value; }
    }

    static string Md5Sum(string s)
    {
        s += GameObject.Find("xxmd5").transform.GetChild(0).name;
        print(s);
        System.Security.Cryptography.MD5 hash = System.Security.Cryptography.MD5.Create();
        byte[] data = hash.ComputeHash(System.Text.Encoding.Default.GetBytes(s));

        System.Text.StringBuilder _builder = new System.Text.StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            _builder.Append(data[i].ToString("X2"));
        }
        return _builder.ToString();
    }

    public void saveVal(int val)
    {
        string tmpV = Md5Sum(val.ToString());
        PlayerPrefs.SetString("meat_hash", tmpV);
        PlayerPrefs.SetInt("meat", val);
    }

    private int decrpyt(string val)
    {
        int tmpV = 0;
        if (val == "")
        {
            saveVal(tmpV);
        }
        else
        {
            if (val.Equals(Md5Sum(PlayerPrefs.GetInt("meat").ToString())))
            {
                tmpV = PlayerPrefs.GetInt("meat");
            }
            else {
                saveVal(0); // since data is different or corrupt
            }
        }
        return tmpV;
    }

    private int getMeatFromDb()
    {
        return decrpyt(PlayerPrefs.GetString("meat_hash"));
    }

    public void storeMeat()
    {
        saveVal(_meat);
    }
}
