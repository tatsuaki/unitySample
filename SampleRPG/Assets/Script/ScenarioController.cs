using UnityEngine;
using System.Collections;
using UnityEngine.UI;	// uGUIの機能使用時
using NS_ScenarioData;

using UnityEngine.SceneManagement;

/**
 *  Scenarioコントローラー
 */
public class ScenarioController : MonoBehaviour {
	public GameObject obj;
	string[] NEXT    = new string[]{"<NEXT>"};
	const string EFFECT  = "<EFFECT:";
	const string FIRST   = "<FIRST>";
	
	[SerializeField] Camera _camera = null;
	[SerializeField] public ParticleSystem tapEffect;              // タップエフェクト

	public string[] scenarioData;
	[SerializeField] public Text uiMessageText; // uiTextへの参照を保つ
	[SerializeField] public Text uiEffectInfoText; // uiTextへの参照を保つ
	private int scenarioLength;

	[SerializeField][Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f;

	private string currentText = string.Empty;
	private float timeUntilDisplay = 0;
	private float timeElapsed = 1;
	private int currentLine = 0; // 現在の行番号
	private int lastUpdateCharacter = -1;
	
    private GameObject effect_panel;
    // Alpha増減値(点滅スピード調整)
    private float _Step = 0.1f;
	private bool isEffect = false;

	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText 
	{
		get { return  Time.time > timeElapsed + timeUntilDisplay; }
	}

	void Start()
	{
		Debug.Log("Start");
		
		this.effect_panel = GameObject.Find("EffectPanel");
		
		string datas = ScenarioData.data1;
		scenarioData = datas.Split(NEXT, 200, System.StringSplitOptions.None);
		scenarioLength = scenarioData.Length;
		SetNextScriptLine();
	}

	public void PanelClicked () 
	{
		Debug.Log ("PanelClicked.");
	}

	void Update () 
	{

	//	Vector3 screenPos = Input.mousePosition;
	//	Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
	//	Debug.Log ("worldPos." + worldPos.x);
	//	Debug.Log("Update");
		if (null == currentText) {
			return;
		}

		// 文字表示が完了時
		if( IsCompleteDisplayText ){
			if(currentLine < scenarioLength && Input.GetMouseButtonDown(0)){
				SetNextScriptLine();
			}
		} else {
			// 文字表示未完了時文字をすべて表示
			if(Input.GetMouseButtonDown(0)){
				timeUntilDisplay = 0;
			}
		}
		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
	//	Debug.Log("Update displayCharacterCount = " + displayCharacterCount);
		if( displayCharacterCount != lastUpdateCharacter ){
			uiMessageText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}

		if (isEffect) {
			EffectFlashing();
		} else {
			ClearEffect();
		}
		if(Input.GetMouseButtonUp(0)){
			//ここで処理
			// Vector3 screenPos = Input.mousePosition;
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward);
			// Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
			Debug.Log ("Input.mousePosition." + Input.mousePosition.ToString());
			Debug.Log ("worldPos_camera.transform.forward" + _camera.transform.forward.ToString());
			Debug.Log ("worldPos." + pos.ToString());

			//	var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
			// pos = _camera.ScreenToWorldPoint(Input.mousePosition);
			tapEffect.transform.position = pos;
			tapEffect.Emit(1);
		}
	}

	void SetNextScriptLine() {
		string current = scenarioData[currentLine];
		//	Debug.Log("SetNextScriptLine = " + current);
		ClearEffect();

		// <EFFECT:000>
		if(0 == current.IndexOf(EFFECT)) {
			string effectNum = current.Substring(8, 3);
			Debug.Log("effectNum = " + effectNum);
			uiEffectInfoText.text = effectNum;
			currentText = current.Substring(12);

			isEffect = true;
		// <FIRST>
		} else if (0 == current.IndexOf(FIRST)) {
			uiEffectInfoText.text = FIRST;
			currentText = current.Substring(FIRST.Length);
			uiMessageText.text = currentText;

			// プレハブを取得
			GameObject prefab = (GameObject)Resources.Load ("Prefabs/FT_ExplosioMaster_Explosion01");
			// プレハブからインスタンスを生成
			Instantiate (prefab, obj.transform.position, Quaternion.identity);
		} else {
			uiEffectInfoText.text = "NONE";
			currentText = current;
		}

		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		Debug.Log("SetNextScriptLine timeUntilDisplay = " + timeUntilDisplay);
		timeElapsed = Time.time;
		currentLine ++;
		if (currentLine >= scenarioLength) {
			currentLine = 0;
		}
		lastUpdateCharacter = -1;
	}

	void ClearEffect() 
	{
		isEffect = false;
		this.effect_panel.GetComponent<Image>().color = new Color(255, 0, 0, 0);
	}

	/**
	 * 点滅
	 */
	void EffectFlashing() 
	{
	//	Debug.Log("Flashing");
		if (null == this.effect_panel) 
		{
			return;
		}
		Debug.Log("Flashing obj = " + this.effect_panel.name);
		// 現在のAlpha値を取得
		float toColor = this.effect_panel.GetComponent<Image>().color.a;
		// Alphaが0 または 1になったら増減値を反転
		if (toColor < 0 || toColor > 1)
		{
			_Step = _Step * -1;
		}
		// Alpha値を増減させてセット
		this.effect_panel.GetComponent<Image>().color = new Color(255, 0, 0, toColor + _Step);
	}
}
