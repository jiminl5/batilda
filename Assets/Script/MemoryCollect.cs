using UnityEngine;
using System.Collections;

public class MemoryCollect : MonoBehaviour {

	// Use this for initialization
	void Update () {
        if (Time.frameCount % 30 == 0)
        {
            System.GC.Collect();
        }
	}
}
