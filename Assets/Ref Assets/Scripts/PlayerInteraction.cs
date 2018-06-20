using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteraction : MonoBehaviour {	
	public bool hitable = false;

	#region //Serilized
	[SerializeField] Animator anim;
	[SerializeField] AudioSource sound;
	[SerializeField] AudioClip[] audios;
	#endregion
	#region //private region
	int pipes = 1;
	Ray ray;
	RaycastHit hit;
	#endregion
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			ray.origin = transform.position;
			ray.direction =transform.TransformDirection( Vector3.forward);
			if (Physics.Raycast (ray, out hit, 5f)) {
				//check for the pickable object
				if (hit.collider.gameObject.tag == "pickups") {		
					//check for hammer
					if (hit.collider.gameObject.name == "Hammer") {
						hitable = true;
						//Destroy (hit.collider.gameObject);
						Destroy(GameObject.Find("hammer 1"));
						ObjectiveManager.objectiManager.objectives [0].objectives = true;
						ObjectiveManager.objectiManager.UpdateText ();
						sound.clip = audios [0];
						sound.Play ();
						StartCoroutine( VoiceManager.vc.PlayDialog (VoiceManager.vc.dialogs [1], 1f, 2f)); 
						//check for the hammer
					}else if (hit.collider.gameObject.name == "lighter") {
						print ("did");
						Destroy (hit.collider.gameObject);
						ObjectiveManager.objectiManager.objectives [7].objectives = true;
						ObjectiveManager.objectiManager.UpdateText ();
						sound.clip = audios [0];
						sound.Play ();
						StartCoroutine( VoiceManager.vc.PlayDialog (VoiceManager.vc.dialogs [8], 1f, 2f)); 
					}
					//check for the pipes
				} else if (hit.collider.gameObject.tag == "pipes" && hitable) {
					
					ObjectiveManager.objectiManager.objectives [pipes].objectives = true;
					pipes++;
					anim.SetTrigger ("attack");
					hit.collider.gameObject.GetComponent<MeshRenderer> ().enabled = false;
					hit.collider.gameObject.transform.GetChild (0).gameObject.SetActive (true);
					hit.collider.gameObject.transform.GetChild (1).gameObject.SetActive (true);
					hit.collider.gameObject.tag = "Untagged";
					ObjectiveManager.objectiManager.UpdateText ();
					sound.clip = audios [1];
					sound.Play ();
					StartCoroutine(VoiceManager.vc.PlayDialog (VoiceManager.vc.dialogs [pipes], 1f, VoiceManager.vc.dialogs [pipes].length));
				}
					
			}
		}
	}
}
