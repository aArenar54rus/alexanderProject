using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

	public void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log(collider);
		if (collider.gameObject.tag == "Player") {
			//Character player = collider.gameObject.GetComponent<Character> ();
			Debug.Log(collider);
			//GameObject player = collider.gameObject;
			//var obj = player.GetComponents ();
		}
	}
}