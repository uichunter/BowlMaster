using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {
	public static List<int> GetScoreList (List<FrameList> frameList)
	{
		int score = 0;
		List<int> scoreList = new List<int> ();

		for (int i = 0; i < frameList.Count; i++) {
			int pinNow = frameList [i].PinDown;
			int frameListSize = frameList.Count;
			int currentRollID = frameList [i].RollID;

			if (pinNow == 10 && currentRollID == 1 && i < frameListSize - 1) {// Handle the Strike situation
				//Debug.Log("Strike situation: "+score);
				score += pinNow + frameList[i+1].PinDown+frameList[i+2].PinDown;
				scoreList.Add(score);
			}else if (currentRollID == 2 && i< frameListSize -1 && pinNow + frameList[i-1].PinDown ==10){// Handle Spare situation.
				score +=  frameList[i-1].PinDown + pinNow + frameList[i+1].PinDown;
				scoreList.Add(score);
				//Debug.Log("Spare situation: "+score);
			}else if (currentRollID == 2 && pinNow + frameList[i-1].PinDown <10){
				score += pinNow + frameList[i-1].PinDown;
				scoreList.Add(score);
				//Debug.Log("Normal situation: "+score);
			}
		}
		return scoreList;
	}
}
