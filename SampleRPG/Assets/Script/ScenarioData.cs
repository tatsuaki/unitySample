using UnityEngine;
using System.Collections;

namespace NS_ScenarioData
{
	public static class ScenarioData
    {
        private static string datetimeStr = System.DateTime.Now.ToString();
		public static string data1 = 
			  "文字が表示されるまでの時間を設定し、時間の進行で表示される文字の範囲を取得する訳です。<NEXT>"
			+ "bbb<NEXT>"
			+ "文字の表示が完了していなかったら、文字の表示時間を0にして強制的に文字列を表示文字の表示が完了していなかったら、<NEXT>"
			+ "文字の表示時間を0にして強制的に文字列を表示<NEXT>"
			+ "naemの攻撃!!! <color=red>" + datetimeStr + "ダメージ</color>を与えた!!<NEXT>"
			+ "<EFFECT:003>textextextextextexダメージを与えたダメージを与えた!!<NEXT>"
			+ "333,BBB,CCC,3.141592,2.7182,6.022\r\n<NEXT>"
			+ "555,BBB,CCC,3.141592,2.7182,6.022\r\n";

		/*
             "111,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n",
			+"文字が表示されるまでの時間を設定し、時間の進行で表示される文字の範囲を取得する訳です。"  + "\r\n"
            +"333,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n"
            +"444,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n"
            +"555,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n"
            +"666,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n"
            +"777,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n"
            +"888,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n"
            +"999,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n"
		}
		*/
    }
}