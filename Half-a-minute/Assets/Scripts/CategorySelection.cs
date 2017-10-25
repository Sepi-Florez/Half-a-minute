using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategorySelection : MonoBehaviour {

    private List<string[]> DatabaseList = new List<string[]>();
    public Transform prefab;
    public Transform Content;

    public void Start() {
        DatabaseList = CSVReader.reader.DatabaseList;
        SpawnCategories();
        //print(DatabaseList.Count);
    }
    public void SpawnCategories() {
        for(int i = 0; i < DatabaseList.Count; i++) { 
            Transform newCategory = Instantiate(prefab);
            newCategory.SetParent(Content, false);
            newCategory.GetComponent<CategoryHelper>().Fill(DatabaseList[i][0]);
            //print(DatabaseList[i][0]);
        }
    }
}
