# Gimmie for Unity

This repository is Gimmie files for integrating Gimmie iOS/Android lib to Unity project.

## Android

- [Download plugin](http://gimmieworld.s3.amazonaws.com/sdk/gimmie_Android_SDK_1.5_Touchten.zip) and extract all files into `Assets/Plugins`
- Create a binding class, you can use a basic one here: [GimmieBinding.cs](GimmieBinding.cs).
- Modify AndroidManifest.xml to include all the Gimmie declarations. See [example here](android/AndroidManifest.xml).

Sample project structures

    Assets
        Plugins
            Android
                AndroidManifest.xml
                    Gimmie_Android_SDK
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

## Showing rewards catalog and trigger events

To show rewards catalog on any button add below code to Unity logic file.

    GimmieBinding.ShowGimmieRewardsCatalogue();

To trigger event

    GimmieBinding.TriggerGimmieEvent("event_name");

