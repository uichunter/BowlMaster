using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {
	public static List<int> GetScoreList (List<FrameList> frameList)
	{
		int score = 0;
		List<int> scoreList = new List<int> ();
//		foreach (FrameList frame in frameList) {
//			score += frame.PinDown;
//			if (frame.RollID == 2) {
//				scoreList.Add (score);
//			}
//		}

		//score = scoreList[scoreList.Capacity -1];// Bug: Index out of range.


		for (int i = 0; i < frameList.Count; i++) {

			int PinNow = frameList[i].PinDown;
			if (PinNow == 10 && frameList [i].RollID == 1 && i<frameList.Count-1) {// Handle the Strike situation
				score += PinNow + frameList[i+1].PinDown+frameList[i+2].PinDown;
				Debug.Log("Strike situation: "+score);
				scoreList.Add(score);
			}else if (frameList[i].RollID == 2 && PinNow + frameList[i-1].PinDown ==10 && i<frameList.Count-1){// Handle Spare situation.
				score +=  frameList[i-1].PinDown + PinNow + frameList[i+1].PinDown;
				scoreList.Add(score);
				Debug.Log("Spare situation: "+score);
			}else if (frameList[i].RollID == 2 && PinNow + frameList[i-1].PinDown <10){
				score += PinNow + frameList[i-1].PinDown;
				scoreList.Add(score);
				Debug.Log("Normal situation: "+score);
			}
		}
		return scoreList;
	}
}
