using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;




public class GameManager : MonoBehaviour {
	
	ActionMaster actionMaster; 
	List<FrameList> framlist = new List<FrameList>();

	private PinSetter pinSetter;
	private ScoreDisplay scoreDisplay;
	private PinsCounter pinsCounter;
	private BowlingBall ball;


	
	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<BowlingBall>();
	
		pinSetter = FindObjectOfType<PinSetter>();
		scoreDisplay = FindObjectOfType<ScoreDisplay>();
		pinsCounter = FindObjectOfType<PinsCounter>();
		actionMaster = new ActionMaster();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SendPinFall (int pinFall)
	{
		//For the real FrameID and RollID
		int realFrameID = actionMaster.frame +1;
		int realRollID = actionMaster.roll +1;

		ActionMaster.Action action = actionMaster.Bowl (pinFall);// Get frame data.
		framlist.Add (new FrameList (){ FrameID = realFrameID, RollID = realRollID, PinDown = pinFall,ActionID = action}); //TODO: The roll id can not reach to 3.
//		foreach (FrameList f in framlist) {// Show each roll information;
//			Debug.Log(f);
//		}

		scoreDisplay.UpdateScore(ScoreMaster.GetScoreList(framlist));//Get scoreList from ScoreMaster and send them to score display.

		ball.Reset();// Reset the ball;
		switch(action){
			case ActionMaster.Action.Tidy: 
			pinSetter.SetTrigger("tidyTrigger");
			break;

			case ActionMaster.Action.EndFrame:
			case ActionMaster.Action.Reset:
			pinSetter.SetTrigger("resetTrigger");
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



