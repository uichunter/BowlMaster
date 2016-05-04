using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;




public class GameManager : MonoBehaviour {
	
	ActionMaster actionMaster; 
	List<FrameList> framlist = new List<FrameList>();

	private PinSetter pinSetter;
	private Animator animator;
	private PinsCounter pinsCounter;
	private BowlingBall ball;


	
	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<BowlingBall>();
	
		pinSetter = FindObjectOfType<PinSetter>();
		animator = pinSetter.gameObject.GetComponent<Animator>();
		pinsCounter = FindObjectOfType<PinsCounter>();

		actionMaster = new ActionMaster();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SendPinFall (int pinFall)
	{
		ActionMaster.Action action = actionMaster.Bowl (pinFall);
		framlist.Add (new FrameList (){ FrameID = actionMaster.frame + 1, RollID = 2- actionMaster.roll, PinDown = pinFall,ActionID = action});

		foreach (FrameList f in framlist) {
			Debug.Log(f);
		}
//		foreach (int score in ScoreMaster.ScoreList(framlist)) {
//			print (score);
//		}

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

public class FrameList : List<FrameList>{
	public int FrameID{get;set;}
	public int RollID{get;set;}
	public int PinDown {get;set;}
	public ActionMaster.Action ActionID{get;set;}

	public override string ToString ()
	{
		return string.Format ("[FrameList: FrameID={0}, RollID={1}, PinDown={2}, ActionID={3}]", FrameID, RollID, PinDown, ActionID);
	} 

	}



