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
        Read();
    }
    private void Load() {
        TextAsset file = Resources.Load(path) as TextAsset;
        all = file.text;
        /*StreamReader file;
        file = File.OpenText(GetPath());
        while (!file.EndOfStream) {
            all += file.ReadLine();
        }
        file.Close();
        */
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
                print(newWord);
                newWord = "";
                fails++;
                if(fails == 2) {
                    DatabaseList.Add(newWordList.ToArray());
                    newWordList.Clear();
                    fails = 0;
                }
            }
        }
    }
    private string GetPath() {


#if UNITY_STANDALONE

        return Application.dataPath + path;

#endif

#if UNITY_ANDROID || UNITY_IOS

        return Application.persistentDataPath + path;
#endif
    }

}
