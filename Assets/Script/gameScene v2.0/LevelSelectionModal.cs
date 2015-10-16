using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class LevelSelectionModal : MonoBehaviour {
	public Button day;
	public Button cancelBtn;
	public GameObject levelSelectionObject;

	private static LevelSelectionModal levelPanel;

	public static LevelSelectionModal Instance(){
		if (!levelPanel) {
			levelPanel = FindObjectOfType(typeof (LevelSelectionModal)) as LevelSelectionModal;
			if(!levelPanel)
				Debug.LogError("An active Level Panel script is required for GameObject in your scene.");
		}
		return levelPanel;
	}

	public void Tempy(Button day, Button cancelBtn, UnityAction selectEvent, UnityAction cancelEvent){
		levelSelectionObject.SetActive (true);

		day.onClick.RemoveAllListeners ();
		day.onClick.AddListener (selectEvent);
		day.onClick.AddListener (CloseLevelSelectionPanel);

		cancelBtn.onClick.RemoveAllListeners ();
		cancelBtn.onClick.AddListener (cancelEvent);
		cancelBtn.onClick.AddListener (CloseLevelSelectionPanel);

		day.gameObject.SetActive (true);
		cancelBtn.gameObject.SetActive (true);
	}

	void CloseLevelSelectionPanel(){
		levelSelectionObject.SetActive (false);
	}

}
