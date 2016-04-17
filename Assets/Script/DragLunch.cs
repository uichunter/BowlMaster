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

	public void MoveStart (float amount)
	{
		float posTest = amount + transform.position.x;
		float floorSizeX = 105f / 2f - transform.lossyScale.x/2;

		if (bowlingBall.isStarted) {
			Debug.LogError("The ball is launched.");
			return;
		}

		if (posTest <= floorSizeX && posTest >= -1 * floorSizeX) {
			bowlingBall.transform.Translate (new Vector3 (amount, 0f, 0f));
		} else {
			Debug.LogError(name +" start position.x is out of floor size.");
		}
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
		}
	}
}
