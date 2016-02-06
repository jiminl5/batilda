using UnityEngine;
using System.Collections;

public class BlackBg : MonoBehaviour {

    void OnMouseDown()
    {
        if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count < GameObject.Find("Main Camera").GetComponent<Tutorial>().cap)
        GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
    }
}
