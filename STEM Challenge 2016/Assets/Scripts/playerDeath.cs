using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerDeath : MonoBehaviour {

	public GameObject playerDeathMenu;

	void OnCollisionEnter(Collision collision)
	{
		if( collision.gameObject.tag == "Player" )
		{
			StartCoroutine (FadeToBlack (collision.gameObject));

		}
	}

	IEnumerator FadeToBlack (GameObject player)
	{
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		SFX.Instance.FadeMainMusic(false, false, 1.5f, SFX.Instance.mainGameMusic.volume);
		Debug.Log ("Faded main game music out after death");
		yield return new WaitForSeconds(2.0f);

		Destroy(player);
		//Time.timeScale = 0;
		Instantiate(playerDeathMenu);
		SFX.Instance.FadeSecondaryMusic (true, true, 1.5f, 0);
		Debug.Log ("Secondary music faded in after death");
	}

	IEnumerator FadeFromBlack ()
	{
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		yield return new WaitForSeconds(0);
	}

	public void RetryLevel()
	{
		//Time.timeScale = 1;
		SFX.Instance.FadeSecondaryMusic(false, false, 0.5f, SFX.Instance.secondaryGameMusic.volume);
		Debug.Log ("Faded out secondary music from retry button");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		Debug.Log ("Faded in main music from retry button");
	}

	public void RetryLevelFromPause()
	{
		Time.timeScale = 1;
		SFX.Instance.FadeMainMusic(false, false, 0.5f, SFX.Instance.secondaryGameMusic.volume);
		Debug.Log ("Faded out secondary music from retry button");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		SFX.Instance.FadeMainMusic(true, true, 1.5f, 0);
		Debug.Log ("Faded in main music from retry button");
	}

	public void LoadLevelSelect()
	{
		//Time.timeScale = 1;
		SFX.Instance.FadeSecondaryMusic(true, true, 0.5f, 0);
		SceneManager.LoadScene ("LevelSelect");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent

	}

	public void LoadLevelSelectFromPause()
	{
		Time.timeScale = 1;
		SFX.Instance.FadeMainMusic (false, false, 0.5f, SFX.Instance.mainGameMusic.volume);
		SceneManager.LoadScene ("LevelSelect");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		SFX.Instance.FadeSecondaryMusic(true, true, 1.5f, 0);

	}

}
