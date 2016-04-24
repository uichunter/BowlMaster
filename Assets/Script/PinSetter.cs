using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	Pin[] pinGroup;
	public Text standingText;
	public GameObject pinsPrefab;
	public float disToRaise=40f;

	private bool isBallEnterBox = false;
	private int lastPinCount = -1;
	private float lastChangeTime;
	private Vector3 orignalPinsPos;
	private BowlingBall ball;

	
	// Update is called once per frame
	void Update ()
	{
		standingText.text = CountStanding ().ToString ();
		if (isBallEnterBox) {
			CheckPinSettle();
		}
		FindPinsOrignalPinsPos();
	}

	void FindPinsOrignalPinsPos(){
		GameObject Pins  = GameObject.Find("Pins");
		orignalPinsPos = Pins.transform.position;
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

	//Methods to used by animator.
	public void RaisePins ()
	{
		foreach (Pin pin in pinGroup) {
			if (pin.isStanding()) {
				pin.transform.Translate(new Vector3(0,disToRaise,0) ,Space.World);
				pin.StablePins();
				pin.setUseGravity(false);
			}
		}
	}

	public void LowerPins ()
	{
		foreach (Pin pin in pinGroup) {
			pin.setUseGravity(true);
		}
	}

	public void RenewPins ()
	{
		//TODO Destroy the empty Pins gameobject.
		Vector3 renewPos = orignalPinsPos + new Vector3 (0f,40f,0f);
		Instantiate(pinsPrefab,renewPos,Quaternion.identity);
	}
}
