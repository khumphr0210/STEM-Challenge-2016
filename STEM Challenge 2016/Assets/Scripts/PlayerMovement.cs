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
	public static bool isPaused;
	public GameObject pauseMenuOverlay;
	private GameObject pauseMenuInstance;
	public GameObject breakLock;
	public GameObject keyCollect;


	void Start () {
	
		player = GetComponent<Rigidbody> ();
		speed = 15f;
		jumpForce = 300f;
		isPaused = false;

	}

	void Update () {
		if(Input.GetButtonDown("Jump") && !isFalling)
			{
				Jump();
			}

		if (Input.GetKeyUp(KeyCode.Escape)) {
			if (!isPaused) {
				StartCoroutine (PauseGame ());
			}

			if (isPaused) {
				UnpauseGame();
			}
		}
	}

	IEnumerator PauseGame ()
	{
		pauseMenuInstance = (GameObject)Instantiate (pauseMenuOverlay);
		yield return new WaitForSeconds (0.1f);
		Time.timeScale = 0;

		isPaused = true;

	}

	public void UnpauseGame ()
	{
		Time.timeScale = 1;
		Destroy (pauseMenuInstance);
		isPaused = false;
	}

	public void ResumeGame()
	{
		//StartCoroutine (PauseGame ());
		Destroy(GameObject.FindGameObjectWithTag("Pause"));
		Time.timeScale = 1;
		isPaused = false;
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
			GameObject keyCollectInstance = (GameObject)Instantiate (keyCollect, collider.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
			collider.gameObject.SetActive (false);
			Destroy (keyCollectInstance, 1f);
		}

		if (collider.gameObject.CompareTag ("Lock") && gotKey) {
			gotKey = false;
			GameObject brokenLockInstance = (GameObject)Instantiate (breakLock, collider.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
			collider.gameObject.SetActive (false);
			Destroy (brokenLockInstance, 2f);
		}


	}
	public void QuitGame ()
	{
		Application.Quit ();
	}

}
