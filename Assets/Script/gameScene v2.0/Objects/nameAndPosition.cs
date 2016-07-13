using UnityEngine;
using System.Collections;

public class nameAndPosition : MonoBehaviour {
	public string name;
	public int x;
	public int y;
	public GameObject go;
    public GameObject[] tier = new GameObject[3]; // # of tiers
    private int _tier;

    void Awake()
    {
        if (go)
        {
            if (go.name == "cheese")
            {
                _tier = PlayerPrefs.GetInt("cheese");
                this.GetComponent<SpriteRenderer>().sprite = tier[_tier].GetComponent<SpriteRenderer>().sprite;
                go.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
            }
            if (go.name == "meat")
            {
                _tier = PlayerPrefs.GetInt("meat");
                this.GetComponent<SpriteRenderer>().sprite = tier[_tier].GetComponent<SpriteRenderer>().sprite;
                go.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
            }
            if (go.name == "fish")
            {
                _tier = PlayerPrefs.GetInt("fish");
                this.GetComponent<SpriteRenderer>().sprite = tier[_tier].GetComponent<SpriteRenderer>().sprite;
                go.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
            }
            if (go.name == "onion")
            {
                _tier = PlayerPrefs.GetInt("onion");
                this.GetComponent<SpriteRenderer>().sprite = tier[_tier].GetComponent<SpriteRenderer>().sprite;
                go.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
            }
            if (go.name == "wheat")
            {
                _tier = PlayerPrefs.GetInt("wheat");
                this.GetComponent<SpriteRenderer>().sprite = tier[_tier].GetComponent<SpriteRenderer>().sprite;
                go.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
            }
            if (go.name == "carrot")
            {
                _tier = PlayerPrefs.GetInt("carrot");
                this.GetComponent<SpriteRenderer>().sprite = tier[_tier].GetComponent<SpriteRenderer>().sprite;
                go.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
