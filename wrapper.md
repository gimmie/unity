# Wrapper to call APIs directly

- [Add the wrapper files](https://github.com/gimmie/unity/tree/master/Wrapper) into `Assets/Plugins`
- Read the list of available [Gimmie APIs here](http://developer.gimmieworld.com/gimmie-api/).
- InitGimmie() with key and secret, and then CallGimmie()

### Sample API call
    using Gimmie;
    string profileEndpoint = "https://api.gimmieworld.com/1/profile.json";
    GimmieWrapper.InitGimmie("keykeykeykeykeykeykey", "secretsecretsecretsecret");
    GimmieWrapper.Login("awesomeUser");
    JSONObject j = GimmieWrapper.CallGimmie(profileEndpoint);
    Debug.Log("from manager: "+ j["response"]["user"]["awarded_points"].n);
