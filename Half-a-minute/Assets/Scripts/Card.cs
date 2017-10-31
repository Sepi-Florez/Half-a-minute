using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    public Transform wordParent;
    public Transform wordPref;

    public List<List<string>> dataBaseListM = new List<List<string>>();

    public void Start() {
    }
    public void CreateDatabaseList() {
        dataBaseListM.Clear();
        for(int i = 0; i < CategorySelection.usingCategories.Count; i++) {
            dataBaseListM.Add(CSVReader.reader.ConvertList<string>(CSVReader.databaseList[CategorySelection.usingCategories[i]]));
        }
    }
    public void NewCard() {
        if(dataBaseListM.Count != 0) {
            foreach (Transform child in wordParent) {
                Destroy(child.gameObject);
            }
            for (int i = 0; i < SettingsManager.thisManager.mySettings[0].myCounter; i++) {
                Transform newWord = Instantiate(wordPref);
                newWord.SetParent(wordParent, false);
                newWord.GetComponent<Text>().text = RandomWord();
            }
        }
        else {
            print("There were not enough categories to make a card");
        }
    }
    public string RandomWord() {
        string newWord = "";
        int rngC = Random.Range(0, dataBaseListM.Count);
        int rngW = Random.Range(1, dataBaseListM[rngC].Count);
        //print("Random category index: " + rngC);
        //print("Random word index: " + rngW);
        newWord = dataBaseListM[rngC][rngW];
        dataBaseListM[rngC].RemoveAt(rngW);
        if (dataBaseListM[rngC].Count == 1) {
            dataBaseListM.RemoveAt(rngC);
            if (dataBaseListM.Count == 0) {
                CreateDatabaseList();
            }
        }
        print(newWord);
        return newWord;
    }
}
