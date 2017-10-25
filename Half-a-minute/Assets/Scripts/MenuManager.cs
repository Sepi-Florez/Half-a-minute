using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public static MenuManager thisManager;
    public Transform[] menus;
    private List<Animator> menusAnim = new List<Animator>();
    int currentMenu;
    public List<int> previousMenus;

    public void Start(){
        thisManager = this;
        for(int i = 0; i < menus.Length; i++)
        {
            menusAnim.Add(menus[i].GetComponent<Animator>());
            menus[i].GetComponent<CanvasGroup>().alpha = 0;
        }
        EnableMenu(currentMenu);
    }
    public void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if(previousMenus.Count > 0) {
                NavigateBack();
            }
        }
    }
    public void Navigate(int i) {
        DisableMenu(currentMenu);
        EnableMenu(i);
        previousMenus.Add(currentMenu);
        currentMenu = i;
        
    }
    /*public void EnableButtons(int i) { 
        foreach (Transform n in menus[i]){
            n.GetComponent<Button>().interactable = true;
        }
    }
    public void DisableButtons(int i) {
        foreach (Transform n in menus[i]){
            n.GetComponent<Button>().interactable = false;
        }
    }*/
    public void DisableMenu(int i) {
        menusAnim[i].SetBool("Open", false);
    }
    public void EnableMenu(int i) {
        if (menus[i].GetComponent<CanvasGroup>().alpha == 0) {
            menus[i].GetComponent<CanvasGroup>().alpha = 1;
        }
        menusAnim[i].SetBool("Open", true);
    }
    public void EnableNext() { 

    }
    public void NavigateBack(){
        DisableMenu(currentMenu);
        EnableMenu(previousMenus[previousMenus.Count - 1]);
        currentMenu = previousMenus[previousMenus.Count - 1];
        previousMenus.RemoveAt(previousMenus.Count - 1);
    }
}
