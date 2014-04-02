extern "C" {
    void AnonymousLogin();
    void Login(const char *username);
    void Logout();
    void UpdateGimmieCountry(const char *country);
    void ShowGimmieRewards();
    void BindGimmieNotification();
    void TriggerEvent(const char *eventname);
}
