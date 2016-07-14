using UnityEngine;
using System.Collections;

public class storeUpgrades : MonoBehaviour {


    public void Store()
    {
        GameObject.Find("CarrotUpgrade").GetComponent<carrotHandler>().storeCarrot();
        GameObject.Find("CarrotUpgrade").GetComponent<carrotHandler>().storeCarrotExp();
    }
}
