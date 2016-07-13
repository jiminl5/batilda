using UnityEngine;
using System.Collections;

public class cheeseHandler : MonoBehaviour
{

    private int _cheese;

    // Use this for initialization
    void Start()
    {
        _cheese = getCheeseFromDb();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int Cheese
    {
        get { return _cheese; }
        set { _cheese = value; }
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
        PlayerPrefs.SetString("cheese_hash", tmpV);
        PlayerPrefs.SetInt("cheese", val);
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
            if (val.Equals(Md5Sum(PlayerPrefs.GetInt("cheese").ToString())))
            {
                tmpV = PlayerPrefs.GetInt("cheese");
            }
            else {
                saveVal(0); // since data is different or corrupt
            }
        }
        return tmpV; // 0 or cheese value
    }

    private int getCheeseFromDb()
    {
        return decrpyt(PlayerPrefs.GetString("cheese_hash"));
    }

    public void storeCheese()
    {
        saveVal(_cheese);
    }
}
