#import "Gimmie.h"
#import "GMUnityIntegration.h"

void AnonymousLogin()
{
    [Gimmie loginWithGenerateID];
}

void Login(const char *username)
{
    NSString *user = [NSString stringWithUTF8String:username];
    [Gimmie login:user];
}

void Logout()
{
    [[GMService sharedService] logout];
}

bool NativeIOSIsAnonymous()
{
    NSString *user = [GMService sharedService].user;
    return [user hasPrefix:@"guest:"];
}

void UpdateGimmieCountry(const char *country)
{
    [GMService sharedService].country = [NSString stringWithUTF8String: country];
}

void ShowGimmieRewards()
{
    [Gimmie showGimmieView];
}

void BindGimmieNotification() {
    [Gimmie start];
}

void TriggerEvent(const char *eventname)
{
    NSString *event = [NSString stringWithUTF8String:eventname];
    [Gimmie trigger:event];
}

