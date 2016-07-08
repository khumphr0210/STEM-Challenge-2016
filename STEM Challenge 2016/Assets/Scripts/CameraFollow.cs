using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	public float distanceAway;
	public float distanceUp;
	public float smooth;
	public Transform follow;
	private Vector3 targetPosition;



	void LateUpdate () {
	
		targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
		transform.LookAt (follow);
	}
}
