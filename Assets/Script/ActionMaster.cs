using UnityEngine;
using System.Collections;

public class ActionMaster {
	public enum Action{Tidy, Reset, EndFrame, EndGame, Spare, Strike}

	public  int roll =0;
	public  int frame =0;

	int[,] frameList = new int[10,3];


	public Action Bowl (int pins)
	{
		frameList [frame, roll] = pins; 

		//For the error input;
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Invaild pins number!");
		}

		//Handle last frame situation.
		if (frame == 10 - 1) {

			if (roll == 0) {//Last frame first roll;
				if (pins == 10) {
					roll++;
					return Action.Reset;
				}
			}

			if (roll == 1) {// Last frame second roll;
				if (isSpare () || frameList[frame,roll] == 10) {
					roll++;
					return Action.Reset;
				} else if (frameList [9, 0] == 10) {
					roll++;
					return Action.Tidy;
				} else {
					return Action.EndGame;
				}
			}

			if (roll == 2) {// Last frame last roll;
				return Action.EndGame;
			}

		}

		//Handle the strike situation.
		if (pins == 10) {
			NextFrame ();
			return Action.EndFrame;
		}

		//Gneral situation.
		if (roll == 0) {
			roll ++;
			return Action.Tidy;
		} else {
			NextFrame ();
			return Action.EndFrame;
		}
	}

	void NextFrame ()
	{
		roll = 0;
		frame++;
	}

	bool isSpare ()
	{
		return (frameList[10-1,1-1] + frameList[10-1,2-1] >=10 && frameList[10-1,1-1] !=10);
	}
}
