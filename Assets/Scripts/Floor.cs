﻿using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{	
		Debug.Log ("enter");
		if (other.tag == "Hole") 
		{
			Debug.Log ("disabled");
			other.enabled = false;
		}
	}
}
