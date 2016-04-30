using UnityEngine;
using System.Collections;

public class ActionMaster {
	public enum Action
	{
		Tidy, Reset, EndTurn, EndGame
	}

	public Action Bowl (int pins)
	{
		if (pins < 0 || pins > 10) {
			throw new UnityException("Invaild pins number!");
		}
		if (pins == 10) {
			return Action.EndTurn;
		}

		throw new UnityException("Dont know which action should return;");
	}
}
