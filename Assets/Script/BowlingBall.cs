using UnityEngine;
using System.Collections;

public class BowlingBall : MonoBehaviour {
	public Vector3 ballSpeedVector;
	public bool isStarted;

	Rigidbody ballRigidbody;
	AudioSource ballSound;
	Vector3 originalPosition;
	float speed =100f;

	// Use this for initialization
	void Start ()
	{
		originalPosition = gameObject.transform.position;
		ballRigidbody = this.GetComponent<Rigidbody> ();
		ballSound  = this.GetComponent<AudioSource>();
		isStarted = false;
		ballRigidbody.useGravity = false;
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
		//Editor control mode.
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		transform.position += move*speed * Time.deltaTime;
	}

	public void Reset ()
	{
		isStarted = false;
		ballRigidbody.useGravity = false;
		transform.position = originalPosition;
		ballRigidbody.velocity = Vector3.zero;
		ballRigidbody.angularVelocity = Vector3.zero;
	}
}
