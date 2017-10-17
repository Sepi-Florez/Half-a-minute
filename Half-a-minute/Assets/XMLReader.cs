using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using UnityEngine;

public class XMLReader : MonoBehaviour {
    public string path;
    public DataTable db = new DataTable();

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
    DataTable Deserialize(TextAsset xmlFile) {
        XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
        using (System.IO.StringReader reader = new System.IO.StringReader(xmlFile.text)) {
            return serializer.Deserialize(reader) as DataTable;
        }
    }
}