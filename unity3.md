# Gimmie with UI components for Unity 3.x
Integrating Gimmie with its UI components into Unity project targeting iOS/Android
## Android

- Download [Gimmie SDK for Unity](http://gimmieworld.s3.amazonaws.com/sdk/Gimmie-AndroidSDK-1.8.1-Unity.zip)
- Extract and copy 'res/' and all files in 'libs'
- Create a binding class, you can use a basic one here: [GimmieBinding.cs](GimmieBinding.cs).
- Modify AndroidManifest.xml to include all the Gimmie declarations. See [example here](android/AndroidManifest.xml).

Sample project structures

    Assets/
        Plugins/
            Android/
            	res/
                AndroidManifest.xml
                GimmieBinding.cs
                gimmie.jar
                actionbar sherlock.jar
                android-support-v4.jar
                MixpanelAPI.jar
                pager indicator.jar
                scribe-1.3.5.jar
                tagsoup-1.2.1.jar
            Your-other-plugins/

## iOS

Same steps as [Unity 4.x](./unity4.md)
