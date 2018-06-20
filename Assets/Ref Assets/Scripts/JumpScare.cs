using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class JumpScare : MonoBehaviour {

	#region //Serialized variables
	[SerializeField] GameObject normalCam;
	[SerializeField] GameObject jumpScareCam;
	[SerializeField] GameObject player;
	[SerializeField] GameObject[] zombie;
	[SerializeField] AudioSource sound;
	[SerializeField] float fov;
	[SerializeField] SphereCollider col;
	#endregion


	//Check for the monster is in the sight or not 
	void OnTriggerStay(Collider other){
		if (other.tag == "Ghost") {
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);
			if (angle < fov * 0.5f) {
				RaycastHit hit;
				if (Physics.Raycast(transform.position, direction.normalized, out hit, col.radius)) 
					if (hit.collider.tag == "Ghost") 
						StartCoroutine (End());
			}
		}
	}

	//The JumpCare method
	IEnumerator End(){
		player.GetComponent<FirstPersonController> ().enabled = false;
		yield return new WaitForSeconds (0.3f);
		Destroy (zombie[0]);	//Destroy the model no 0
		Destroy (zombie[1]);	//Destroy the model no 1
		yield return new WaitForSeconds (0.5f);
		if (!sound.isPlaying) sound.Play ();
		jumpScareCam.SetActive (true);
		normalCam.SetActive (false);
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene (0);

	}
		
}
