using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using UnityEngine;

public class XMLReader : MonoBehaviour {
    // XML read part //
    public string path;
    public List<string> db = new List<string>();

    private void Start() {
        Load();
    }
    // Loads the XML file
    public void Load() {
        TextAsset n = (TextAsset)Resources.Load(path);
        if (n != null) {
            db = Deserialize(n);
            print("Deserialized!");
        }
        else {
            print("Database file not found");
        }
    }
    //Deserializes the given XML file and returns it as a DataTable;
    List<string> Deserialize(TextAsset xmlFile) {
        XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
        using (System.IO.StringReader reader = new System.IO.StringReader(xmlFile.text)) {
            return serializer.Deserialize(reader) as List<string>;
        }
    }
}
