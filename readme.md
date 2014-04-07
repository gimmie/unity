# Gimmie for Unity

This repository is Gimmie files for integrating Gimmie iOS/Android lib to Unity project.

## Android

- [Download plugin](http://gimmieworld.s3.amazonaws.com/sdk/gimmie_Android_SDK_1.5.2_Touchten.zip) and extract all files into `Assets/Plugins`
- Create a binding class, you can use a basic one here: [GimmieBinding.cs](GimmieBinding.cs).
- Modify AndroidManifest.xml to include all the Gimmie declarations. See [example here](android/AndroidManifest.xml).

Sample project structures

    Assets
        Plugins
            Android
                Gimmie_Android_SDK
                AndroidManifest.xml
                GimmieBinding.cs

## iOS

- Building and export project from Unity
- [Download Gimmie iOS SDK](http://gimmieworld.s3.amazonaws.com/sdk/gimmie_iOS_SDK_2.3.0.zip) and extract into exported project.
- Build the project with Xcode

## Initialize

Call the following to bind Gimmie to each new context, for example in Star():

    void Start() {
        GimmieBinding.initGimmie();
    }

After init Gimmie it will automatically login user with `guest:randomid` which is anonymous user. Anonymous user is the same as
normal user, it can earn points and redeem but it also can transfer points to other user. To transfer the points, call `Login`
with your internal user id and points will get merge.

To check is user anonymous, call `Gimmie.IsAnonymousUser()`.

## Showing rewards catalog and trigger events

To show rewards catalog on any button add below code to Unity logic file.

    GimmieBinding.ShowGimmieRewardsCatalogue();

To trigger event

    GimmieBinding.TriggerGimmieEvent("event_name");

## Known Issues

- Duplicated scribe library

        UNEXPECTED TOP-LEVEL EXCEPTION:
        java.lang.IllegalArgumentException: already added: Lorg/scribe/builder/api/Api;

In plugin folder, remove scribe-(version).jar file because other library already has that in dependencies.

- Duplicated Android Supported library

        UNEXPECTED TOP-LEVEL EXCEPTION:
        java.lang.IllegalArgumentException: already added: Landroid/support/v4/hardware/display/DisplayManagerCompat;

In plugin folder, remove android-support-v4.jar file because other library already has that in dependencies.

- Missing Sherlock resources

        /path/in/game/gimmie_Android_SDK_Unity/res/values/gm__styles.xml:4: error: Error retrieving parent for item: No resource found that matches the given name '@style/Theme.Sherlock.Light'.
        /path/in/game/gimmie_Android_SDK_Unity/res/values/gm__styles.xml:5: error: Error: No resource found that matches the given name: attr 'actionBarStyle'.

Copy all res and jar files including ActionBar Sherlock and ViewPager in plugins folder to your games.

