using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

	public GameObject levelCompleteMenu;

	void OnTriggerEnter (Collider finish)
	{
		
		//Debug.Log ("scene: " + SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex).ToString());
		Debug.Log("scene: " + SceneManager.GetActiveScene().buildIndex);

		GameObject.Find ("Player").GetComponent<Rigidbody> ().angularDrag = 5;
		GameObject.Find ("Player").GetComponent<Rigidbody> ().drag = 5;
		GameObject.Find ("Player").GetComponent<Rigidbody> ().mass = 10;
		GameObject.Find ("Player").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;


		StartCoroutine (FadeToBlack ());
	}

	IEnumerator FadeToBlack ()
	{
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		yield return new WaitForSeconds(2.0f);

		Time.timeScale = 0;
		Instantiate(levelCompleteMenu);
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
	public void NextLevel ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent

	}
}
