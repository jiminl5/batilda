using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class testModalPanel : MonoBehaviour {
    private LevelSelectionModal modalPanel;

    void Awake()
    {
        modalPanel = LevelSelectionModal.Instance();
    }

    //Send to Modal Panel to set up Buttons and Functions to CALL


    void TestCancelFunction()
    {

    }
}
