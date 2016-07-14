using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ingreUpgrade : MonoBehaviour {

    public GameObject ingredientUI;

    public bool _addExp;

    private float increaseAmt = 0.25f;
    private float defaultExp;
	// Use this for initialization
	void Start () {
        _addExp = false;
        ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("carrot") + 2;
        if (this.name == "CarrotUpgrade")
        {
            defaultExp = PlayerPrefs.GetFloat("carrot_exp");
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = defaultExp;
        }
        //print("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ " + PlayerPrefs.GetInt("carrot"));
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
                    this.GetComponent<carrotHandler>().CarrotExp = defaultExp;
                    //this.GetComponent<carrotHandler>().storeCarrotExp();
                }

                _addExp = false;
            }
        }
        if (ingredientUI.transform.GetChild(0).GetComponent<Slider>().value ==
             ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue)
        {
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().value = 0.0f;
            defaultExp = 0.0f;

            if (this.name == "CarrotUpgrade")
            {
                this.GetComponent<carrotHandler>().CarrotExp = defaultExp;
                //this.GetComponent<carrotHandler>().storeCarrotExp();
                if (this.GetComponent<carrotHandler>().Carrot < 5)
                {
                    this.GetComponent<carrotHandler>().Carrot++;
                }
            }
            //this.GetComponent<carrotHandler>().storeCarrot();
            ingredientUI.transform.GetChild(0).GetComponent<Slider>().maxValue = PlayerPrefs.GetInt("carrot") + 2; // Maximum exp increases by 2
        }
    }
}
