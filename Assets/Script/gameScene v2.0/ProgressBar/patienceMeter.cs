using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class patienceMeter : MonoBehaviour {

    public Transform timeBar;
    public Transform getParent;
    float temp_Time;
    float patienceTime;
    bool angry;

    //Animation
    private int _PeasantState = Animator.StringToHash("Peasant_State");
    private Animator _Panimator;

    // Use this for initialization
    void Start () {
        angry = false;
        //patienceTime = 30f; // patience timer
        getParent = this.transform.parent.parent.parent;
        if (getParent.name == "Peasant 1(Clone)")
        {
            patienceTime = 40f;
            print("Spawned Pessant, timer at: " + patienceTime);
        }
        else if (getParent.name == "Artisan 1(Clone)")
        {
            patienceTime = 55f;
            print("Spawned Artisan, timer at: " + patienceTime);
        }
        else if (getParent.name == "Middle Class 1(Clone)")
        {
            patienceTime = 80f;
            print("Spawned Middle Class, timer at: " + patienceTime);
        }
        else if (getParent.name == "Noble 1(Clone)")
        {
            patienceTime = 100f;
            print("Spawned Noble, timer at: " + patienceTime);
        }
        temp_Time = patienceTime;
        _Panimator = getParent.transform.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (_Panimator.GetInteger(_PeasantState) != 5)
        {
            temp_Time -= Time.deltaTime;
            timeBar.GetComponent<Image>().fillAmount = temp_Time / patienceTime;
        }
        if (timeBar.GetComponent<Image>().fillAmount < 0.45f && timeBar.GetComponent<Image>().fillAmount > 0 && !angry)
        {
            angry = true;
            AngryAnim();
        }
        if (timeBar.GetComponent<Image>().fillAmount == 0)
        {
            getParent.GetChild(1).gameObject.GetComponent<Customer>().SetAnger();
            getParent.GetChild(1).gameObject.GetComponent<Customer>().DestroyFoodSprite();
            getParent.GetChild(1).gameObject.GetComponent<Customer>().CustomerExit();
            Destroy(this.transform.parent.parent.gameObject);
        }
    }

    void AngryAnim()
    {
        _Panimator.SetInteger(_PeasantState, 4);
    }
}
