using UnityEngine;
using System.Collections;

public class ScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//	Camera.main.ScreenToWorldPoint(Vector3 pos);
		// TODO タッチ座標を取得
		Vector3 screenPos = Input.mousePosition;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
		Debug.Log ("worldPos." + worldPos.x);
		//var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
	}
}
