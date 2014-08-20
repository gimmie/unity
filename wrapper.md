# Wrapper to call APIs directly

- [Add the wrapper files](Wrapper/) into `Assets/Plugins`
- Read the list of available [Gimmie APIs here](http://developer.gimmieworld.com/gimmie-api/).
- InitGimmie() with key and secret, and then CallGimmie()

### Sample API call
````c#
    using Gimmie;
    ...
    string profileEndpoint = "https://api.gimmieworld.com/1/profile.json";
    // Key and Secret are from Gimmit portal.
    GimmieWrapper.InitGimmie("key", "secret");
    GimmieWrapper.Login("awesomeUser");
    JSONObject j = GimmieWrapper.CallGimmie(profileEndpoint);
    Debug.Log("JSON fields accessed: "+ j["response"]["user"]["awarded_points"].n);
````
