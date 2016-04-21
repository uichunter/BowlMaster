using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	Pin[] pinGroup;
	Text standingText;
	int standCount = 0;


	// Use this for initialization
	void Start () {
		pinGroup = FindObjectsOfType<Pin>();
		standingText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		print(name +" "+CountStanding());
	}

	public int CountStanding ()
	{
		foreach (Pin pin in pinGroup) {
			if (pin.isStanding()) {
				standCount++;
			}
		}
		return standCount;
	}
}
