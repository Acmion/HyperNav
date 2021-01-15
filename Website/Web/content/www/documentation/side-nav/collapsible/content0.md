# Collapsible

The HyperNav side navigation menu supports a collapsed state on both mobile and
desktop devices. The collapsed state is infinitely nestable and depends on
icons for proper user experience. This kind of menu should only feature full 
expand items, because clicking the small plus sign in the collapsed state
is quite difficult. Alternatively, one could implement some JS (or page 
generation code) that improves usability. See 
[this demo](https://acmion.github.io/HyperNav/testing/nested-iconified-side-nav-menu-split-buttons.html)
for a way to improve the usability of split expand items with JavaScript.

## Default

In this example the state (whether the menu is collapsed or not) will
carry over between device sizes, which will be relevant if you expect 
that your users resize the website.

<div class="example side" data-src="examples/default.html"></div>

## Device Dependent State

Sometimes it might be preferrable to maintain a separate device dependent 
state. To achieve this we can leverage the classes `.hn-hide-desktop` and
`.hn-hide-mobile`. 

<div class="example side" data-src="examples/device-dependent.html"></div>

## Initial State

The initial state can be manipulated by specifying the `checked` attribute for
an input element.

<div class="example side" data-src="examples/device-dependent-initial-state.html"></div>