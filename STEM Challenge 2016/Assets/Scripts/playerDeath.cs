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
		yield return new WaitForSeconds(2.0f);

		Destroy(player);
		Time.timeScale = 0;
		Instantiate(playerDeathMenu);
	}

	IEnumerator FadeFromBlack ()
	{
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
		yield return new WaitForSeconds(0);
	}

	public void RetryLevel()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
	}

	public void LoadLevelSelect()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene ("LevelSelect");
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent
	}
}
