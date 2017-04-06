using UnityEngine;
using System.Collections;

public class storeUpgrades : MonoBehaviour {

    void Start()
    {   //For testing only
        print("Carrot Level: " + PlayerPrefs.GetInt("carrot"));
        print("Carrot Exp: " + PlayerPrefs.GetFloat("carrot_exp"));

        print("Wheat Level: " + PlayerPrefs.GetInt("wheat"));
        print("Wheat Exp: " + PlayerPrefs.GetFloat("wheat_exp"));

        print("Fish Level: " + PlayerPrefs.GetInt("fish"));
        print("Fish Exp: " + PlayerPrefs.GetFloat("fish_exp"));

        print("Beef Level: " + PlayerPrefs.GetInt("beef"));
        print("Beef Exp: " + PlayerPrefs.GetFloat("beef_exp"));

        print("Onion Level: " + PlayerPrefs.GetInt("onion"));
        print("Onion Exp: " + PlayerPrefs.GetFloat("onion_exp"));

        print("Cheese Level: " + PlayerPrefs.GetInt("cheese"));
        print("Cheese Exp: " + PlayerPrefs.GetFloat("cheese_exp"));
    }

    public void Store()
    {
        //Carrot
        PlayerPrefs.SetFloat("carrot_exp", GameObject.Find("CarrotUpgrade").GetComponent<ingreUpgrade>().defaultExp);
        //Wheat
        PlayerPrefs.SetFloat("wheat_exp", GameObject.Find("WheatUpgrade").GetComponent<ingreUpgrade>().defaultExp);
        //Fish
        PlayerPrefs.SetFloat("fish_exp", GameObject.Find("FishUpgrade").GetComponent<ingreUpgrade>().defaultExp);
        //Beef
        PlayerPrefs.SetFloat("beef_exp", GameObject.Find("BeefUpgrade").GetComponent<ingreUpgrade>().defaultExp);
        //Onion
        PlayerPrefs.SetFloat("onion_exp", GameObject.Find("OnionUpgrade").GetComponent<ingreUpgrade>().defaultExp);
        //Cheese
        PlayerPrefs.SetFloat("cheese_exp", GameObject.Find("CheeseUpgrade").GetComponent<ingreUpgrade>().defaultExp);
    }
}
