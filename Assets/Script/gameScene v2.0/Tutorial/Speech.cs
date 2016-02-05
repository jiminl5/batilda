using UnityEngine;
using System.Collections;

public class Speech : MonoBehaviour {

    void OnMouseDown()
    {
        if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count < GameObject.Find("Main Camera").GetComponent<Tutorial>().cap)
            GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
    }
}
