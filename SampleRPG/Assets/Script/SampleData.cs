using UnityEngine;
using System.Collections;

namespace NS_SampleData
{
    public static class SampleData
    {
        private static string datetimeStr = System.DateTime.Now.ToString();
		public static string[] data1 = new string[]{
			"文字が表示されるまでの時間を設定し、時間の進行で表示される文字の範囲を取得する訳です。",
			"bbb",
			"文字の表示が完了していなかったら、文字の表示時間を0にして強制的に文字列を表示文字の表示が完了していなかったら、" +
			"文字の表示時間を0にして強制的に文字列を表示",
			"naemの攻撃!!! <color=red>" + datetimeStr + "ダメージ</color>を与えた!!",
			"333,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n",
			"555,BBB,CCC,3.141592,2.7182,6.022"  + "\r\n"
		};
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