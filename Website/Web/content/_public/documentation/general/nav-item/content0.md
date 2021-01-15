# Navigation Item

This page documents the navigation item in HyperNav. 
Usually these items are links, but other times they may be 
used more like buttons.

## Basic

The basic navigation item.

<div class="example" data-src="examples/basic.html"></div>

## Basic With Icon

The basic navigation item with an icon. For a more unified UI, the icon width is fixed with a variable.

<div class="example" data-src="examples/icon.html"></div>

## Basic With Auto Sized Icon 

The basic navigation item with an auto sized icon. To break the fixed with of an icon use the auto size utility 
class `.hn-size-auto`. [More about utilities](../utilities).

<div class="example" data-src="examples/icon-auto.html"></div>

## Bold Displacement Fix

The `font-weight` property affects layout dimensions, which can be problematic
if, for example, when an active navigation item should be displayed with bold text (not the default in HyperNav).
Read an article about the problem [here](https://www.sitepoint.com/quick-tip-fixing-font-weight-problem-hover-states/).
In practice, the problem affects only those layouts that are of horizontal nature, 
which means that the fix is often unnecessary for HyperNav side menus.
Regardless, to fix this in HyperNav you should give the element with class `.hn-content` the attribute 
`data-hn-content`, which should have the same value as the element itself.   

**Note:** This is a subtle change and you need to inspect the element with dev tools to see the change. 
For example, compare the widths of the left (150px) and right (144px) items in this example.


<div class="example" data-src="examples/bold-displacement-fix.html"></div>

## Active State

The currently active navigation item should also have the class `.hn-active`, which
will apply active styling.

<div class="example" data-src="examples/active.html"></div>
