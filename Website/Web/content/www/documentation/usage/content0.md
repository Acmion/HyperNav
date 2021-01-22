# Usage

Clone (or download) the [HyperNav GitHub repository](https://github.com/Acmion/HyperNav) and link to 
the file `hyper-nav.min.css` from a HTML document. You must also link to a file that contains the
declarations for the CSS variables (this is most often a custom file). The default CSS variable 
declarations can be found in the file `themes/default/variables.min.css`. Each project should probably
be override these variables.

```
<link rel="stylesheet" href="path/to/HyperNav/dist/hyper-nav.min.css"/>
<link rel="stylesheet" href="path/to/HyperNav/dist/themes/default/variables.min.css"/>
```

## Alternative Usage

HyperNav default theme can also be enabled by loading in a single CSS file, `hyper-nav-default.min.css`. This file
is just a combination of the files mentioned above. 

```
<link rel="stylesheet" href="path/to/HyperNav/dist/hyper-nav-default.min.css"/>
```

## CSS Variable Ponyfill

CSS variables are not supported on IE11, but [css-vars-ponyfill](https://github.com/jhildenbiddle/css-vars-ponyfill) 
exists for this. For IE11 compatibility you should either use this library or you should convert all CSS variables
to SCSS variables.

## Expand Menu Content Flashing Fix

In certain cases the content of an expand menu may flash on initial navigation to a site that uses HyperNav.
This behavior may be related to a browser bug or something else and probably occurs when the site loads too 
fast. See for example this demo: [/+/testing/no-js.html](/+/testing/no-js.html), where the contents of the
"Shipping" menu briefly flash if the site is loaded without utilizing the cache. Luckily, the fix is simple, 
either add a `script` tag with an arbitrary JavaScript instruction or add a `style` tag that explicitly 
disables this behavior (this can not reliably be bundled into HyperNav itself).

The JavaScript alternative:
```
<head>
    <!-- Some stuff here. -->

    <!-- Fix below. -->
    <script>
        var a = 0;
    </script>
</head>
```

The CSS alternative:
```
<head>
    <!-- Some stuff here. -->

    <!-- Fix below. -->
    <style>
        .hn-expand-body
        {
            visibility: hidden;
        }
    </style>
</head>
```