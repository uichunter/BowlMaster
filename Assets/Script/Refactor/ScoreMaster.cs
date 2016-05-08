using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {
	public static List<int> GetScoreList (List<FrameList> frameList)
	{
		int score = 0;
		int frameListSize = frameList.Count;
		List<int> scoreList = new List<int> ();

		//Loop over the framelist and return scoreList.
		for (int i = 0; i < frameListSize; i++) {
			int pinNow = frameList [i].PinDown;
			int currentRollID = frameList [i].RollID;

			if (currentRollID == 2 && pinNow + frameList[i-1].PinDown <10){// Handle the normal situation.
				score += pinNow + frameList[i-1].PinDown;
				scoreList.Add(score);
			}

			if (frameListSize - i <= 1) {break;} // Stop the invaild look forward step.

			if (pinNow == 10 && currentRollID == 1) {// Handle the Strike situation
				score += pinNow + frameList[i+1].PinDown+frameList[i+2].PinDown;
				scoreList.Add(score);
			}

			if (currentRollID == 2 && pinNow + frameList[i-1].PinDown ==10){// Handle Spare situation.
				score +=  frameList[i-1].PinDown + pinNow + frameList[i+1].PinDown;
				scoreList.Add(score);
			}
		}
		return scoreList;
	}
}
