using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TorchManager : MonoBehaviour {

	#region //Serilized
	[SerializeField] float maxIntersity; //sets the max intensity
	#endregion
	#region //Private Variables
	Light light;		//ref to the light
	float timmer;
	#endregion
	#region //Public Variables
	public int charge;	//store the charge of the torch
	public bool working = true; //check the torch is on or not if true it is working and false not working
	#endregion

	// Use this for initialization
	void Start () {
		//refs
		light = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		//on and off the torch
		if (Input.GetMouseButtonUp (1))
			working = working ? !working : !working;

		Life ();
	}

	//take care of the life of the torch
	void Life(){
		
		//timmer check
		if (charge > 0) {
			timmer += Time.deltaTime;
			//reduce the charge and reset the timmer
			if ((timmer >= 5f) && working) {
				charge--;
				timmer = 0f;
			}
			//change the state of working
			if (working)
				light.intensity = maxIntersity;
			else
				light.intensity = 0f;
		} else if (charge <= 0) //if no charge is left
			light.intensity = 0f;

	}
}
