using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryHelper : MonoBehaviour {
    private Animator anim;
    private void Start() {
        anim = transform.GetComponent<Animator>();
    }
    public void Selected() {
        anim.SetBool("Selected", !anim.GetBool("Selected"));
    }
    public void Fill(string category, int i) {
        transform.GetChild(1).GetComponent<Text>().text = category;
        transform.GetComponent<Button>().onClick.AddListener(() => CategorySelection.thisManager.toggleCategory(i));
    }
}
