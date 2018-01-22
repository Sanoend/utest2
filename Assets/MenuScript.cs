using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	public Renderer rend;
	public Transform arrow;
	public string ClickToScene;
	// Use this for initialization
	void Start () {
		//Debug.Log ("START = "+gameObject.name);
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter() {
		rend.material.color = Color.red;
		if(arrow != null){
			arrow.gameObject.SetActive (true);
		}
	}
	void OnMouseOver() {
		//rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
		rend.material.color -= new Color(0.1F, 0.1F, 0) * Time.deltaTime;
	}
	void OnMouseExit() {
		rend.material.color = Color.white;
		if(arrow != null){
			arrow.gameObject.SetActive (false);
		}
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
