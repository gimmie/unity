using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class GimmieBinding : MonoBehaviour {
	#if UNITY_IPHONE
	[DllImport ("__Internal")]
	private static extern void UpdateGimmieUser(string username);
	[DllImport ("__Internal")]
	private static extern void RemoveGimmieUser();
	[DllImport ("__Internal")]
	private static extern void ShowGimmieRewards();
	[DllImport ("__Internal")]
	private static extern void BindGimmieNotification();
	[DllImport ("__Internal")]
	private static extern void TriggerEvent(string eventname);
	[DllImport ("__Internal")]
	private static extern void UpdateGimmieCountry(string country);
	#endif

	public static void initGimmie(){
		// Binding Gimmie to Activity or View first.
		AndroidJNI.AttachCurrentThread();
		
		#if UNITY_IPHONE
		Debug.Log("Login to gimmie");
		BindGimmieNotification();
		#endif
		
		#if UNITY_ANDROID
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
		
		AndroidJavaClass gimmie = new AndroidJavaClass("com.gimmie.Gimmie");
		AndroidJavaObject service = gimmie.CallStatic<AndroidJavaObject>("getInstance", activity);
		service.Call("updateContext", activity);
		#endif
		
		Login("test");
	}
	
	public static void Login(string user) {
		// Login with given user id.

		#if UNITY_IPHONE
		Debug.Log("Login to gimmie");
		BindGimmieNotification();
		UpdateGimmieUser(user);
		#endif
		
		#if UNITY_ANDROID
		Debug.Log("Login to Gimmie..");
		
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
		
		AndroidJavaClass gimmie = new AndroidJavaClass("com.gimmie.Gimmie");
		AndroidJavaObject service = gimmie.CallStatic<AndroidJavaObject>("getInstance", activity);
		service.Call ("login", user);
		#endif
	}
	
	public static void UpdateCountry(string countryCode) {
		#if UNITY_IPHONE
		UpdateGimmieCountry(countryCode);
		#endif
		
		#if UNITY_ANDROID
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
		
		AndroidJavaClass gimmie = new AndroidJavaClass("com.gimmie.Gimmie");
		AndroidJavaObject service = gimmie.CallStatic<AndroidJavaObject>("getInstance", activity);
		service.Call ("setCountry", countryCode);
		#endif
	}
	
	public static void ShowGimmieRewardsCatalogue(){
		#if UNITY_IPHONE
		ShowGimmieRewards();
		#elif UNITY_ANDROID
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
		
		AndroidJavaClass components = new AndroidJavaClass("com.gimmie.components.GimmieComponents");
		components.CallStatic("showRewardCatalogue", activity);
		#endif
	}
	
	public static void TriggerGimmieEvent(string eventName){
		#if UNITY_IPHONE
		TriggerEvent(eventName);
		#elif UNITY_ANDROID
		AndroidJavaClass components = new AndroidJavaClass("com.gimmie.components.GimmieComponents");
		components.CallStatic("triggerEvent", eventName);
		#endif
	}
}