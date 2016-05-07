using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	Text[] displayList;

	// Use this for initialization
	void Start ()
	{
		displayList = gameObject.GetComponentsInChildren<Text> (true);//(true) is used to inactive GameObjects be included in the found set.
		foreach (Text scoreText in displayList) {
			scoreText.text = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateScore(List<int> scoreList){
		for (int i =0;i < scoreList.Count;i++){
			displayList[i].text = scoreList[i].ToString();
		}
	}
}
