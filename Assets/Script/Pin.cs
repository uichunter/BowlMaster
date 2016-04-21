using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {
	public float standingThreshold = 3f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isStanding ()
	{
		return Vector3.Angle(transform.up,Vector3.up) < standingThreshold;
	}

}
