# Documentation

HyperNav is an interactive CSS only web navigation menu framework. The interactivity is 
mainly provided by utilizing `input` elements of type `checkbox` combined with the CSS 
sibling operator `~` and by applying `hover` styles. The main downside is that accessibility 
might not be entirely perfect. However, by employing progressive enhancement via JavaScript,
these problems could also be solved.

All of the CSS is prefixed with `hn-` Thus, 
interference with any other CSS frameworks is improbable. For instance,
this website utilizes both HyperNav and Bootstrap without any issues. 

HyperNav will probably have to be customized separately for each projects, as changing 
sizes and colors might be necessary to achieve a desired look. However, this is quite
straight forward due to the use of variables.
