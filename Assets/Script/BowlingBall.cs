using UnityEngine;
using System.Collections;

public class BowlingBall : MonoBehaviour {
	public float ballSpeed;
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
		ballRigidbody.velocity = new Vector3 (0f, 0f, ballSpeed);
		ballSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
