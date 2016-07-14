using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ingredientIconTier : MonoBehaviour {

    public GameObject[] ingredientIcon = new GameObject[6];

    public Sprite[] carrotIcon = new Sprite[3];
    public Sprite[] wheatIcon = new Sprite[3];
    public Sprite[] fishIcon = new Sprite[3];
    public Sprite[] beefIcon = new Sprite[3];
    public Sprite[] onionIcon = new Sprite[3];
    public Sprite[] cheeseIcon = new Sprite[3];

    private int carrot_tier;
    private int wheat_tier;
    private int fish_tier;
    private int beef_tier;
    private int onion_tier;
    private int cheese_tier;

    void Start()
    {
        changeIconTier();
    }

    public void changeIconTier()
    {
        //Carrot
        if (PlayerPrefs.GetInt("carrot") < 2)
            ingredientIcon[0].transform.GetChild(2).GetComponent<Image>().sprite = carrotIcon[0];
        else if (PlayerPrefs.GetInt("carrot") >= 2 && PlayerPrefs.GetInt("carrot") < 5)
            ingredientIcon[0].transform.GetChild(2).GetComponent<Image>().sprite = carrotIcon[1];
        else if (PlayerPrefs.GetInt("carrot") == 5)
            ingredientIcon[0].transform.GetChild(2).GetComponent<Image>().sprite = carrotIcon[2];

        //Wheat
        if (PlayerPrefs.GetInt("wheat") < 2)
            ingredientIcon[1].transform.GetChild(2).GetComponent<Image>().sprite = wheatIcon[0];
        else if (PlayerPrefs.GetInt("wheat") >= 2 && PlayerPrefs.GetInt("wheat") < 5)
            ingredientIcon[1].transform.GetChild(2).GetComponent<Image>().sprite = wheatIcon[1];
        else if (PlayerPrefs.GetInt("wheat") == 5)
            ingredientIcon[1].transform.GetChild(2).GetComponent<Image>().sprite = wheatIcon[2];

        //Fish
        if (PlayerPrefs.GetInt("fish") < 2)
            ingredientIcon[2].transform.GetChild(2).GetComponent<Image>().sprite = fishIcon[0];
        else if (PlayerPrefs.GetInt("fish") >= 2 && PlayerPrefs.GetInt("fish") < 5)
            ingredientIcon[2].transform.GetChild(2).GetComponent<Image>().sprite = fishIcon[1];
        else if (PlayerPrefs.GetInt("fish") == 5)
            ingredientIcon[2].transform.GetChild(2).GetComponent<Image>().sprite = fishIcon[2];

        //Beef
        if (PlayerPrefs.GetInt("beef") < 2)
            ingredientIcon[3].transform.GetChild(2).GetComponent<Image>().sprite = beefIcon[0];
        else if (PlayerPrefs.GetInt("beef") >= 2 && PlayerPrefs.GetInt("beef") < 5)
            ingredientIcon[3].transform.GetChild(2).GetComponent<Image>().sprite = beefIcon[1];
        else if (PlayerPrefs.GetInt("beef") == 5)
            ingredientIcon[3].transform.GetChild(2).GetComponent<Image>().sprite = beefIcon[2];

        //Onion
        if (PlayerPrefs.GetInt("onion") < 2)
            ingredientIcon[4].transform.GetChild(2).GetComponent<Image>().sprite = onionIcon[0];
        else if (PlayerPrefs.GetInt("onion") >= 2 && PlayerPrefs.GetInt("fish") < 5)
            ingredientIcon[4].transform.GetChild(2).GetComponent<Image>().sprite = onionIcon[1];
        else if (PlayerPrefs.GetInt("onion") == 5)
            ingredientIcon[4].transform.GetChild(2).GetComponent<Image>().sprite = onionIcon[2];

        //Cheese
        if (PlayerPrefs.GetInt("cheese") < 2)
            ingredientIcon[5].transform.GetChild(2).GetComponent<Image>().sprite = cheeseIcon[0];
        else if (PlayerPrefs.GetInt("cheese") >= 2 && PlayerPrefs.GetInt("cheese") < 5)
            ingredientIcon[5].transform.GetChild(2).GetComponent<Image>().sprite = cheeseIcon[1];
        else if (PlayerPrefs.GetInt("cheese") == 5)
            ingredientIcon[5].transform.GetChild(2).GetComponent<Image>().sprite = cheeseIcon[2];
    }
}
