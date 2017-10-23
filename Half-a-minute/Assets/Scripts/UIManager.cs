using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text dataList;

    public void LoadData() {
        dataList.text = CSVReader.reader.all;
    }
}
