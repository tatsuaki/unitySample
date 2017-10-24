using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class UnityMoviePlayer : MonoBehaviour {

	//　VideoPlayerコンポーネント
	private VideoPlayer mPlayer;
	//　AudioSourceコンポーネント
	private AudioSource audioSource;
	//　内部に保存したテクスチャを表示するRawImageUI
	public RawImage rImage;
	// public VideoClip mVide;
	//　内部スクリプトを出力するUIにTextureをセットしたかどうか
	private bool check = false;

	// Use this for initialization
	void Start () {
		mPlayer = GetComponent <VideoPlayer> ();
		//　スクリプトでAudioOutputModeをAudioSourceに変更
		mPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		//　Directモードはまだサポートされていない為使えない
		//		mPlayer.audioOutputMode = VideoAudioOutputMode.Direct;
		audioSource = GetComponent <AudioSource> ();
		//　オーディオトラックを有効にする
		mPlayer.EnableAudioTrack (0, true);
		//　AudioOutPutがAudioSourceの時にスクリプトからAudioSourceを設定する。
		mPlayer.SetTargetAudioSource (0, audioSource);
		//　スタートした時にすぐ再生する
		mPlayer.Play ();
	}

	// Update is called once per frame
	void Update () {
		//　内部に保存しているテクスチャを設定
		if (mPlayer.texture != null && !check) {
			Debug.Log ("Set");
			rImage.texture = mPlayer.texture;
			check = true;
		}
		//　マウスの左クリックで再生と停止を切り替える
		if (Input.GetButtonDown ("Fire1")) {
			//　再生中でなければ再生
			if (!mPlayer.isPlaying) {
				mPlayer.Play ();
				//　再生中であれば停止
			} else {
				mPlayer.Pause ();
			}
		}
	}
}