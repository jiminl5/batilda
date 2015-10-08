using UnityEngine;
using System.Collections;

public class AIwalking : MonoBehaviour {
	public GameObject person;
	public float y_top_range;
	public float y_bottom_range;
	public float x_start_position;
	public float spawnTime = 3f;
	// Use this for initialization
	void Start () {
		Invoke("CreateAI", spawnTime);
	}
	

	// Update is called once per frame
	void Update () {

	}
	void CreateAI () 
	{
		float randomTime = Random.Range (1, 3);
		Object newPerson = Instantiate (person, new Vector3(x_start_position, Random.Range (y_bottom_range, y_top_range), 0), Quaternion.identity);
		Invoke("CreateAI", randomTime);
	}

}
