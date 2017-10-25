using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour {
    public static CSVReader reader;


    public string path;
    public List<string[]> DatabaseList = new List<string[]>();
    public string all;


    

    private void Awake() {
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
                    DatabaseList.Add(newWordList.ToArray());
                    newWordList.Clear();
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

}
