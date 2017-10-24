using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		Handheld.PlayFullScreenMovie ("op.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
