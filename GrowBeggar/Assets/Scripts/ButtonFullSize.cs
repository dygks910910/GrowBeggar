using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFullSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width,Screen.height);        
	}
}
