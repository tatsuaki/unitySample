using UnityEngine;
using System.Collections;

// オブジェクトを点滅させるクラス
public class Blinker : MonoBehaviour {
	public float interval = 1.0f;   // 点滅周期

	// 点滅コルーチンを開始する
	void Start() {
		StartCoroutine("Blink");
	}

	// 点滅コルーチン
	IEnumerator Blink() {
		while ( true ) {
			yield return new WaitForSeconds(interval);
		}
	}
}
