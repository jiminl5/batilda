﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;

public class recipeRepository : MonoBehaviour {
    // Use this for initialization
    public ArrayList recipes;
    public string cookingObjectName;

    private ArrayList fileNames;

    void Awake()
    {
        fileNames = new ArrayList();
        recipes = new ArrayList();
    }

	void Start () {
        
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Recipies/Food Recipes");
        FileInfo[] info = dir.GetFiles("*.prefab");
        info.Select(f => f.FullName).ToArray();
        foreach (FileInfo f in info)
        {
            fileNames.Add(f.Name);
        }

        foreach (string food in fileNames)
        {
            //Debug.Log(food);
            GameObject load = Resources.Load("Recipies/Food Recipes/" + food.Split('.')[0]) as GameObject;
            //Debug.Log(cookingObjectName);
            if (cookingObjectName == "all")
            {
                recipes.Add(load.GetComponent<Recipie>());
            }
            if (load.tag == cookingObjectName)
            {
                recipes.Add(load.GetComponent<Recipie>());
                Debug.Log(load.GetComponent<Recipie>().name);
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
