using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour {
    public static CSVReader reader;


    public string path;
    public static List<List<string>> databaseList = new List<List<string>>();
    public string all;


    

    private void Awake() {
        reader = this;
        Load();
        Read();
        print("The database I created has " + databaseList.Count + " Categories and " + databaseList[0].Count + " in the first category");
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
            if (all[i].Equals('\n')) {
                continue;
            }
            if (all[i] != ","[0]) {
                newWord += all[i];
                fails = 0;
            }
            else{
                fails++;
                if (fails > 2) {
                    continue;
                }
                else if(fails == 2){
                    databaseList.Add(ConvertList<string>(newWordList));
                    //print("The previous category added has : " + databaseList[databaseList.Count - 1].Count);
                    newWordList.Clear();
                    //print("but now has " + databaseList[databaseList.Count - 1].Count);
                    //print("NEw list!");
                    continue;
                }
                else if(newWord != "" || newWord!=" ") { 
                    newWordList.Add(newWord);
                    //print(newWord);
                    newWord = "";

                }
            }
        }
    }
    public  List<string> ConvertList<T>(List<string> convertable) {
        List<string> ret = new List<string>();
        foreach (string transgender in convertable)
            ret.Add(transgender);
        return ret;
    }

}
