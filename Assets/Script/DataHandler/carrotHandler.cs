using UnityEngine;
using System.Collections;

public class carrotHandler : MonoBehaviour
{

    private int _carrot;

    // Use this for initialization
    void Start()
    {
        _carrot = getCarrotFromDb();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Carrot
    {
        get { return _carrot; }
        set { _carrot = value; }
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
        PlayerPrefs.SetString("carrot_hash", tmpV);
        PlayerPrefs.SetInt("carrot", val);
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
            if (val.Equals(Md5Sum(PlayerPrefs.GetInt("carrot").ToString())))
            {
                tmpV = PlayerPrefs.GetInt("carrot");
            }
            else {
                saveVal(0); // since data is different or corrupt
            }
        }
        return tmpV;
    }

    private int getCarrotFromDb()
    {
        return decrpyt(PlayerPrefs.GetString("carrot_hash"));
    }

    public void storeCarrot()
    {
        saveVal(_carrot);
    }
}
