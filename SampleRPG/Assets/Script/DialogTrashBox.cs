using UnityEngine;
using System.Collections;

public class DialogTrashBox : MonoBehaviour {

    // エディタのインスペクタで、この変数にヒエラルキーにある Canvas を割り当ててください。
    public Canvas canvasConfirmAllHoshiDelete = null;

    // Use this for initialization
    void Start() {
        // ダイアログを表示するときまで、 Canvas を無効にしておく。
        if (canvasConfirmAllHoshiDelete != null)
        {
            canvasConfirmAllHoshiDelete.enabled = false;
        }
    }

    // クリックされた
    void OnMouseUpAsButton()
    {
        confirmAllHoshiDelete();
    }

    // ダイアログを表示
    public void confirmAllHoshiDelete()
    {
        // Canvas を有効にする
        if (canvasConfirmAllHoshiDelete != null)
        {
            canvasConfirmAllHoshiDelete.enabled = true;
        }
    }

    // Yes ボタンと関連づけたイベントハンドラ関数
    public void onButtonYes()
    {
        // Canvas を無効にする。(ダイアログを閉じる)
        canvasConfirmAllHoshiDelete.enabled = false;

        // アイテムの削除処理(省略)
    }

    // No ボタンと関連づけたイベントハンドラ関数
    public void onButtonNo()
    {
        // Canvas を無効にする。(ダイアログを閉じる)
        canvasConfirmAllHoshiDelete.enabled = false;
    }
}