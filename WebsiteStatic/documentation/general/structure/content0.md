# Menu Structure

This page documents the structure of the navigation menu in HyperNav. The 
code is interchangeable between both top and side navigation menus, however,
only the top navigation menu has been used in these examples for convenience.
To replicate the same behavior for side navigation menus, just exchange the
class `.hn-top` with `.hn-side`.

## Basic Structure

All HyperNav navigation menus should have a basic structure as presented
below. The content of the element with the class `.hn-section-brand` is visible
regardless of the device size, while the content of the element with the 
class `.hn-section-body` will be hidden behind a toggleable menu on mobile
devices.

<div class="example only-code" data-src="examples/basic.html"></div>

## Navigation Content Alignment

Sometimes you might want to align some navigation items to the start
and some to the end. This can be achieved by adding an element
with the class `.hn-spacer`. All `.hn-spacer` elements have an equal width
and height. More specifically, they have `flex: 1`.

<div class="example only-code" data-src="examples/alignment.html"></div>

## Menu with Overlay

Often an overlay for the navigation menu should be used, so that the content
below the it (the actual page content) gets darker. Additionally,
the navigation menu is closed by clicking on this region.

<div class="example only-code" data-src="examples/overlay.html"></div>

## Disable Focus Styles

HyperNav uses `:focus` styles to enable basic keyboard accessibility,
however, this also affects pointer usage. The coloring of clicked items 
will remain even if they are no longer hovered. To disable the `:focus` 
styles, you should add the class `.hn-menu-no-focus` to the `.hn-menu` 
element. This will destroy the keyboard accessibility, but by using
JavaScript that listens to certain keyboard elements, the class could
be toggled (not provided by HyperNav).  

<div class="example only-code" data-src="examples/no-focus.html"></div>