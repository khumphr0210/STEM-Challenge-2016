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

			if (PlayerPrefs.GetInt ("HighestLevel") < SceneManager.GetActiveScene ().buildIndex) 
			{
				if (PlayerPrefs.GetInt ("HighestLevel") != 12) {
					PlayerPrefs.SetInt ("HighestLevel", SceneManager.GetActiveScene ().buildIndex + 1);
				}
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
		//SFX.Instance.finsihFadeOutMainGameMusic(0.5f);
		SFX.Instance.FadeMainMusic(false, false, 0.5f, SFX.Instance.mainGameMusic.volume);
		Debug.Log("Main game music faded out");
		//SFX.Instance.finishFadeInSecondaryGameMusic (3.5f);
		Debug.Log ("Secondary game music faded in");
		yield return new WaitForSeconds(3.0f);
		SFX.Instance.FadeSecondaryMusic(true, true, 1.5f, 0);


		//Time.timeScale = 0;
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
		//SFX.Instance.finsihFadeOutSecondaryGameMusic (0.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 0.5f, SFX.Instance.secondaryGameMusic.volume);
		Debug.Log("Secondary game music faded out");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		//SFX.Instance.finishFadeInMainGameMusic(1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		Debug.Log("Main game music faded in");
	}

	public void NextLevel ()
	{
		Time.timeScale = 1;
		//SFX.Instance.finsihFadeOutSecondaryGameMusic (0.5f);
		SFX.Instance.FadeSecondaryMusic(false, false, 0.5f, SFX.Instance.secondaryGameMusic.volume);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		//SFX.Instance.finishFadeInMainGameMusic(1.5f);
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);

	}

	public void LoadLevelSelect()
	{
		Time.timeScale = 1;
		SFX.Instance.FadeSecondaryMusic(true, true, 1.5f, 0);
		//SFX.Instance.finsihFadeOutSecondaryGameMusic (0.5f);
		//SFX.Instance.FadeSecondaryMusic(false, false, 0.5f, SFX.Instance.secondaryGameMusic.volume);
		SceneManager.LoadScene ("LevelSelect");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		//SFX.Instance.finishFadeInSecondaryGameMusic(1.5f);
	}
}
