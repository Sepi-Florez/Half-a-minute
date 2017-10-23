using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour {
    public static CSVReader reader;


    public string path;
    public List<string[]> DatabaseList = new List<string[]>();

    public string all;

    

    private void Start() {
        reader = this;
        Load();
    }
    private void Load() {
        StreamReader file;
        file = File.OpenText(Application.dataPath + path);
        while (!file.EndOfStream) {
            all += file.ReadLine();
        }
        file.Close();
    }
    private void Read() {
        List<string> newWordList = new List<string>();
        string newWord = "";
        int fails = 0;
        for(int i = 0; i < all.Length; i++) {
            if (all[i] != ","[0]) {
                newWord += all[i];
            }
            else {
                newWordList.Add(newWord);
                fails++;
            }
        }
    }
}
