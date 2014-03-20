#import "Gimmie.h"
#import "GMUnityIntegration.h"

void Login(const char *username)
{
    NSString *user = [NSString stringWithUTF8String:username];
    [[GMService sharedService] login:user];
}

void Logout()
{
    [[GMService sharedService] logout];
}

void UpdateGimmieCountry(const char *country)
{
    [GMService sharedService].country = [NSString stringWithUTF8String: country];
}

void ShowGimmieRewards()
{
    UIApplication *application = [UIApplication sharedApplication];
    UIViewController *rootController = application.keyWindow.rootViewController;
    [GMRewardsViewController presentGimmieOnController:rootController];
}

void BindGimmieNotification() {
    UIApplication *application = [UIApplication sharedApplication];
    UIViewController *rootController = application.keyWindow.rootViewController;
    [GMNotificationViewController showNotificationOnViewController:rootController];
    [[GMNotificationViewController sharedController] setShowNotificationOnTop:YES];
}

void TriggerEvent(const char *eventname)
{
    NSString *event = [NSString stringWithUTF8String:eventname];
    [[GMService sharedService] triggerEventName:event callback:nil];
}