﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
    public Text score;
    public Text win;

	private Rigidbody rb;
    private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
        count = 0;
        win.text = "";
        SetScore();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
            {
            other.gameObject.SetActive(false);
            count += 1;
            SetScore();
        }
    }

    void SetScore()
    {
        score.text = "Score : " + count.ToString();
        if (count == 13)
        {
            win.text = "You win";
        }
    }
}

