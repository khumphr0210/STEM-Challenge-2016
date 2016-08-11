using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

	public GameObject levelCompleteMenu;
	private GameObject player;
	private bool levelFinished;

	void OnTriggerEnter (Collider finish)
	{
		levelFinished = true;
		SFX.Instance.finish.Play ();

		if (PlayerPrefs.GetInt ("HighestLevel") != null) 
		{

			if (PlayerPrefs.GetInt ("HighestLevel") < SceneManager.GetActiveScene ().buildIndex || PlayerPrefs.GetInt ("HighestLevel") != 12) 
			{
				PlayerPrefs.SetInt ("HighestLevel", SceneManager.GetActiveScene ().buildIndex +1);
			}

		} 
		else 
		{
			PlayerPrefs.SetInt ("HighestLevel", SceneManager.GetActiveScene ().buildIndex +1);
		}


		if (PlayerPrefs.GetInt ("LastLoadedLevel") != null) 
		{
			if (PlayerPrefs.GetInt ("LastLoadedLevel") == 12) {
				PlayerPrefs.SetInt ("LastLoadedLevel", 3);
			} 
			else
			{
				PlayerPrefs.SetInt ("LastLoadedLevel", SceneManager.GetActiveScene ().buildIndex +1);
			}

		} 
		else 
		{
			PlayerPrefs.SetInt ("LastLoadedLevel", SceneManager.GetActiveScene ().buildIndex +1);
		}


		GameObject.Find ("Player").GetComponent<Rigidbody> ().angularDrag = 5;
		GameObject.Find ("Player").GetComponent<Rigidbody> ().drag = 5;
		GameObject.Find ("Player").GetComponent<Rigidbody> ().mass = 10;
		GameObject.Find ("Player").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;


		StartCoroutine (FadeToBlack ());
	}

	IEnumerator FadeToBlack ()
	{
		FadeManager.Instance.Fade(true, 3.0f); //fade to black
		yield return new WaitForSeconds(3.0f);

		Time.timeScale = 0;
		//Instantiate(levelCompleteMenu);

		GameObject levelCompleted = (GameObject)Instantiate(levelCompleteMenu);
		if (SceneManager.GetActiveScene ().buildIndex == 12) {
			levelCompleted.GetComponentInChildren<Text> ().text = "Congratulations..." + Environment.NewLine + "All levels complete!";
			GameObject.Find ("btnNextLevel").SetActive (false);
		}
	}

	IEnumerator FadeFromBlack ()
	{
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		yield return new WaitForSeconds(0);
	}

	void Start()
	{
		levelFinished = false;
		player = GameObject.Find ("Player");
	}

	void Update()
	{
		if (levelFinished) {
			player.transform.Translate (Vector3.up * 4 * Time.deltaTime, Space.World);
		}
	}

	public void RetryLevel()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
	}
	public void NextLevel ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent

	}

	public void LoadLevelSelect()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("LevelSelect");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
	}
}
