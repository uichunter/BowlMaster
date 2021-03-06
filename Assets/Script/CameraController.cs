﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject ball;
	float cameraStopPosition = 1700;

	Vector3 subtractVector;

	// Use this for initialization
	void Start ()
	{
		if (ball == null) {
			ball = GameObject.Find("Ball");
		}

		subtractVector = this.transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ball.transform.position.z <= cameraStopPosition) {
			this.transform.position = ball.transform.position + subtractVector;
		}
	}
}
