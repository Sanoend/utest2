﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public int lives = 3;
    public int bricks = 24;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject bita;
    public GameObject deathParticles;
    public static GameManager instance = null;

    private GameObject cloneBita;

    // Use this for initialization
    void Start () {

        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        Setup();
	}

    public void Setup() {
        cloneBita = Instantiate(bita, transform.position,Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if(bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLives()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, cloneBita.transform.position, Quaternion.identity);
        Destroy(cloneBita);
        Invoke("SetupBita", resetDelay);
        CheckGameOver();
    }

    void SetupBita()
    {
        cloneBita = Instantiate(bita, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
