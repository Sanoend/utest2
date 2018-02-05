using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bita : MonoBehaviour {

    public float bitaSpeed = 2f;
    public GameObject fonar;
    public float fonarCharge = 6f;

    private Vector3 playerPos = new Vector3(17f, -5, 0);


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float yPos = transform.localPosition.y + (Input.GetAxis("Horizontal") * bitaSpeed);
		playerPos = new Vector3(17f, Mathf.Clamp(yPos, - 37f, 22f), 0f);
		transform.localPosition = playerPos;
	}
}
