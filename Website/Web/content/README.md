# HyperNav Documentation
This repository contains the source of the [HyperNav](https://github.com/Acmion/HyperNav) documentation, which is hosted
at [hyper-nav.acmion.com](hyper-nav.acmion.com).

The main HyperNav repository can be found here: [https://github.com/Acmion/HyperNav](https://github.com/Acmion/HyperNav).

## Build Process
The website is built with [CommunicatorCms](https://github.com/Acmion/CommunicatorCms), which is another Acmion
project. Unfortunately, CommunicatorCms is not yet entirely production ready, but works well for generating
static websites. To build the website do the following:
1. Install ASP.NET Core 3.1.
2. Clone [CommunicatorCms](https://github.com/Acmion/CommunicatorCms).
3. Clone this repository in to `CommunicatorCms/Web/content`.
4. Install wget.
5. Run `publish.sh` to generate a static copy.
