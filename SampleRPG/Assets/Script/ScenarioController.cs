using UnityEngine;
using System.Collections;
using UnityEngine.UI;	// uGUIの機能を使うお約束
using NS_ScenarioData;

public class ScenarioController : MonoBehaviour {

	string[] NEXT    = new string[]{"<NEXT>"};
	const string EFFECT  = "<EFFECT:";

	public string[] scenarioData; // シナリオを格納する
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
		SetNextLine();
	}

	public void PanelClicked () 
	{
		Debug.Log ("PanelClicked.");
	}

	void Update () 
	{
	//	Debug.Log("Update");
		// 文字の表示が完了してるならクリック時に次の行を表示する
		if (null == currentText) {
			return;
		}

		if( IsCompleteDisplayText ){
			if(currentLine < scenarioLength && Input.GetMouseButtonDown(0)){
		//	if(currentLine < scenarios.Length && textClick()){
				SetNextLine();
			}
		}else{
		// 完了してないなら文字をすべて表示する
			if(Input.GetMouseButtonDown(0)){
				timeUntilDisplay = 0;
			}
		}

		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
		if( displayCharacterCount != lastUpdateCharacter ){
			uiMessageText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}

		if (isEffect)
		{
			EffectFlashing();
		} else {
			ClearEffect();
		}
			
	}

	void SetNextLine()
	{
		string current = scenarioData[currentLine];
		Debug.Log("SetNextLine = " + current);
		// <EFFECT:000>
		if(0 == current.IndexOf(EFFECT)){
			string effectNum = current.Substring(8, 3);
			Debug.Log("effectNum = " + effectNum);
			uiEffectInfoText.text = effectNum;
			currentText = current.Substring(12);

			isEffect = true;
		} else {
			uiEffectInfoText.text = "NONE";
			currentText = current;

			isEffect = false;
			//一致しなかった
		}
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
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
		Debug.Log("Flashing");
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
