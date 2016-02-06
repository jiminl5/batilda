using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VideoToggle : MonoBehaviour {

    public GameObject low;
    public GameObject med;
    public GameObject high;

    private int ini_quality;

    void Start()
    {
       ini_quality = QualitySettings.GetQualityLevel();
        if (ini_quality == 2)
            high.GetComponent<Toggle>().isOn = true;
        else if (ini_quality == 1)
            med.GetComponent<Toggle>().isOn = true;
        else if (ini_quality == 0)
            low.GetComponent<Toggle>().isOn = true;
    }

	// Update is called once per frame
	void Update () {
        if (high.GetComponent<Toggle>().isOn)
        {
            high.GetComponent<Toggle>().interactable = false;
            QualitySettings.SetQualityLevel(2);
        }
        else if (!high.GetComponent<Toggle>().isOn)
            high.GetComponent<Toggle>().interactable = true;

        if (med.GetComponent<Toggle>().isOn)
        {
            med.GetComponent<Toggle>().interactable = false;
            QualitySettings.SetQualityLevel(1);
        }
        else if (!med.GetComponent<Toggle>().isOn)
            med.GetComponent<Toggle>().interactable = true;

        if (low.GetComponent<Toggle>().isOn)
        {
            low.GetComponent<Toggle>().interactable = false;
            QualitySettings.SetQualityLevel(0);
        }
        else if (!low.GetComponent<Toggle>().isOn)
            low.GetComponent<Toggle>().interactable = true;
    }
}
