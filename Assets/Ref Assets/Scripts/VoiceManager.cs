using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour {


	#region //public Varibles
	public static VoiceManager vc;
	public AudioClip[] dialogs;
	#endregion
	#region // private region
	AudioSource audio;
	#endregion

	// Use this for initialization
	void Start () {
		vc = this;		//ref to this object;
		audio = GetComponent<AudioSource> ();
		StartCoroutine( PlayDialog (dialogs[0],2f, 0f));	//dialog 1 starts
	}

	//play dialog over the game and also refed to other scripts
	public IEnumerator PlayDialog(AudioClip dialog, float waitTime, float delay){
		yield return new WaitForSeconds (delay);
		audio.clip = dialog;
		audio.PlayDelayed (waitTime);
	}
}
