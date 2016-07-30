﻿using UnityEngine;
using System.Collections;

public class Finsih : MonoBehaviour {

	void OnTriggerExit (Collider finish)
	{
		Debug.Log ("You Win");

		GameObject.Find ("Player").GetComponent<Rigidbody> ().angularDrag = 5;
		GameObject.Find ("Player").GetComponent<Rigidbody> ().drag = 5;
		GameObject.Find ("Player").GetComponent<Rigidbody> ().mass = 10;
		GameObject.Find ("Player").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
	}
}
