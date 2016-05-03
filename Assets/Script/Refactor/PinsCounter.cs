using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinsCounter : MonoBehaviour {
	public Text standingText;



	Pin[] pinGroup;
	GameManager gameManager;

	private bool isBallEnterBox = false;
	private int lastPinsForActionMaster=10;
	private int lastPinCount = -1;
	private float lastChangeTime;
	private int bowl;

	public void SetLastPinsForActionMaster (int pins)
	{
		lastPinsForActionMaster = pins;
	}
	public Pin[] GetPinGroup ()
	{
		return pinGroup;
	}
	
	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager>();
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
			bowl = lastPinsForActionMaster - currentPinCount; // to calculate the number of pins konck down after settled.
			SetLastPinsForActionMaster(currentPinCount);
			PinHaveSettled ();
		}
	}

	void PinHaveSettled ()
	{
		Reset();
		gameManager.SendPinFall(bowl); // the concetion to GameManager;
		SetTextColor(Color.black);
	}

	void SetTextColor(Color color){
		standingText.color = color;
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.GetComponent<BowlingBall> ()) {
			isBallEnterBox = true;
			SetTextColor(Color.red);
		}

	}

	void Reset ()
	{
		lastPinCount = -1;// Reset the pin status;
		isBallEnterBox = false;// Reset the ball enter status;
	}

}
