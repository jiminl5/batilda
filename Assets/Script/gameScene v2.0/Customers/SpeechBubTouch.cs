using UnityEngine;
using System.Collections;

public class SpeechBubTouch : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("WWWWWWWWWWWWWWWWWWWWWWWWWWW");
        print("mtX: " + this.GetComponentInParent<nameAndPosition>().x + ", mtY: " + this.GetComponentInParent<nameAndPosition>().y);
        GameObject.Find("tmp_invisibleTile1(Clone)").GetComponent<MoveableTile>().SpeechBubDown(this.GetComponentInParent<nameAndPosition>().x, this.GetComponentInParent<nameAndPosition>().y);
    }
}
