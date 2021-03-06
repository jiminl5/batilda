﻿using UnityEngine;
using System.Collections;

public class Furnace : MonoBehaviour {
    public GameObject FurnaceTimer;

	public bool isOn = false;
	public bool hasFirewood = false;

    public bool playFireLoop = false;

    public AudioClip startFurnace;
	public AudioClip logDrop;
	public AudioClip lightOut;
    private AudioSource source;

	private float maxTime = 30;
	private float currentTime;
    public static float currentTime_;

    private GameObject _smoke;
    private ParticleSystem smoke;
    private bool smokeOn = false;
	private bool played = false;

	public GameObject light;
	private bool lightMaxed = false; // max amt of light is 1.5f intensity
	private bool lightMin = false; // minimum amt of light is .5f intesity

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        _smoke = Instantiate(Resources.Load("Smoke") as GameObject);
        _smoke.transform.parent = transform;
        _smoke.transform.position = transform.position;
        smoke = _smoke.GetComponent<ParticleSystem>();
        smoke.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn) {
            //Furnace Timer Visual - 2016-05-06 by Jimmy
            FurnaceTimer.transform.gameObject.SetActive(true);
			currentTime -= Time.deltaTime;
            currentTime_ = currentTime;
			if ( !playFireLoop) //currentTime <= maxTime - 12 &
            {
                playFireLoop = true;
                source.Play();
            }
			GameObject.Find ("/Environment Assets/fire_0").GetComponent<SpriteRenderer> ().enabled = true;
                smoke.Stop();
                smokeOn = false;
			if (!lightMaxed) {
				increaseLight ();
			}
		}
		else if (!isOn) {
            FurnaceTimer.transform.gameObject.SetActive(false);
            GameObject.Find ("/Environment Assets/fire_0").GetComponent<SpriteRenderer> ().enabled = false;
            if (!smokeOn)
            {
                smoke.Play();
                smokeOn = true;
            }
			if (!lightMin) {
				decreaseLight ();
			}
		}
		checkForFirewood ();
	}

	void turnOff() {
		this.GetComponent<SpriteRenderer> ().color = Color.white;
		isOn = false;
	}

	void turnOn() {
		if(!isOn)
        	source.PlayOneShot(logDrop);
		if (isOn)
			source.PlayOneShot (logDrop);
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

	void lightThresholdReached(){
		if (light.GetComponent<Light> ().intensity >= 1.5f)
			lightMaxed = true;
	}

	void lightBThresholdReached(){
		if (light.GetComponent<Light> ().intensity <= .5f)
			lightMin= true;
	}

	void increaseLight(){
		lightMin = false;
		light.GetComponent<Light> ().intensity += .01f;
		lightThresholdReached ();
	}

	void decreaseLight(){
		lightMaxed = false;
		light.GetComponent<Light> ().intensity -= .01f;
		lightBThresholdReached ();
	}
}
