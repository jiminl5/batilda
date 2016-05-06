using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class drinkMeter : MonoBehaviour {

    public Transform timeBar;

    public float tempTime;

    GameObject drinkObj;

    // Use this for initialization
    void Start()
    {
        tempTime = 0;
        drinkObj = this.transform.parent.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (drinkObj.GetComponent<drinkObject>().waitingOnDrink)
        {
            tempTime += Time.deltaTime;
            timeBar.GetComponent<Image>().fillAmount = tempTime / drinkObj.GetComponent<drinkObject>().timeToMakeDrink;
            if (timeBar.GetComponent<Image>().fillAmount >= 1)
            {
                tempTime = 0;
            }
        }
    }
}
