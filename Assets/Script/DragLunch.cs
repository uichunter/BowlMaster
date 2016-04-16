using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BowlingBall))]
public class DragLunch : MonoBehaviour {

	BowlingBall bowlingBall;
	Vector3 mousePoStart;
	Vector3 mouseOffset;
	float timeStart,timeEnd;
	// Use this for initialization
	void Start () {
		bowlingBall =  gameObject.GetComponent<BowlingBall>();
	}
	
	public void DragStart(){
		// Capture time and position of draging.
		mousePoStart = Input.mousePosition;
		timeStart = Time.time;

	}

	public void DragEnd ()
	{
		// Launch.
		mouseOffset = Input.mousePosition - mousePoStart;
		timeEnd = Time.time - timeStart;
		if (mouseOffset.y >= 0) {
			Vector3 newMouseOffset = new Vector3 (mouseOffset.x / timeEnd, 0f, mouseOffset.y / timeEnd);
			bowlingBall.BallLaunch (newMouseOffset);
			print (name+" "+timeEnd);
			print (newMouseOffset);
		}
	}
}
