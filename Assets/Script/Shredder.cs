using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerExit (Collider collider)
	{
		if (collider.GetComponentInParent<Pin>()) {
			Destroy(collider.transform.parent.gameObject);
		}
	}
}
