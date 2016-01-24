using UnityEngine;
using System.Collections;

public class Furnace : MonoBehaviour {
	public bool isOn = false;
	public bool hasFirewood = false;

    public bool playFireLoop = false;

    public AudioClip startFurnace;
    private AudioSource source;

	private float maxTime = 30;
	private float currentTime;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn) {
			currentTime -= Time.deltaTime;
            if (currentTime <= maxTime - 12 & !playFireLoop)
            {
                playFireLoop = true;
                source.Play();
            }
			GameObject.Find ("/Environment Assets/fire_0").GetComponent<SpriteRenderer> ().enabled = true;
		}
		else if (!isOn) {
			GameObject.Find ("/Environment Assets/fire_0").GetComponent<SpriteRenderer> ().enabled = false;
		}
		checkForFirewood ();
	}

	void turnOff() {
		this.GetComponent<SpriteRenderer> ().color = Color.white;
		isOn = false;
	}

	void turnOn() {
        source.PlayOneShot(startFurnace);
		this.GetComponent<SpriteRenderer> ().color = Color.yellow;
		isOn = true;
	}

	void checkForFirewood() {
		if (hasFirewood) {
			turnOn ();
			currentTime = maxTime;
			hasFirewood = false;
		} else if (currentTime <= 0)
        {
            source.Stop();
            turnOff ();
		}
	}
}
