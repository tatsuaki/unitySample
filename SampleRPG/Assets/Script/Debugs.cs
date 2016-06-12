#if !UNITY_EDITOR
#define DEBUG_LOG_OVERWRAP
#endif

using UnityEngine;

#if DEBUG_LOG_OVERWRAP
public static class Debugs
{
    static public void Break(){
		if( IsEnable() ) {
			UnityEngine.Debug.Break();
		}
    }

    static public void Log( object message ){
        if( IsEnable() ){
            UnityEngine.Debug.Log( message );
        }
    }
    static public void Log( object message, Object context ){
        if( IsEnable() ) {
            UnityEngine.Debug.Log( message, context );
        }
    }

    static bool IsEnable(){ return UnityEngine.Debug.isDebugBuild; }
}
#endif