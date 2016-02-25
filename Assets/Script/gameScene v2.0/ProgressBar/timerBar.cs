using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerBar : MonoBehaviour {

    public Transform timeBar;
    float temp_Time;
    //public Recipie current_recipe;
    // Use this for initialization
    public float cookingTime;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        temp_Time += Time.deltaTime;
        timeBar.GetComponent<Image>().fillAmount = temp_Time / cookingTime;
        if (timeBar.GetComponent<Image>().fillAmount == 1)
        {
            Destroy(this.transform.parent.parent.gameObject);
        }
	}
}
