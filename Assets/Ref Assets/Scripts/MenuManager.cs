using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	#region //Serialized variables
	[SerializeField] GameObject startPanel;
	[SerializeField] GameObject creditPanel;
	[SerializeField] GameObject helpPanel;
	#endregion

	void Start(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	//button method called when a button is clicked
	public void OnClickButton(Button btn){
		switch (btn.name) {
			
			//this for play button change to main scene
			case "Play":
				SceneManager.LoadScene (1);
				break;
			//this for Credits button change other pannels to the Credits pannel
			case "Credits":
				startPanel.SetActive (false);
				creditPanel.SetActive (true);
				helpPanel.SetActive (false);
				break;
			//this for Exit button close game
			case "Exit":
				Application.Quit ();
				break;
			//this for Help button change other pannels to the help pannel
			case "Help":
				startPanel.SetActive (false);
				creditPanel.SetActive (false);
				helpPanel.SetActive (true);
				break;
			//this for Back button change other pannels to the main menu pannel
			case "Back":
				startPanel.SetActive (true);
				creditPanel.SetActive (false);
				helpPanel.SetActive (false);
				break;
		}
	}
}
