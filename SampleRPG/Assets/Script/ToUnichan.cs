using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ToUnichan : UIBehaviour {

	protected override void Start() {
		base.Start();
		Debug.Log ("Start");
		// Buttonクリック時、OnClickメソッドを呼び出す
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	void OnClick() {
		Debug.Log ("OnClick");
		// 「GameScene」シーンに遷移する
		SceneManager.LoadScene("Unichan");
	}
}