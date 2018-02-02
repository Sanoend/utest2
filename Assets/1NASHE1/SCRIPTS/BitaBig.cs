using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitaBig : MonoBehaviour {

    public float bitaSpeed = 10f;

    private Vector3 playerPos = new Vector3(-30f, 0, 100f);


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
		float yPos = transform.position.y + (Input.GetAxis("Vertical") * bitaSpeed);
        playerPos = new Vector3(8.5f, Mathf.Clamp(yPos, - 8.4f, 8.4f), 0f);
        transform.position = playerPos;
        */
        //float yPos = transform.localPosition.y + (Input.GetAxis("Vertical") * bitaSpeed);
        float xPos = transform.localPosition.x + (Input.GetAxis("Horizontal") * bitaSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -210f, 170f), 0, 100f);
        transform.localPosition = playerPos;
    }
}
