using UnityEngine;
using System.Collections;

namespace NS_ScenarioData
{
	public static class ScenarioData
    {
        private static string datetimeStr = System.DateTime.Now.ToString();
		public static string data1 = 
			  "文字が表示されるまでの時間を設定し、時間の進行で表示される文字の範囲を取得<NEXT>"
			+ "bbb<NEXT>"
			+ "文字の表示が完了していなかったら文字の表示時間を0にして強制的に文字列を表示<NEXT>"
			+ "abcdfegabcdfegabcdfegabcdfegabcdfegabcdfegabcdfegabcdfegabcdfeg<NEXT>"
			+ "<FIRST>naemの攻撃!!! <color=red>" + datetimeStr + "ダメージ</color>を与えた!!<NEXT>"
			+ "<EFFECT:003>textextextextextexダメージを与えたダメージを与えた!!<NEXT>"
			+ "文字,BBB,文字,3.141592,2.7182,6.022\r\n<NEXT>"
			+ "文字,文字,文字,3.141592,2.7182,6.022\r\n";
    }
}