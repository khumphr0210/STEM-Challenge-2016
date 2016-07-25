using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	//public float horizontalSpeed;
	//public float verticalSpeed;
	public float speed;
	private Rigidbody player;
	public float jumpForce;
	public bool isFalling = false;
	public LayerMask groundLayer;
	public bool gotKey = false;

	void Start () {
	
		player = GetComponent<Rigidbody> ();
		speed = 15f;
		jumpForce = 300f;
	}

	void Update () {
		if(Input.GetButtonDown("Jump") && !isFalling)
			{
				Jump();
			}
	}

	void FixedUpdate () {
	
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		player.AddForce (movement * speed);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 8) {
			isFalling = false;
		}
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.layer == 8 && !isFalling) {
			isFalling = true;
		}
	}
	void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.layer == 8) {
			isFalling = false;
		}
	}

	void Jump ()
	{
		player.AddForce (0, jumpForce, 0);
	}

	void OnTriggerEnter(Collider collider) 
	{
		if (collider.gameObject.CompareTag ("Key"))
		{
			gotKey = true;
			collider.gameObject.SetActive (false);
		}

		if (collider.gameObject.CompareTag ("Lock") && gotKey) {
			gotKey = false;
			collider.gameObject.SetActive (false);
		}


	}


}
