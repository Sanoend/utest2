﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// test for commit from KIper
public class MenuScript : MonoBehaviour {
	
	public string ClickToScene;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter() {

	}
	void OnMouseOver() {
		
		//rend.material.color -= new Color(0.1F, 0.1F, 0) * Time.deltaTime;
	}
	void OnMouseExit() {
	}

	void OnMouseUp(){
		if (ClickToScene != null) {
			if (ClickToScene != "") {
				Debug.Log ("OnMouseClick load scene = "+ClickToScene);
				SceneManager.LoadScene (ClickToScene);
			}
		}
	}

	public void MyLoadScene(string sc_name){
		Debug.Log ("My load scene = "+sc_name);
		SceneManager.LoadScene (sc_name);
	}
}
