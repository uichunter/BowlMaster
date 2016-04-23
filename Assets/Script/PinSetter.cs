using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	Pin[] pinGroup;
	public Text standingText;



	// Use this for initialization
	void Start () {
		pinGroup = FindObjectsOfType<Pin>();
	}
	
	// Update is called once per frame
	void Update () {
		standingText.text = CountStanding().ToString();
	}

	public int CountStanding ()
	{
		int standCount = 0;
		foreach (Pin pin in pinGroup) {
			if (pin.isStanding()) {
				standCount++;
			}
		}
		return standCount;
	}
}
