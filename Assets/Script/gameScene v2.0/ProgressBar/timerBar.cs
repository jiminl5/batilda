using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerBar : MonoBehaviour {

    public Transform timeBar;
    float temp_Time;
    float temp_Time_1;
    //public Recipie current_recipe;
    // Use this for initialization
    public float cookingTime;
    public static int identify_tool;

	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("furnace").GetComponent<Furnace>().isOn || (identify_tool == 2 || identify_tool == 3))
        {
            print("IDEDENNENENENEN" + identify_tool);
            temp_Time += Time.deltaTime;
            timeBar.GetComponent<Image>().fillAmount = temp_Time / cookingTime;
        }
        else if (GameObject.Find("furnace").GetComponent<Furnace>().isOn)
        {
            temp_Time = temp_Time_1;
            timeBar.GetComponent<Image>().fillAmount = temp_Time / cookingTime;
        }
        temp_Time_1 = temp_Time;
        if (timeBar.GetComponent<Image>().fillAmount == 1)
        {
            Destroy(this.transform.parent.parent.gameObject);
        }
	}
}
