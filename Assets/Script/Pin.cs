using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {
	public float standingThreshold = 5f;
	Rigidbody pinRigidbody;

	// Use this for initialization
	void Start () {
		pinRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isStanding ()
	{
		return Vector3.Angle(transform.up,Vector3.up) < standingThreshold;
	}

	public void setUseGravity(bool isUse){
		pinRigidbody.useGravity = isUse;
	}

	public void StablePins ()
	{
		pinRigidbody.velocity = Vector3.zero;
		pinRigidbody.angularVelocity = Vector3.zero;
		gameObject.transform.rotation = Quaternion.Euler(0,0,0);
	}

}
