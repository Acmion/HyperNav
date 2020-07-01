function initializeThemeLoader()
{
    var themeButtons = document.querySelectorAll("#theme-button-container button");

    for (var i = 0; i < themeButtons.length; i++)
    {
        themeButtons[i].onclick = generateThemeButtonClickFunction(themeButtons[i]);
    }
}

function generateThemeButtonClickFunction(button)
{
    return function ()
    {
        loadTheme(button.dataset.theme);
    };
}

function loadTheme(theme)
{
    // Quite bad code
    // Document grows and grows and grows
    // Affects performance?

    var hyperNavThemeName = theme;
    var hyperNavThemeNameElement = document.getElementById("hyper-nav-theme-name-element");
    hyperNavThemeNameElement.innerHTML = "Theme: " + hyperNavThemeName;

    if (theme == "Default")
    {
        var stylesheetLinkElement = document.createElement("link");
        stylesheetLinkElement.rel = "stylesheet";
        stylesheetLinkElement.href = "../dist/hyper-nav-css-vars.min.css";

        document.head.appendChild(stylesheetLinkElement);
    }
    else if (theme == "Default Mono")
    {
        var stylesheetLinkElement = document.createElement("link");
        stylesheetLinkElement.rel = "stylesheet";
        stylesheetLinkElement.href = "../dist/themes/default-mono/variables.min.css";

        document.head.appendChild(stylesheetLinkElement);
    }  
    else if (theme == "Technical")
    {
        var stylesheetLinkElement = document.createElement("link");
        stylesheetLinkElement.rel = "stylesheet";
        stylesheetLinkElement.href = "../dist/themes/technical/variables.min.css";

        document.head.appendChild(stylesheetLinkElement);
    }
    
    cssVars();

}

