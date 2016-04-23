using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	Pin[] pinGroup;
	public Text standingText;

	private bool isBallEnterBox = false;
	private int lastPinCount = -1;
	private float lastChangeTime;
	private BowlingBall ball;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		standingText.text = CountStanding ().ToString ();
		if (isBallEnterBox) {
			CheckPinSettle();
		}
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
			PinHaveSettled ();
		}
	}

	void PinHaveSettled ()
	{
		Reset ();
		standingText.color = Color.green;
	}

	void Reset ()
	{
		lastPinCount = -1;// Reset the pin status;
		isBallEnterBox = false;// Reset the ball enter status;
		ball.Reset();
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

	void OnTriggerEnter (Collider collider)
	{
		if (collider.GetComponent<BowlingBall> ()) {
			ball = collider.GetComponent<BowlingBall>();// Link the actual BowlingBall to this object;
			isBallEnterBox = true;
			SetTextColor(Color.red);
		}

	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.GetComponentInParent<Pin>()) {
			Destroy(collider.transform.parent.gameObject);
		}
	}

	void SetTextColor(Color color){
		standingText.color = color;
	}
}
