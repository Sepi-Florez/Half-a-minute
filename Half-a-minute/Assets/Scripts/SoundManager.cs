using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager thisManager;

    private void Awake() {
        thisManager = this;
    }
    public AudioSource source;

    public void PlaySound() {
        if(SettingsManager.thisManager.mySettings[2].mySwitch == false) {
            source.Play();
        }
    }
}
