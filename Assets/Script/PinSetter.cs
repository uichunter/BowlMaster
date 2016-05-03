using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	
	public GameObject pinsPrefab;
	public float disToRaise=40f;

	Pin[] pinGroup;
	private bool isBallEnterBox = false;
	private int lastPinCount = -1;
	private int bowl;
	private int lastPinsForActionMaster=10;
	private float lastChangeTime;
	private Vector3 orignalPinsPos;
	private BowlingBall ball;
	private ActionMaster actionMaster = new ActionMaster();
	private Animator animator;

	void Start(){
		FindPinsOrignalPinsPos();
		animator = gameObject.GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update ()
	{
		standingText.text = CountStanding ().ToString ();
		if (isBallEnterBox) {
			CheckPinSettle();
		}
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
			bowl = lastPinsForActionMaster - currentPinCount; // to calculate the number of pins konck down after settled.
			lastPinsForActionMaster = currentPinCount;
			PinHaveSettled ();
		}
	}

	void PinHaveSettled ()
	{
		Reset ();
		ActionMaster.Action action = actionMaster.Bowl(bowl);
		print("Hit:"+bowl+" "+action);
		switch(action){
			case ActionMaster.Action.Tidy: 
			animator.SetTrigger("tidyTrigger");
			break;

			case ActionMaster.Action.EndFrame:
			case ActionMaster.Action.Reset:
			animator.SetTrigger("resetTrigger");
			lastPinsForActionMaster =10;// Reset the last pins number to 10;
			break;

			case ActionMaster.Action.EndGame:
			throw new UnityException("Not reach to End Game state;");
		}
		SetTextColor(Color.black);;
	}

	void Reset ()
	{
		lastPinCount = -1;// Reset the pin status;
		isBallEnterBox = false;// Reset the ball enter status;
		ball.Reset();
	}

//	public int CountStanding ()
//	{
//		pinGroup = FindObjectsOfType<Pin>();
//		int standCount = 0;
//		foreach (Pin pin in pinGroup) {
//			if (pin.isStanding()) {
//				standCount++;
//			}
//		}
//		return standCount;
//	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.GetComponent<BowlingBall> ()) {
			ball = collider.GetComponent<BowlingBall>();// Link the actual BowlingBall to this object;
			isBallEnterBox = true;
			SetTextColor(Color.red);
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
