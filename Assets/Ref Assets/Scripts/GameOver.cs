using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	#region //EndGame

	#region //Serialized variables
	[SerializeField] Animator playerAnim;
	[SerializeField] Animator filterAnim;
	[SerializeField] GameObject player;
	#endregion

	//Check for the end game trigger
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" && ObjectiveManager.objectiManager.objectives[7].objectives == true) {
			StartCoroutine (EndGame ());
		}
	}

	//the end game method
	IEnumerator EndGame(){
		player.GetComponent<FirstPersonController> ().enabled = false;
		filterAnim.SetBool ("Start", true);

		yield return new WaitForSeconds (6f);
		SceneManager.LoadScene (0);		// back to main menu scene
	}

	#endregion


	#region //Pause Game
	public bool paused = false;
	public GameObject ingamePannel;
	public GameObject pausePannel;


	void Update(){
		if (Input.GetKeyUp(KeyCode.Escape)) {
			paused = paused ? !paused : !paused;
		}
		Pause ();
	}

	void Pause(){
		if (paused) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			player.GetComponent<FirstPersonController> ().enabled = false;
			Time.timeScale = 0f;
			Time.fixedDeltaTime = 0f;
			pausePannel.SetActive (true);
			ingamePannel.SetActive (false);

		} else {
			player.GetComponent<FirstPersonController> ().enabled = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Time.timeScale = 1;
			Time.fixedDeltaTime = 0.02f;
			pausePannel.SetActive (false);
			ingamePannel.SetActive (true);
		}
	}

	public void Resume(){
		paused = false;
	}
	public void OnExit(){
		SceneManager.LoadScene (0);
	}
	#endregion 
}
