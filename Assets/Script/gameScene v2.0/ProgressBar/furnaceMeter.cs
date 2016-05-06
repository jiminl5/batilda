using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class furnaceMeter : MonoBehaviour {

    public Transform timeBar;

    private float maxTime;

    // Use this for initialization
    void Start () {
        maxTime = 30f;
	}
	
	// Update is called once per frame
	void Update () {
        timeBar.GetComponent<Image>().fillAmount = Furnace.currentTime_ / maxTime;
    }
}
