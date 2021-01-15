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