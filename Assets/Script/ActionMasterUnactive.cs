using UnityEngine;
using System.Collections;

public class ActionMasterUnactive {
	public enum Action{Tidy, Reset, EndFrame, EndGame}

	private int roll =1;

	private int[] bowls = new int[22];

	public Action Bowl (int pins)
	{
		bowls [roll] = pins; 



		if (pins < 0 || pins > 10) {
			throw new UnityException ("Invaild pins number!");
		}

		//Handle the last frame situation;
		if (roll >= 21) {// no wonder how many pins, return end game in last frame;
			return Action.EndGame;
		}

		if (roll >= 20 && isSpareInLastFrame ()) {// Detect the roll 20;
			roll += 1;
			return Action.Reset;
		} else if (roll == 20 && !isSpareInLastFrame ()) {
			if (bowls[roll-1] == 10){
				roll +=1;
				return Action.Tidy;
			}
			return Action.EndGame;
		}

		//If player hit a strike;
		if (pins == 10) {
			if (roll >= 19) {// Handle last frame;
				roll +=1;
				return Action.Reset;
			}
			roll +=2;
			return Action.EndFrame;
		}

		//General situation;
		if (roll % 2 == 1) {
			roll +=1;
			return Action.Tidy;
		} else {
			roll +=1;
			return Action.EndFrame;
		}
	}

	private bool isSpareInLastFrame ()
	{
		return (bowls[roll-1]+bowls[roll] ==10 && bowls[roll -1] !=10);
	}
}
