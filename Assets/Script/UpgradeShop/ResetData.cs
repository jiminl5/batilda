using UnityEngine;
using System.Collections;

public class ResetData : MonoBehaviour {

    public void Reset()
    {
        //Carrot
        PlayerPrefs.SetInt("carrot", 0);
        PlayerPrefs.SetFloat("carrot_exp", 0.0f);
        //Wheat
        PlayerPrefs.SetInt("wheat", 0);
        PlayerPrefs.SetFloat("wheat_exp", 0.0f);
        //Fish
        PlayerPrefs.SetInt("fish", 0);
        PlayerPrefs.SetFloat("fish_exp", 0.0f);
        //Beef
        PlayerPrefs.SetInt("beef", 0);
        PlayerPrefs.SetFloat("beef_exp", 0.0f);
        //Onion
        PlayerPrefs.SetInt("onion", 0);
        PlayerPrefs.SetFloat("onion_exp", 0.0f);
        //Cheese
        PlayerPrefs.SetInt("cheese", 0);
        PlayerPrefs.SetFloat("cheese_exp", 0.0f);
    }

}
