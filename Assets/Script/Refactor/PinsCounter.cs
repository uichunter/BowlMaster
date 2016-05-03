using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinsCounter : MonoBehaviour {
	public Text standingText;

	Pin[] pinGroup;
	private bool isBallEnterBox = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		standingText.text = CountStanding ().ToString ();
		if (isBallEnterBox) {
			CheckPinSettle();
		}
	}

	public int CountStanding ()
	{
		pinGroup = FindObjectsOfType<Pin>();
		int standCount = 0;
		foreach (Pin pin in pinGroup) {
			if (pin.isStanding()) {
				standCount++;
			}
		}
		return standCount;
	}

	void CheckPinSettle ()
	{
		int currentPinCount = CountStanding ();

		if (currentPinCount != lastPinCount) {
			lastChangeTime = Time.time;
			lastPinCount = currentPinCount;
			return;
		}

		float settleTime = 3f;// How long to wait the pins settle down;
		if ((Time.time - lastChangeTime) > settleTime) {
			//bowl = lastPinsForActionMaster - currentPinCount; // to calculate the number of pins konck down after settled.
			//lastPinsForActionMaster = currentPinCount;
			PinHaveSettled ();
		}
	}
}
