using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	//public float horizontalSpeed;
	//public float verticalSpeed;
	public float speed;
	public Rigidbody player;
	public float jumpForce;
	public bool isFalling = false;
	public LayerMask groundLayer;
	public bool gotKey = false;
	public static bool isPaused;
	public GameObject pauseMenuOverlay;
	private GameObject pauseMenuInstance;
	public GameObject breakLock;
	public GameObject keyCollect;
    public VirtualJoystick joyStick;

	//public CameraFollow followCam;

	//void Awake()
	//{
		//followCam = (GameObject)CameraFollow.FindObjectOfType<Camera>();
	//}

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
		StartCoroutine (PauseMusic ());
		yield return new WaitForSeconds (0.1f);
		Time.timeScale = 0;

		isPaused = true;

	}
	IEnumerator PauseMusic()
	{
		//SFX.Instance.pauseFadeOutMainGameMusic (0.09f);
		SFX.Instance.FadeMainMusicFromPause(false, 0.09f, SFX.Instance.mainGameMusic.volume);
		yield return null;
	}

	public void UnpauseGame ()
	{
		Time.timeScale = 1;
		Destroy (pauseMenuInstance);
		StartCoroutine (UnpauseMusic ());
		isPaused = false;
	}
	IEnumerator UnpauseMusic()
	{
		//SFX.Instance.pauseFadeInMainGameMusic (0.09f);
		SFX.Instance.FadeMainMusicFromPause(true, 0.09f, SFX.Instance.mainGameMusic.volume);
		yield return null;
	}

	public void ResumeGame()
	{
		Destroy(GameObject.FindGameObjectWithTag("Pause"));
		Time.timeScale = 1;
		SFX.Instance.mainGameMusic.volume = 1;
		isPaused = false;
	}

	void FixedUpdate () {

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = joyStick.Horizontal();
        float moveVertical = joyStick.Vertical();

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

	public void Jump ()
	{
        if(!isFalling)
		player.AddForce (0, jumpForce, 0);
	}

	void OnTriggerEnter(Collider collider) 
	{
		if (collider.gameObject.CompareTag ("Key"))
		{
			gotKey = true;
			GameObject keyCollectInstance = (GameObject)Instantiate (keyCollect, collider.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
			SFX.Instance.keyCollect.Play ();
			collider.gameObject.SetActive (false);
			Destroy (keyCollectInstance, 1f);
		}

		if (collider.gameObject.CompareTag ("Lock") && gotKey) {
			gotKey = false;
			GameObject brokenLockInstance = (GameObject)Instantiate (breakLock, collider.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
			SFX.Instance.lockExplosion.Play ();
			collider.gameObject.SetActive (false);
			//followCam.ShakeCamera (0.3f, 1f);
			Destroy (brokenLockInstance, 2f);

		}


	}
	public void QuitGame ()
	{
		Application.Quit ();
	}

}
