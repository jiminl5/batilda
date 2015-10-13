using UnityEngine;
using System.Collections;

public class AIwalking_movement : MonoBehaviour {
	public int x_direction; //positive to right, negative to left
	public int x_boundary = 10;
	private float random_x_speed;
	//private float random_x_speed = Random.Range (1.0f, 2.0f);
	// Use this for initialization
	void Start () {
		random_x_speed = Random.Range (1.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate((Vector3.right * 2*x_direction * random_x_speed) * Time.deltaTime);
		if (x_direction == -1) 
		{
			transform.localScale = new Vector3(1,1,1);
			if (transform.position.x < x_boundary * x_direction) 
			{
				Destroy (this.gameObject);
			}
		} 
		else 
		{
			transform.localScale = new Vector3(-1,1,1);
			if (transform.position.x > x_boundary)
			{
				Destroy (this.gameObject);
			}
		}
	}
}
