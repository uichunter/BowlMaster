using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour {
	

	ActionMaster actionMaster; 

	private GameObject pinSetterGameObject;
	private PinSetter pinSetter;
	private Animator animator;
	private PinsCounter pinsCounter;
	private BowlingBall ball;

	
	// Use this for initialization
	void Start () {
		pinSetterGameObject = GameObject.Find("PinSetter");
		ball = FindObjectOfType<BowlingBall>();

		animator = pinSetterGameObject.GetComponent<Animator>();
		pinSetter = pinSetterGameObject.GetComponent<PinSetter>();
		pinsCounter = FindObjectOfType<PinsCounter>();

		actionMaster = new ActionMaster();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SendPinFall (int pinFall)
	{
		ActionMaster.Action action =  actionMaster.Bowl(pinFall);
		//Debug.Log("Hit: "+pinFall+" " + action);
		ball.Reset();// Reset the ball;
		switch(action){
			case ActionMaster.Action.Tidy: 
			animator.SetTrigger("tidyTrigger");
			break;

			case ActionMaster.Action.EndFrame:
			case ActionMaster.Action.Reset:
			animator.SetTrigger("resetTrigger");
			pinsCounter.SetLastPinsForActionMaster(10);// Reset the last pins number to 10;
			break;

			case ActionMaster.Action.EndGame:
			throw new UnityException("Not reach to End Game state;");
		}
	}

}

//class Frames : IList{
//	
//}