using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;

public class GimmieBinding : MonoBehaviour {
	#if UNITY_IPHONE
	[DllImport ("__Internal")]
	private static extern void NativeIOSAnonymousLogin();
	[DllImport ("__Internal")]
	private static extern bool NativeIOSIsAnonymous();
	[DllImport ("__Internal")]
	private static extern void NativeIOSLogin(string username);
	[DllImport ("__Internal")]
	private static extern void NativeIOSLogout();
	[DllImport ("__Internal")]
	private static extern void NativeIOSUpdateGimmieCountry(string country);
	[DllImport ("__Internal")]
	private static extern void NativeIOSShowGimmieRewards();
	[DllImport ("__Internal")]
	private static extern void NativeIOSBindGimmieNotification();
	[DllImport ("__Internal")]
	private static extern void NativeIOSTriggerEvent(string eventname);
	#endif
	
	public static void InitGimmie(){
		#if UNITY_IPHONE
		Debug.Log("Login to gimmie");
		NativeIOSBindGimmieNotification();
		NativeIOSAnonymousLogin();
		#endif
		
		#if UNITY_ANDROID
		AndroidJNI.AttachCurrentThread();
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
		
		AndroidJavaClass gimmieComponent = new AndroidJavaClass("com.gimmie.GimmieComponents");
		gimmieComponent.CallStatic("registerUnityHandler");

		// Auto call login.
		gimmieComponent.CallStatic<AndroidJavaObject>("getInstance", activity);
		#endif
	}
	
	public static void Login(string user) {
		Debug.Log("Login to gimmie");

		#if UNITY_IPHONE
		NativeIOSLogin(user);
		#endif
		
		#if UNITY_ANDROID
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
		
		AndroidJavaClass gimmieComponent = new AndroidJavaClass("com.gimmie.GimmieComponents");
		AndroidJavaObject componentInstance = gimmieComponent.CallStatic<AndroidJavaObject>("getInstance", activity);
		AndroidJavaObject service = componentInstance.Call<AndroidJavaObject>("getGimmie");
		service.Call ("loginAndTransferFromGuest", user, "", "");
		#endif
	}

	public static void Logout() {
		#if UNITY_IPHONE
		NativeIOSLogout();
		#endif

		#if UNITY_ANDROID
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
		
		AndroidJavaClass gimmieComponent = new AndroidJavaClass("com.gimmie.GimmieComponents");
		AndroidJavaObject componentInstance = gimmieComponent.CallStatic<AndroidJavaObject>("getInstance", activity);
		AndroidJavaObject service = componentInstance.Call<AndroidJavaObject>("getGimmie");
		service.Call ("logout");
		#endif
	}

	public static bool IsAnonymousUser() {
		#if UNITY_IPHONE
		return NativeIOSIsAnonymous();
		#endif

		#if UNITY_ANDROID
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
		
		AndroidJavaClass gimmieComponent = new AndroidJavaClass("com.gimmie.GimmieComponents");
		AndroidJavaObject componentInstance = gimmieComponent.CallStatic<AndroidJavaObject>("getInstance", activity);
		AndroidJavaObject service = componentInstance.Call<AndroidJavaObject>("getGimmie");
		String user = service.Call<String> ("getUser");
		return user.StartsWith("guest:", true, null);
		#endif
	}
	
	public static void UpdateCountry(string countryCode) {
		#if UNITY_IPHONE
		NativeIOSUpdateGimmieCountry(countryCode);
		#endif
		
		#if UNITY_ANDROID
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
				
		AndroidJavaClass gimmieComponent = new AndroidJavaClass("com.gimmie.GimmieComponents");
		AndroidJavaObject componentInstance = gimmieComponent.CallStatic<AndroidJavaObject>("getInstance", activity);
		AndroidJavaObject service = componentInstance.Call<AndroidJavaObject>("getGimmie");
		service.Call ("setCountry", countryCode);
		#endif
	}
	
	public static void ShowGimmieRewardsCatalogue(){
		#if UNITY_IPHONE
		NativeIOSShowGimmieRewards();
		#elif UNITY_ANDROID
		AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
		
		AndroidJavaClass components = new AndroidJavaClass("com.gimmie.GimmieComponents");
		components.CallStatic("showRewardCatalogue", activity);
		#endif
	}
	
	public static void TriggerGimmieEvent(string eventName){
		#if UNITY_IPHONE
		NativeIOSTriggerEvent(eventName);
		#elif UNITY_ANDROID
		AndroidJavaClass components = new AndroidJavaClass("com.gimmie.GimmieComponents");
		components.CallStatic("triggerEvent", eventName);
		#endif
	}
	
	public void HandleNeedLogin(string message) {
		BroadcastMessage ("GimmieNeedLogin", null, SendMessageOptions.DontRequireReceiver);
	}
}
