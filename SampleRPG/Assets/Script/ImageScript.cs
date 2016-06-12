using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageScript : MonoBehaviour {
	public GameObject obj;
	private Vector3 bases;
	
	void Start(){
		bases = obj.transform.position;
	}

	void Update () {
		bases.x += 0.2f;
		obj.transform.localPosition = bases;
	}
}
