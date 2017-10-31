using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategorySelection : MonoBehaviour {
    public static CategorySelection thisManager;

    public Transform prefab;
    public Transform Content;

    public bool[] categories;
    public static List<int> usingCategories = new List<int>();

    public void Awake() {
        thisManager = this;
    }

    public void Start() {
        categories = new bool[CSVReader.databaseList.Count];
        SpawnCategories();
        //print(CSVReader.databaseList.Count);
    }
    public void SpawnCategories() {
        for (int i = 0; i < CSVReader.databaseList.Count; i++) { 
            Transform newCategory = Instantiate(prefab);
            newCategory.SetParent(Content, false);
            newCategory.GetComponent<CategoryHelper>().Fill(CSVReader.databaseList[i][0], i);
        }
    }
    public void toggleCategory(int i) {
        //print("Tried to toggle: " + i);
        categories[i] = !categories[i];
        if(categories[i] == true) {
            usingCategories.Add(i);
            print("Using " + usingCategories.Count + " Categories.");
        }
        else {
            usingCategories.Remove(i);
        }
    }
}
