using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingHelper : MonoBehaviour {
    InputField counter;
    Transform switcheroo;

    public int myCounter;
    public bool mySwitch;


    public void Awake() {
        counter = transform.GetComponentInChildren<InputField>();
        if(counter != null)
            myCounter = Convert.ToInt32(counter.text);
    }
    public void CounterIncrease(int i) {
        myCounter += i;
        counter.text = myCounter.ToString();
    }
    public void CounterChange(string i) {
        myCounter = Convert.ToInt32(i);
    }
    public void Switcheroo() {
        mySwitch = !mySwitch;
    }
}
