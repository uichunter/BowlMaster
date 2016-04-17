using UnityEngine;
using System.Collections;

public class BowlingBall : MonoBehaviour {
	public Vector3 ballSpeedVector;
	public bool isStarted;

	Rigidbody ballRigidbody;
	AudioSource ballSound;

	// Use this for initialization
	void Start ()
	{
		ballRigidbody = this.GetComponent<Rigidbody> ();
		ballSound  = this.GetComponent<AudioSource>();
		isStarted = false;
		ballRigidbody.useGravity = false;

		//BallLaunch (ballSpeedVector);
	}

	public void BallLaunch (Vector3 velocity)
	{
		isStarted = true;
		ballRigidbody.useGravity = true;
		ballRigidbody.velocity = velocity;
		ballSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
