using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class NewBehaviourScript : MonoBehaviour {
	
	public Text standingText;

	ActionMaster actionMaster; 

	
	// Use this for initialization
	void Start () {
		actionMaster = gameObject.GetComponent<ActionMaster>();
	}
	
	// Update is called once per frame
	void Update () {
		standingText.text = CountStanding ().ToString ();
		if (isBallEnterBox) {
			CheckPinSettle();
		}
	}

	void SendPinFall (int pinFall)
	{
		actionMaster.Bowl(pinFall);
	}
}

//class Frames : IList{
//	
//}