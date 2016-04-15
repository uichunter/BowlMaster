using UnityEngine;
using System.Collections;

public class BowlingBall : MonoBehaviour {
	public Vector3 ballSpeedVector;
	Rigidbody ballRigidbody;
	AudioSource ballSound;
	// Use this for initialization
	void Start ()
	{
		ballRigidbody = this.GetComponent<Rigidbody> ();
		ballSound  = this.GetComponent<AudioSource>();

		BallLaunch ();
	}

	public void BallLaunch ()
	{
		ballRigidbody.velocity = ballSpeedVector;
		ballSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
