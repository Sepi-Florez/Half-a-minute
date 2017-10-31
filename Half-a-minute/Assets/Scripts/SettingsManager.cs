using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {
    public static SettingsManager thisManager;
    public SettingHelper[] mySettings;

    public void Awake() {
        thisManager = this;
    }
    public void Start() {
        mySettings = transform.GetComponentsInChildren<SettingHelper>();
    }

}
