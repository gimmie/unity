extern "C" {
    void AnonymousLogin();
    void Login(const char *username);
    void Logout();
    bool NativeIOSIsAnonymous();
    void UpdateGimmieCountry(const char *country);
    void ShowGimmieRewards();
    void BindGimmieNotification();
    void TriggerEvent(const char *eventname);
}
