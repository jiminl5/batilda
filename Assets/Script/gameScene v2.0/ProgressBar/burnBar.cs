using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class burnBar : MonoBehaviour
{

    public Transform timeBar;
    float temp_Time;
    float temp_Time_1;
    //public Recipie current_recipe;
    // Use this for initialization
    public float burnTime;
    public int identify_tool;
    private Material mat;
    public string asset_name;
    GameObject fire;
    void Start()
    {
        mat = Resources.Load("Sprite Shader") as Material;
        temp_Time = burnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("furnace").GetComponent<Furnace>().isOn)
        {
            timeBar.GetComponent<Image>().material = null;
            temp_Time -= Time.deltaTime;
            timeBar.GetComponent<Image>().fillAmount = temp_Time / burnTime;
            print(timeBar.GetComponent<Image>().fillAmount);
        }
        else if (!GameObject.Find("furnace").GetComponent<Furnace>().isOn)
        {
            timeBar.GetComponent<Image>().material = mat;
            temp_Time = temp_Time_1;
            timeBar.GetComponent<Image>().fillAmount = temp_Time / burnTime;
        }
        temp_Time_1 = temp_Time;
        if (timeBar.GetComponent<Image>().fillAmount <= 0 || !GameObject.Find(asset_name).GetComponent<cookingObject>().food_ready)
        {
            Destroy(this.transform.parent.parent.gameObject);
        }
        if (!fire)
        {
            fire = Instantiate(Resources.Load("fire") as GameObject);
            fire.transform.position = this.gameObject.transform.position + new Vector3(0,.25f,0);
            fire.transform.parent = this.gameObject.transform;
        }
    }
}
