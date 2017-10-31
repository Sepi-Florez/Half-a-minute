using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timerText;
    public Image timerImag;

    public Text ButtonText;

    bool timer;
    float time;
    float time2;
    float timeExpended;

    Coroutine timerLoop;
    public void TimerToggle() {
        if(!timer){
            timer = true;
            Reset();
            timerLoop = StartCoroutine(Time());
        }
        else{
            timer = false;
            RefreshButton();
        }

    }
    public IEnumerator Time() {
        while (timer) {
            yield return new WaitForSeconds(0.01f);
            timerImag.fillAmount -= 0.01f;
            time -= 0.01f;
            timeExpended += 0.01f;
            if (timeExpended >= 1) {
                timerImag.fillAmount = 1.0f;
                time2--;
                timerText.text = time2.ToString();
                timeExpended = 0;
                if (time2 == 0) {
                    timer = false;
                    RefreshButton();
                }
            }
        }
    }
    public void RefreshButton() {
        if (timer) {
            ButtonText.text = "Stop Timer";
        }
        else {
            ButtonText.text = "Start Timer";
        }
    }
    public void Reset() {
        time = SettingsManager.thisManager.mySettings[1].myCounter;
        time2 = time;
        timerText.text = time.ToString();
        RefreshButton();
        timerImag.fillAmount = 1.0f;
    }
}
