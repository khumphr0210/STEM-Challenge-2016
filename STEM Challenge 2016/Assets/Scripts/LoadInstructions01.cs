using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadInstructions01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		FadeManager.Instance.Fade (false, 2.0f);
	}
	
	public void loadInstructions01 (){
		StartCoroutine (FadeLoadFade ());
	}

	IEnumerator FadeLoadFade ()
	{
		//FadeManager.Instance.FadeIn ();
		FadeManager.Instance.Fade(true, 2.0f); //fade to black
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene ("Instructions01");
		//FadeManager.Instance.FadeOut ();
		FadeManager.Instance.Fade (false, 2.0f); //fade to transparent

	}
}
