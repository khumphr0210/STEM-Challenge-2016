using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {

	public static SFX Instance { set; get; }
	public AudioSource lockExplosion;
	public AudioSource keyCollect;
	public AudioSource finish;
	public AudioSource mainGameMusic;
	public AudioSource secondaryGameMusic;
	public AudioSource boingSound;
	public AudioSource glassSound;


	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
		Instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
