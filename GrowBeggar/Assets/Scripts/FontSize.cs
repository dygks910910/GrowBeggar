using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FontSize : MonoBehaviour {
    public int size = 1;
    Text t;
	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        t.fontSize = Screen.height * size / 20;
    }
}
