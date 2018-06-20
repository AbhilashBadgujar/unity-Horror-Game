using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour {
	#region //public Variables
	public Text objText;
	public static ObjectiveManager objectiManager;
	public Objective[] objectives;
	#endregion
	#region //Serialized Variables
	[SerializeField] GameObject lighter;
	#endregion

	// Use this for initialization
	void Start () {
		objectiManager = this;
		UpdateText ();
	}	

	void Update () {
		//check for the lighter objective
		if (ObjectiveManager.objectiManager.objectives [6].objectives == true) 
			lighter.SetActive (true);
		
	}

	//update the objectives text
	public void UpdateText(){
		for (int i = 0; i < objectives.Length; i++) {
			if (objectives [i].objectives == true) {
				objText.text = objectives [i + 1].discription;
			} else if(objectives [0].objectives == false) {
				objText.text = objectives [0].discription;
			}
		}
	}
}

//stores data for the objectives and the description
[System.Serializable]
public class Objective{
	[TextArea]
	public string discription;
	public bool objectives;

}
