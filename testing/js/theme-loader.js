function inIframe()
{
    try
    {
        return window.top != window.self;
    }
    catch (e)
    {
        return true;
    }
}

function loadTheme()
{
    var hyperNavThemeName = "Default";
    var hyperNavThemeNameElement = document.getElementById("hyper-nav-theme-name-element");

    if (inIframe())
    {
        var hash = document.location.hash;
        hyperNavThemeName = decodeURIComponent(hash.substr(1));

        if (hash == "#Technical")
        {
            var stylesheetLinkElement = document.createElement("link");
            stylesheetLinkElement.rel = "stylesheet";
            stylesheetLinkElement.href = "../dist/themes/technical/variables.min.css";

            document.head.appendChild(stylesheetLinkElement);
        }
        else if (hash == "#DefaultMono")
        {
            var stylesheetLinkElement = document.createElement("link");
            stylesheetLinkElement.rel = "stylesheet";
            stylesheetLinkElement.href = "../dist/themes/default-mono/variables.min.css";

            document.head.appendChild(stylesheetLinkElement);
        }  
    }

    hyperNavThemeNameElement.innerHTML = "Theme: " + hyperNavThemeName;
}

