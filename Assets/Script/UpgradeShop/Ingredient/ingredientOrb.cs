using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ingredientOrb : MonoBehaviour {

    public Sprite[] img = new Sprite[2];
    public GameObject[] ingredients = new GameObject[6];

	// Use this for initialization
	void Start () {
        SetOrb();
	}
	
    public void SetOrb()
    {
        /**
            Carrot Orb
        **/
        if (PlayerPrefs.GetInt("carrot") == 1)
        {
            ingredients[0].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("carrot") == 2)
        {
            ingredients[0].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("carrot") == 3)
        {
            ingredients[0].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("carrot") == 4)
        {
            ingredients[0].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("carrot") == 5)
        {
            ingredients[0].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
            ingredients[0].transform.GetChild(0).GetChild(4).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("carrot") == 0)
        {
            for (int i = 0; i < ingredients.Length - 1; i++)
            {
                ingredients[0].transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = img[0];
            }
        }

        /**
            Wheat Orb
        **/
        if (PlayerPrefs.GetInt("wheat") == 1)
        {
            ingredients[1].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("wheat") == 2)
        {
            ingredients[1].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("wheat") == 3)
        {
            ingredients[1].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("wheat") == 4)
        {
            ingredients[1].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("wheat") == 5)
        {
            ingredients[1].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
            ingredients[1].transform.GetChild(0).GetChild(4).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("wheat") == 0)
        {
            for (int i = 0; i < ingredients.Length - 1; i++)
            {
                ingredients[1].transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = img[0];
            }
        }

        /**
            Fish Orb
        **/
        if (PlayerPrefs.GetInt("fish") == 1)
        {
            ingredients[2].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("fish") == 2)
        {
            ingredients[2].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("fish") == 3)
        {
            ingredients[2].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("fish") == 4)
        {
            ingredients[2].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("fish") == 5)
        {
            ingredients[2].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
            ingredients[2].transform.GetChild(0).GetChild(4).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("fish") == 0)
        {
            for (int i = 0; i < ingredients.Length - 1; i++)
            {
                ingredients[2].transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = img[0];
            }
        }

        /**
            Beef Orb
        **/
        if (PlayerPrefs.GetInt("beef") == 1)
        {
            ingredients[3].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("beef") == 2)
        {
            ingredients[3].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("beef") == 3)
        {
            ingredients[3].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("beef") == 4)
        {
            ingredients[3].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("beef") == 5)
        {
            ingredients[3].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
            ingredients[3].transform.GetChild(0).GetChild(4).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("beef") == 0)
        {
            for (int i = 0; i < ingredients.Length - 1; i++)
            {
                ingredients[3].transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = img[0];
            }
        }

        /**
            Onion Orb
        **/
        if (PlayerPrefs.GetInt("onion") == 1)
        {
            ingredients[4].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("onion") == 2)
        {
            ingredients[4].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("onion") == 3)
        {
            ingredients[4].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("onion") == 4)
        {
            ingredients[4].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("onion") == 5)
        {
            ingredients[4].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
            ingredients[4].transform.GetChild(0).GetChild(4).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("onion") == 0)
        {
            for (int i = 0; i < ingredients.Length - 1; i++)
            {
                ingredients[4].transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = img[0];
            }
        }

        /**
            Cheese Orb
        **/
        if (PlayerPrefs.GetInt("cheese") == 1)
        {
            ingredients[5].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("cheese") == 2)
        {
            ingredients[5].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("cheese") == 3)
        {
            ingredients[5].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("cheese") == 4)
        {
            ingredients[5].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("cheese") == 5)
        {
            ingredients[5].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = img[1];
            ingredients[5].transform.GetChild(0).GetChild(4).GetComponent<Image>().sprite = img[1];
        }
        if (PlayerPrefs.GetInt("cheese") == 0)
        {
            for (int i = 0; i < ingredients.Length - 1; i++)
            {
                ingredients[5].transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = img[0];
            }
        }
    }
}
