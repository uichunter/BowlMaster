using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	
	public GameObject pinsPrefab;
	public float disToRaise=40f;
	private Animator animator;

	Pin[] pinGroup;

	private Vector3 orignalPinsPos;
	private PinsCounter pinsCounter;

	void Start(){
		FindPinsOrignalPinsPos();
		pinsCounter = FindObjectOfType<PinsCounter>();
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update ()
	{
		pinGroup = pinsCounter.GetPinGroup();
	}

	void FindPinsOrignalPinsPos(){
		GameObject Pins  = GameObject.Find("Pins");
		orignalPinsPos = Pins.transform.position;
	}

	//Animation part
	public void SetTrigger (string triggerNmae)
	{
		animator.SetTrigger(triggerNmae);
	}

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
		Vector3 renewPos = orignalPinsPos + new Vector3 (0f,40f,0f);
		Instantiate(pinsPrefab,renewPos,Quaternion.identity);
	}
}
