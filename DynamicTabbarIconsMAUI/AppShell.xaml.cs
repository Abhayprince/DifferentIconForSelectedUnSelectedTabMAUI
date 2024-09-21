namespace DynamicTabbarIconsMAUI;

public partial class AppShell : Shell
{
    private static Dictionary<string, (ImageSource SelectedIcon, ImageSource UnselectedIcon)> _tabbarIconsMap =
        new()
        {
            [nameof(MainPage)] = ("home_selected.png", "home.png"),
            [nameof(ProfilePage)] = ("user_selected.png", "user.png")
    };

    public AppShell()
    {
        InitializeComponent();
    }
    
    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        // FROM the current tab to new tab
        // We will set Un-selected Icon here

        base.OnNavigating(args);
        if(bottomTabbar != null)
        {
            var tabbItem = bottomTabbar.CurrentItem.CurrentItem;
            var route = tabbItem.Route;
            if (_tabbarIconsMap.TryGetValue(route, out var icons))
            {
                tabbItem.Icon = icons.UnselectedIcon;
            }
        }
    }
    
    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        // TO this Tab from previous tab
        // We will set Selected Icon here
        base.OnNavigated(args);
        if (bottomTabbar != null)
        {
            var tabbItem = bottomTabbar.CurrentItem.CurrentItem;
            var route = tabbItem.Route;
            if (_tabbarIconsMap.TryGetValue(route, out var icons))
            {
                tabbItem.Icon = icons.SelectedIcon;
            }
        }
    }


}

