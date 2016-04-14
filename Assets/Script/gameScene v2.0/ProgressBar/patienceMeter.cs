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
        patienceTime = 25f; // patience timer
        temp_Time = patienceTime;
        getParent = this.transform.parent.parent.parent;
        _Panimator = getParent.transform.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        temp_Time -= Time.deltaTime;
        timeBar.GetComponent<Image>().fillAmount = temp_Time / patienceTime;
        if (timeBar.GetComponent<Image>().fillAmount < 0.45f && timeBar.GetComponent<Image>().fillAmount > 0 && !angry)
        {
            angry = true;
            AngryAnim();
        }
        if (timeBar.GetComponent<Image>().fillAmount == 0)
        {
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
