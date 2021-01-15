# Modes

The top navigation menu supports modes. For example, a common use case is to have a separate 
search mode, which overrides the look of the top navigation bar. This page documents the usage of modes
in HyperNav. Usage of modes result in relatively complex HTML, especially as `input` of type `radio`
must be used.  

**Note:** the usage of modes is not completely keyboard accessible without JS.

## Mode Structure

The state control for modes is a bit different than for the standard HyperNav hamburger menu.
This follows from the fact that only one mode should be active at a time, which is why input
elements of type `radio` are used instead of `checkbox`. This has some extra implications,
which must be taken care of. 

<div class="example only-code" data-src="examples/mode-state-control.html"></div>

## One Mode Example

A HyperNav top navigation menu with one extra mode.

<div class="example" data-src="examples/one-mode.html"></div>

## Two Modes Example

A HyperNav top navigation menu with two extra modes.

<div class="example" data-src="examples/two-mode.html"></div>
