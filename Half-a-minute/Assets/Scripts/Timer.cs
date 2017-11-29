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
    public void Start() {
        Reset();
    }

    public void TimerToggle() {
        if(!timer){
            if (time != 0) {
                timer = true;
                RefreshButton();
            }

            //timerLoop = StartCoroutine(Time());
        }
        else{
            timer = false;
            RefreshButton();
        }

    }
    public void CountDown() {
        time -= Time.deltaTime;
        if (time <= 0) {
            time = 0;
            timer = false;
            timerImag.fillAmount = 0;
            time2 = 0;
            timerText.text = "0";
            EndTimer();
        }
        timeExpended += Time.deltaTime;
        timerImag.fillAmount -= Time.deltaTime;
        if(timeExpended >= 1) {
            timerImag.fillAmount = 1.0f;
            time2--;
            timerText.text = time2.ToString();
            timeExpended = 0;
        }
        
    }
    public void Update() {
        if (timer) {
            CountDown();
        }
    }
    public void EndTimer() {
        SoundManager.thisManager.PlaySound();
        print("Hary has no timer");
    } 
    /*public IEnumerator Time() {
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
    }*/
    public void RefreshButton() {
        if (timer) {
            ButtonText.text = "Pause Timer";
        }
        else {
            ButtonText.text = "Start Timer";
        }
    }
    public void Reset() {
        if (timer) {
            timer = false;
        }
        time = SettingsManager.thisManager.mySettings[1].myCounter;
        print(time);
        timeExpended = 0;
        time2 = time;
        timerText.text = time.ToString();
        RefreshButton();
        timerImag.fillAmount = 1.0f;

    }
}
