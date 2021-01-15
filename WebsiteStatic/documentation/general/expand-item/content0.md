# Expand Item

This page documents the expand item in HyperNav. 
These items are expandable sub menus, which can take the form of
mega menus and dropdowns. These items should not be nested within 
`.hn-section-brand` as they will not work correctly on mobile devices. 
Additionally, this page documents several types of items, which should
not be mixed on a website for the best user experience.

## Full Button

A full button expand item. Clicking or hovering the button toggles the dropdown menu.

<div class="example" data-src="examples/full-button.html"></div>

## Split Button

A split button expand item. The item also works as a link, if not clicked on the plus sign. 
Clicking the plus sign or hovering the button toggles the dropdown menu.

<div class="example" data-src="examples/split-button.html"></div>

## Non-Hoverable Buttons

A full and a split button expand item that will not toggle the dropdown menu on hover. This is 
achieved by adding the class `.hn-no-hover` to the `.hn-expand` element.

<div class="example" data-src="examples/non-hoverable-button.html"></div>

## Non-Clickable Desktop Buttons

A full and a split button expand item that will only toggle on hover in the desktop view. 
Clicking the split button anywhere on desktop will trigger navigation.
The buttons work as above in the mobile view. The behavior is 
achieved by using the utility classes `.hn-hide-mobile` and `.hn-hide-desktop` as well
as some additional HTML content.

<div class="example" data-src="examples/non-clickable-desktop-button.html"></div>

## Mega Menu

A full and a split button mega menu expand item. Mega menus are created by 
adding the class `.hn-expand-mega` to the `.hn-expand` element. Custom content
can be wrapped within a `div` with class `.hn-link`, which results in the same
spacing as otherwise in HyperNav.

<div class="example" data-src="examples/mega-menu-button.html"></div>

## Dropdown Placement

You can change the placement of the dropdown menu with the following classes:

+ `.hn-expand-left`: The expand item expands to the left.
+ `.hn-expand-center`: The expand item expands so that it is aligned to the center.

These classes should be added to the `.hn-expand` element.

<div class="example" data-src="examples/dropdown-placement.html"></div>

## Nesting

To nest the menus in HyperNav, just add an expand item within the `.hn-expand-body` element.
The nesting depth is not limited, however, the maximum indentation level is by default 3. 
This is controlled by the SCSS only variable `$hn-nesting-max-depth`.

<div class="example" data-src="examples/nesting.html"></div>

## Active Child State

If an expand item has an active child (on any level of depth), then the class `.hn-active-child` 
should be added to the `.hn-item` directly below `.hn-expand`.

<div class="example" data-src="examples/active-child.html"></div>
