# Contributing

All contributions to HyperNav, big or small, are greatly appreciated. This page
lists examples of things that you could create or improve on. Changes should be
submitted as pull requests on GitHub and so that the assets in the `dist` folder
have been recompiled. All changes should be implemented and visually tested against 
the [HyperNav Complete Demo](https://acmion.github.io/HyperNav/testing/complete.html). 
The changes should also work on IE11.

## GitHub Issues
Document problems in the [GitHub repository](https://github.com/Acmion/HyperNav).

## Test HyperNav on Various Browsers
HyperNav has been tested on a limited amount of browsers. Test the 
[HyperNav Complete Demo](https://acmion.github.io/HyperNav/testing/complete.html) 
on some browser and compare the behavior to that of Google Chrome. Report the 
findings as GitHub issues.

## New Themes
Create new themes for HyperNav.

## New Demos
Create new demos for HyperNav. The current demos are technical in nature and 
try to showcase as much as possible at once. This means that their user experience
is not too good. The demos should be viewable as files in the browser, without 
spinning up a localhost server.

## Improve the Build Process
Currently HyperNav is compiled and minified with the standard SASS tooling. This 
results in somewhat larger CSS files than needed, for example, the same media 
queries appear several times in the minified files. The tooling should still
be kept at a minimum. The tooling should also be crossplatform without any
hassle (not like Bootstrap Ruby dependencies, which are painful to install on 
Windows machines).

## Create NPM (and Other) Packages
Currently HyperNav must be downloaded or cloned from GitHub. NPM and other 
packages could improve the ease of use.

## Accessibility Guidelines
Accessibility guidelines could be written for various devices. 

## Improve the Documentation
The documentation of HyperNav could always be improved with more and better 
examples. The documentation is hosted in 
[another GitHub repository](https://github.com/Acmion/HyperNav-Documentation).

## Improve the Demos
Currently parts of the HTML of the demos is just copied from one file to another, which 
makes maintenance painful. Perhaps some `iframe` action could help here?

## Create Enhancing JavaScript
HyperNav works without JavaScript, however, some enhancing JavaScript could
be created as optional packages. See [this demo](https://acmion.github.io/HyperNav/testing/nested-iconified-side-nav-menu-split-buttons.html),
which contains JavaScript that is not bundled with HyperNav for better user experience. For example,
the keyboard accessibility is currently basic and could be significantly improved by allowing `labels` 
to be focused and the checkboxes controlled via JavaScript.

## Create new Animations
Some generic animations could be implemented for HyperNav. See the hover delay animation, 
which is implemented in `scss/navigation-menus/top/animations/_expand-body-delay-animation.scss`.

## Implement Different Coloring for Hover and Focus States
Currently the colors for both the `:hover` and `:focus` states are the
same. Some use cases may require different colors depending on state, which
is why this could be implemented. Adding a bunch of variable declarations and
implementing them in SCSS should be enough (the current SCSS should already
be logically correct, but the `:hover` and `:focus` styles should be duplicated
and separated). The state `:focus:hover` should be the most important state.

## Implement New Navigation Menu Types
Some navigation menu types that could be implemented are:

**Horizontally Expanding Side Navigation Menu**

![Horizontally Expanding Side Navigation Menu Visualization](/static/img/horizontally-expanding-side-navigation-menu.png "Horizontally Expanding Side Navigation Menu Visualization")

The left image depicts the default state, while the right image depicts the state after expanding an item. 
Adding a class to `.hn-side` should be enough for this to work. 

**Hover Flyout Side Navigation Menu**

![Hover Flyout Side Navigation Menu Visualization](/static/img/hover-flyout-side-navigation-menu.png "Hover Flyout Side Navigation Menu Visualization")

The left image depicts the default state, while in the right image the item "Top Navigation" has been expanded 
and the "General" item is currently hovered. The hover has triggered a flyout menu. Hovering an already expanded 
item will not create a flyout. Adding a class to `.hn-side` should be enough for this to work. 

## Simplify the SCSS
There might be some redundancies in the SCSS (for example, `:focus` selectors
that can never be applied). These should be deleted.

