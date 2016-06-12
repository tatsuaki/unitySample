using UnityEngine;
using UnityEngine.UI; //追加し忘れ注意
using System.Collections;

public class ImageScript : MonoBehaviour {
//	private RectTransform images;
	public GameObject obj;
	private Vector3 bases;
	
	void Start(){
    //	images = GameObject.Find("Images").GetComponent<RectTransform>();
	//	images.sizeDelta = new Vector2(x,y);　//サイズが変更できる
		bases = obj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 Position = obj.transform.position;
	//	Debug.Log ("Update. Position.x = " + Position.x );
		bases.x += 0.2f;
		obj.transform.localPosition = bases;
	}
}
