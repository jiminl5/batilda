using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ingreUpgrade : MonoBehaviour {

    public GameObject ingredientUI;

    public bool _addExp;
    private bool maxExp;

    private float increaseAmt = 0.25f;
    public float defaultExp;
	// Use this for initialization
	void Start () {
        maxExp = false;
        _addExp = false;
        if (this.name == "CarrotUpgrade")
        {
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("carrot") + 2;
            defaultExp = PlayerPrefs.GetFloat("carrot_exp");
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = defaultExp;
        }
        if (this.name == "WheatUpgrade")
        {
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("wheat") + 2;
            defaultExp = PlayerPrefs.GetFloat("wheat_exp");
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = defaultExp;
        }
        if (this.name == "FishUpgrade")
        {
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("fish") + 2;
            defaultExp = PlayerPrefs.GetFloat("fish_exp");
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = defaultExp;
        }
        if (this.name == "BeefUpgrade")
        {
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("beef") + 2;
            defaultExp = PlayerPrefs.GetFloat("beef_exp");
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = defaultExp;
        }
        if (this.name == "OnionUpgrade")
        {
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("onion") + 2;
            defaultExp = PlayerPrefs.GetFloat("onion_exp");
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = defaultExp;
        }
        if (this.name == "CheeseUpgrade")
        {
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("cheese") + 2;
            defaultExp = PlayerPrefs.GetFloat("cheese_exp");
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = defaultExp;
        }
    }
	
    public void AddExp()
    {
        _addExp = true;
        ingredientUI.transform.GetChild(1).GetComponent<Button>().interactable = false;
    }

	// Update is called once per frame
	void Update () {
	    if (_addExp) // Experience Slider animation
        {
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value += 0.01f;
            if (ingredientUI.transform.GetChild(0).GetComponent<Slider>().value >= defaultExp + increaseAmt)
            {
                ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = defaultExp + increaseAmt;
                defaultExp = ingredientUI.transform.GetChild(0).GetComponent<Slider>().value;
                ingredientUI.transform.GetChild(1).GetComponent<Button>().interactable = true;

                if (this.name == "CarrotUpgrade")
                {
                    PlayerPrefs.SetFloat("carrot_exp", defaultExp);
                }
                if (this.name == "WheatUpgrade")
                {
                    PlayerPrefs.SetFloat("wheat_exp", defaultExp);
                }
                if (this.name == "FishUpgrade")
                {
                    PlayerPrefs.SetFloat("fish_exp", defaultExp);
                }
                if (this.name == "BeefUpgrade")
                {
                    PlayerPrefs.SetFloat("beef_exp", defaultExp);
                }
                if (this.name == "OnionUpgrade")
                {
                    PlayerPrefs.SetFloat("onion_exp", defaultExp);
                }
                if (this.name == "CheeseUpgrade")
                {
                    PlayerPrefs.SetFloat("cheese_exp", defaultExp);
                }

                _addExp = false;
            }
        }

        if (ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue > 6.0f
        && ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue <= 7.0f)
        {
            maxExp = true;
            ingredientUI.transform.GetChild(1).GetComponent<Button>().interactable = false;
        }

        else if (ingredientUI.transform.GetChild(0).GetComponent<Slider>().value ==
             ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue && !maxExp)
        {
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = 0.0f;
            defaultExp = 0.0f;

            if (this.name == "CarrotUpgrade")
            {
                PlayerPrefs.SetFloat("carrot_exp", defaultExp);
                if (PlayerPrefs.GetInt("carrot") < 5)
                {
                    this.GetComponent<ingredientHandler>().Carrot++;
                    GameObject.Find("Main Camera").GetComponent<ingredientOrb>().SetOrb();
                }
                ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("carrot") + 2; // Maximum exp increases by 2
            }
            if (this.name == "WheatUpgrade")
            {
                PlayerPrefs.SetFloat("wheat_exp", defaultExp);
                if (PlayerPrefs.GetInt("wheat") < 5)
                {
                    this.GetComponent<ingredientHandler>().Wheat++;
                    GameObject.Find("Main Camera").GetComponent<ingredientOrb>().SetOrb();
                }
                ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("wheat") + 2; // Maximum exp increases by 2
            }
            if (this.name == "FishUpgrade")
            {
                PlayerPrefs.SetFloat("fish_exp", defaultExp);
                if (PlayerPrefs.GetInt("fish") < 5)
                {
                    this.GetComponent<ingredientHandler>().Fish++;
                    GameObject.Find("Main Camera").GetComponent<ingredientOrb>().SetOrb();
                }
                ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("fish") + 2; // Maximum exp increases by 2
            }
            if (this.name == "BeefUpgrade")
            {
                PlayerPrefs.SetFloat("beef_exp", defaultExp);
                if (PlayerPrefs.GetInt("beef") < 5)
                {
                    this.GetComponent<ingredientHandler>().Beef++;
                    GameObject.Find("Main Camera").GetComponent<ingredientOrb>().SetOrb();
                }
                ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("beef") + 2; // Maximum exp increases by 2
            }
            if (this.name == "OnionUpgrade")
            {
                PlayerPrefs.SetFloat("onion_exp", defaultExp);
                if (PlayerPrefs.GetInt("onion") < 5)
                {
                    this.GetComponent<ingredientHandler>().Onion++;
                    GameObject.Find("Main Camera").GetComponent<ingredientOrb>().SetOrb();
                }
                ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("onion") + 2; // Maximum exp increases by 2
            }
            if (this.name == "CheeseUpgrade")
            {
                PlayerPrefs.SetFloat("cheese_exp", defaultExp);
                if (PlayerPrefs.GetInt("cheese") < 5)
                {
                    this.GetComponent<ingredientHandler>().Cheese++;
                    GameObject.Find("Main Camera").GetComponent<ingredientOrb>().SetOrb();
                }
                ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("cheese") + 2; // Maximum exp increases by 2
            }
        }
    }
}
