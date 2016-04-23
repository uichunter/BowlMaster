using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	Pin[] pinGroup;
	public Text standingText;

	private bool isBallEnterBox = false;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		standingText.text = CountStanding().ToString();
	}

	public int CountStanding ()
	{
		pinGroup = FindObjectsOfType<Pin>();
		int standCount = 0;
		foreach (Pin pin in pinGroup) {
			if (pin.isStanding()) {
				standCount++;
			}
		}
		return standCount;
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.GetComponent<BowlingBall> ()) {
			isBallEnterBox = true;
			SetTextColor(Color.red);
		}

	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.GetComponentInParent<Pin>()) {
			Destroy(collider.transform.parent.gameObject,1f);
		}
		Destroy(collider.gameObject,1f);
	}

	void SetTextColor(Color color){
		standingText.color = color;
	}
}
