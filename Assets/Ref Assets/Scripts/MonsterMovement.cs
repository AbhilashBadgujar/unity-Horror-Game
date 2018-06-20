using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour {


	#region //Public Variables
	public float timeBtn;	//make the timmer limit and stop time
	public Transform player;// stores players transform
	#endregion

	#region //Serilized
	[SerializeField] ObjectiveManager obj;	//check for the objectives completing
	#endregion

	#region //Private Variables

	float timmer;		//make a timmer
	Vector3 pos; 		//contains player pos and store it
	NavMeshAgent nav;	//nav mesh for movement 
	#endregion

	// Use this for initialization
	void Start () {

		//refs
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		//checks for the objective completing of pipe 1 and then make it chase the player
		if (obj.objectives[1].objectives == true) Chase ();

	}

	//make the monster go to the pos Vector.
	void Chase(){
		//adds the timer 
		if (timmer <= timeBtn) 
			timmer += Time.deltaTime;

		//check for the player position  based on timmer 	
		if (timeBtn <= timmer) {
			pos = player.position;
			timmer = 0;
		}

		//set the desitantion to pos vector
		nav.SetDestination(pos);
	}
		
}
