using UnityEngine;
using System.Collections;


public class cuttingObject : MonoBehaviour
{

    public string cutting;


    public bool is_cutting;
    public int timeToCut = 5;
    public int maxContainers;
    public bool allfull;
    public bool is_on;
    public bool full;
    public string stored;
    public int fullContainers;
    public Sprite c_empty;
    public Sprite c_carrot;
    public Sprite c_cheese;
    public Sprite c_onion;
    public Sprite b_empty;
    public Sprite b_carrot;
    public Sprite b_cheese;
    public Sprite b_onion;
    //public Color c;
    // Use this for initialization
    void Start()
    {
        is_cutting = false;
        is_on = false;
        allfull = false;
        full = false;
    }

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = b_carrot;
        checkDough();
        if (is_on)
        {
            this.GetComponent<Animator>().SetBool("on", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("on", false);
        }
    }


    void checkDough()
    {
        if (is_cutting && (!allfull || !full))
        {
            //this.GetComponent<SpriteRenderer> ().color = Color.red;
            //this.GetComponent<stopWatchObject>().startTime = timeToCut;
            //this.GetComponent<stopWatchObject>().timeInSeconds = timeToCut;
            //this.GetComponent<stopWatchObject>().not_cooking = false;
            //print("hello");
            // 0 - grills, 1 - ovens, 2 - cuttingboard, 3 - rolling and so on
            GameObject.Find("Main Camera").GetComponent<timerObject>().genTimerAtLower(4, 0, timeToCut, 3, ""); //2016-02-24 by Jimmy
            Invoke("checkContainers", timeToCut);
            is_cutting = false;
            is_on = true;
            if (maxContainers == fullContainers)
            {
                allfull = true;
            }
            else
            {
                allfull = false;
            }
        }
        if (!full)
        {
            this.GetComponent<Animator>().SetInteger("stored", 0);
        }
    }

    void checkContainers()
    {
        //cuttingPickUp temp;
        print("LENGTH: +++++" + this.gameObject.GetComponentsInChildren<cuttingPickUp>().Length);
        if (!full && allfull)
        {
            full = true;
            stored = "cut_" + cutting;
            if (cutting == "carrot")
            {
                this.GetComponent<Animator>().SetInteger("stored", 1);
                this.GetComponent<nameAndPosition>().go = Resources.Load("Dishes/cut_carrot") as GameObject;
            }
            else if (cutting == "onion")
            {
                this.GetComponent<Animator>().SetInteger("stored", 2);
                this.GetComponent<nameAndPosition>().go = Resources.Load("Dishes/cut_onion") as GameObject;
            }
            else if (cutting == "cheese")
            {
                this.GetComponent<Animator>().SetInteger("stored", 3);
                this.GetComponent<nameAndPosition>().go = Resources.Load("Dishes/cut_cheese") as GameObject;
            }
        }
        else
        {
            foreach (cuttingPickUp cont in this.gameObject.GetComponentsInChildren<cuttingPickUp>())
            {
                if (!cont.full)
                {
                    cont.full = true;
                    cont.stored = "cut_" + cutting;
                    if (cutting == "carrot")
                    {
                        cont.GetComponent<SpriteRenderer>().sprite = c_carrot;
                        cont.GetComponent<nameAndPosition>().go = Resources.Load("Dishes/cut_carrot") as GameObject;
                    }
                    else if (cutting == "onion")
                    {
                        cont.GetComponent<SpriteRenderer>().sprite = c_onion;
                        cont.GetComponent<nameAndPosition>().go = Resources.Load("Dishes/cut_onion") as GameObject;
                    }
                    else if (cutting == "cheese")
                    {
                        cont.GetComponent<SpriteRenderer>().sprite = c_cheese;
                        cont.GetComponent<nameAndPosition>().go = Resources.Load("Dishes/cut_cheese") as GameObject;
                    }
                    fullContainers += 1;
                    break;

                }
            }
        }

        is_cutting = false;
        is_on = false;
        this.GetComponent<SpriteRenderer>().color = Color.white;
        cutting = "";
    }

}
