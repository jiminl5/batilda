using UnityEngine;
using System.Collections;

public class LanternAnim : MonoBehaviour {

    private bool shake;
	// Use this for initialization
	void Start () {
        shake = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (shake)
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
            if (this.gameObject.transform.rotation.eulerAngles.z >= 15.0f && this.gameObject.transform.rotation.eulerAngles.z < 345.0f)
            {
                shake = false;
            }
        }

        else if (!shake)
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, -30) * Time.deltaTime);
            if (this.gameObject.transform.rotation.eulerAngles.z <= 345.0f && this.gameObject.transform.rotation.eulerAngles.z > 15.0f)
            {
                shake = true;
            }
        }
	}
}
