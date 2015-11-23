#Imgix-LinkBuilder

**Note: This project is still in its infancy**

[![Build status](https://ci.appveyor.com/api/projects/status/tg79ub2rwam2lpd9/branch/master?svg=true)](https://ci.appveyor.com/project/RasmusLauridsen/imgix-linkbuilder/branch/master)

A fluent imgix link builder library.<br/>
[Imgix](https://www.imgix.com/) is a hosted real time image processing service.

##Getting started

To get started install the package with the following command

```
PM> Install-Package Imgix-LinkBuilder
```

Once you have installed the package to your project, you can get started creating image links.

``` csharp
/* https://source.imgix.net/path/to_image/file.jpg?w=2000&h=200 */
var result = Imgix.NewImage("source", "path/to_image/file.jpg")
                .Width(2000)
                .Height(200);
```
 
##Changes
