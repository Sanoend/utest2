using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bita : MonoBehaviour {

    public float bitaSpeed = 1f;

    private Vector3 playerPos = new Vector3(8.5f, 0, 0);


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		float yPos = transform.position.y + (Input.GetAxis("Vertical") * bitaSpeed);
        playerPos = new Vector3(8.5f, Mathf.Clamp(yPos, - 8.4f, 8.4f), 0f);
        transform.position = playerPos;
        */
		float yPos = transform.localPosition.y + (Input.GetAxis("Vertical") * bitaSpeed);
		playerPos = new Vector3(8.5f, Mathf.Clamp(yPos, - 8.4f, 8.4f), 0f);
		transform.localPosition = playerPos;
	}
}
