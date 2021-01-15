# Variables

HyperNav utilizes CSS variables via an SCSS interface. That is the variables are declared as follows:  
CSS: `--hn-variable-name: 5rem;`  
SCSS: `$hn-variable-name: var(--hn-variable-name);`  

The majority of the variables in HyperNav follow this pattern, however, some variables are SCSS only due to
limitations in CSS. Regardless, all variables are always accessed via the SCSS interface in the source code.
See the list of all variables below. 

This means that should you wish to only use SCSS variables you can do so with relative ease. However,
the default behavior is provided by CSS variables. CSS variables provide many benefits, such as easy replication
of critical styling options in other elements, for example, one may wish to use the same background color
for a HyperNav element in a custom element, without hardcoding the color. Note that CSS variables are 
not supported on IE11, but [css-vars-ponyfill](https://github.com/jhildenbiddle/css-vars-ponyfill) exists for 
this.

## List of SCSS Only Variables

`$hn-mobile-breakpoint: 767px;`  
Device widths below or equal to this value are considered mobile devices.
Should not overlap with `$hn-desktop-breakpoint`.

`$hn-desktop-breakpoint: 768px;`  
Device widths above or equal to this value are considered desktop devices.
Should not overlap with `$hn-mobile-breakpoint`.

`$hn-mode-count: 4;`  
The maximum number of top navigation modes.

`$hn-nesting-max-depth: 3;`  
The maximum depth at which navigation items still get indented.

`$hn-base-z-index: 1000;`  
`$hn-mode-z-index: $hn-base-z-index + 1000000;`  
`$hn-top-z-index: $hn-base-z-index + 100000;`  
`$hn-side-z-index: $hn-base-z-index  + 10000;`  
`$hn-nav-z-index: $hn-base-z-index + 1000;`  
`$hn-overlay-z-index: $hn-base-z-index + 100;`  
`$hn-side-container-z-index: $hn-mode-z-index + 3;`  
`$hn-side-container-nav-z-index: $hn-mode-z-index + 2;`  
`$hn-side-container-overlay-z-index: $hn-mode-z-index + 1;`  
`$hn-side-container-top-offset-z-index: $hn-base-z-index + 4;`  
`$hn-side-container-top-offset-menu-z-index: $hn-base-z-index + 3;`  
`$hn-side-container-top-offset-nav-z-index: $hn-base-z-index + 2;`  
`$hn-side-container-top-offset-overlay-z-index: $hn-base-z-index + 1;`  
Bunch of z-indexes that control what is on top of what. Could
not be implemented as CSS variables because IE11 does not support
`calc` for this property.


## List of Other Variables
`--hn-bg: rgba(238, 239, 240, 1.00);`  
The background of a HyperNav menu.

`--hn-color: rgba(25, 25, 25, 1.00);`  
The color of a HyperNav menu.

`--hn-expand-body-bg: rgba(0, 0, 0, 0.1);`  
The background of a dropdown menu.

---

`--hn-item-bg: transparent;`  
The background of a navigation item.

`--hn-item-color: var(--hn-color);`  
The color of a navigation item.

`--hn-item-hover-bg: rgba(86, 86, 86, 1.00);`  
The background of a hovered navigation item.

`--hn-item-hover-color: rgba(238, 239, 240, 1.00);`  
The color of a hovered navigation item.

---

`--hn-item-active-bg: rgba(0, 0, 0, 0.40);`  
The background of an active navigation item.

`--hn-item-active-color: rgba(255, 255, 255, 1.00);`  
The color of an active navigation item.

`--hn-item-active-hover-bg: var(--hn-item-hover-bg);`  
The background of a hovered active navigation item.

`--hn-item-active-hover-color: var(--hn-item-hover-color);`  
The color of a hovered active navigation item.

---

`--hn-item-active-child-bg: rgba(0, 0, 0, 0.30);`  
The background of a navigation item with an active child navigation item.

`--hn-item-active-child-color: var(--hn-color);`  
The color of a navigation item with an active child navigation item.

`--hn-item-active-child-hover-bg: var(--hn-item-hover-bg);`  
The background of a hovered navigation item with an active child navigation item.

`--hn-item-active-child-hover-color: var(--hn-item-hover-color);`  
The color of a hovered navigation item with an active child navigation item.

---

`--hn-expand-expanded-item-bg: var(--hn-item-bg);`  
The background of an expanded expand item.

`--hn-expand-expanded-item-color: var(--hn-item-color);`  
The color of an expanded expand item.

`--hn-expand-expanded-item-hover-bg: var(--hn-item-hover-bg);`  
The background of a hovered expanded expand item.

`--hn-expand-expanded-item-hover-color: var(--hn-item-hover-color);`  
The background of a hovered expanded expand item.

---

`--hn-expand-expanded-item-active-bg: var(--hn-item-active-bg);`  
The background of an active expanded expand item.

`--hn-expand-expanded-item-active-color: var(--hn-item-active-color);`  
The color of an active expanded expand item.

`--hn-expand-expanded-item-active-hover-bg: var(--hn-item-active-hover-bg);`  
The background of a hovered active expanded expand item.

`--hn-expand-expanded-item-active-hover-color: var(--hn-item-active-hover-color);`  
The color of a hovered active expanded expand item.

---

`--hn-expand-expanded-item-active-child-bg: var(--hn-item-active-child-bg);`  
The background of an expanded expand item with an active child.

`--hn-expand-expanded-item-active-child-color: var(--hn-item-active-child-color);`  
The color of an expanded expand item with an active child.

`--hn-expand-expanded-item-active-child-hover-bg: var(--hn-item-active-child-hover-bg);`  
The background of a hovered expanded expand item with an active child.

`--hn-expand-expanded-item-active-child-hover-color: var(--hn-item-active-child-hover-color);`  
The color of a hovered expanded expand item with an active child.

---

`--hn-overlay-bg: rgba(0, 0, 0, 0.6);`  
The background of an overlay.

---

`--hn-input-bg: transparent;`  
The background of an input item.

`--hn-input-color: inherit;`  
The color of an input item.

`--hn-input-hover-bg: rgba(0, 0, 0, 0.2);`  
The background of a hovered input item.

`--hn-input-hover-color: inherit;`  
The color of a hovered input item.

`--hn-input-active-bg: var(--hn-input-bg);`  
The background of an input item that is in its active state.

`--hn-input-active-color: var(--hn-input-color);`  
The color of an input item that is in its active state.

`--hn-input-active-hover-bg: var(--hn-input-hover-bg);`  
The background of a hovered input item that is in its active state.

`--hn-input-active-hover-color: var(--hn-input-hover-color);`  
The color of a hovered input item that is in its active state.

---

`--hn-side-width: 20rem;`  
The width of the side menu.

`--hn-side-icon-width: 2.4rem;`
The width of an icon in the side menu.

`--hn-side-font-size: 1.4rem;`  
The font size of the side menu.

`--hn-side-shadow: 0 0 2rem 0 #000;`
The shadow of the side menu.

---

`--hn-side-item-min-height: 4rem;`  
The minimum height of a side menu item.

`--hn-side-link-padding-top: 1rem;`  
The top padding of a side menu link.

`--hn-side-link-padding-right: 1rem;`  
The right padding of a side menu link.

`--hn-side-link-padding-bottom: 1rem;`  
The bottom padding of a side menu link.

`--hn-side-link-padding-left: 1rem;`  
The left padding of a side menu link.

---

`--hn-side-expand-link-padding-top: var(--hn-side-link-padding-top);`  
The top padding of a side menu expand item link.

`--hn-side-expand-link-padding-right: var(--hn-side-link-padding-right);`  
The right padding of a side menu expand item link.

`--hn-side-expand-link-padding-bottom: var(--hn-side-link-padding-bottom);`  
The bottom padding of a side menu expand item link.

`--hn-side-expand-link-padding-left: var(--hn-side-link-padding-bottom);`  
The left padding of a side menu expand item link.

---

`--hn-side-input-width: 4rem;`  
The width of a side menu input item.

---

`--hn-side-collapsed-input-size: 1.2rem;`  
The size of a side menu collapsed input item.

`--hn-side-collapsed-input-font-size: 1.2rem;`  
The font size of a side menu collapsed input item.

`--hn-side-collapsed-input-margin: 0rem;`  
The margin of a side menu collapsed input item.

`--hn-side-collapsed-input-padding: 0rem;`  
The padding of a side menu collapsed input item.

`--hn-side-collapsed-input-bg: transparent;`  
The background of a side menu collapsed input item.

`--hn-side-collapsed-input-color: inherit;`  
The color of a side menu collapsed input item.

`--hn-side-collapsed-input-hover-bg: transparent;`  
The background of a hovered side menu collapsed input item.

`--hn-side-collapsed-input-hover-color: var(--hn-item-hover-color);`  
The color of a hovered side menu collapsed input item.

---

`--hn-side-nesting-indentation: 1rem;`  
The amount of nesting applied per navigation level depth in a side menu.

---

`--hn-top-height: 5rem;`  
The height of a top navigation menu.

`--hn-top-icon-width: 2.4rem;`  
The width of an icon in a top navigation menu.

`--hn-top-font-size: 1.6rem;`  
The font size of a top navigation menu.

`--hn-top-shadow: 0px 0rem 1rem 0px #000;`  
The shadow of a top navigation menu.

`--hn-top-item-min-height: 4rem;`  
The minimum height of a top navigation menu item.

---

`--hn-top-link-padding-top: 1rem;`  
The top padding of a top menu link.

`--hn-top-link-padding-right: 1rem;`  
The right padding of a top menu link.

`--hn-top-link-padding-bottom: 1rem;`  
The bottom padding of a top menu link.

`--hn-top-link-padding-left: 1rem;`  
The left padding of a top menu link.

---

`--hn-top-expand-link-padding-top: var(--hn-top-link-padding-top);`  
The top padding of a top menu expand item link.

`--hn-top-expand-link-padding-right: 0.4rem;`  
The right padding of a top menu expand item link.

`--hn-top-expand-link-padding-bottom: var(--hn-top-link-padding-bottom);`  
The bottom padding of a top menu expand item link.

`--hn-top-expand-link-padding-left: var(--hn-top-link-padding-bottom);`  
The left padding of a top menu expand item link.

---

`--hn-top-input-width: 3rem;`  
The width of an input item in a top menu.

`--hn-top-nesting-indentation: 1rem;`  
The amount of nesting applied per navigation level depth in a top menu.

---

`--hn-top-desktop-expand-body-bg: var(--hn-bg);`  
The background of a dropdown menu in a top menu on desktop.

`--hn-top-desktop-expand-body-border: transparent;`  
The border of a dropdown menu in a top menu on desktop.

`--hn-top-desktop-expand-body-shadow: 0 0.2rem 0.2rem rgba(0, 0, 0, 0.4), -0.2rem 0.2rem 0.4rem rgba(0, 0, 0, 0.4), 0.2rem 0.2rem 0.4rem rgba(0, 0, 0, 0.4);`  
The shadow of a dropdown menu in a top menu on desktop.
