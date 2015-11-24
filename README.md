#Imgix-LinkBuilder

**Note: This project is still in its infancy**

[![Build status](https://ci.appveyor.com/api/projects/status/tg79ub2rwam2lpd9/branch/master?svg=true)](https://ci.appveyor.com/project/RasmusLauridsen/imgix-linkbuilder/branch/master)

A fluent imgix link builder library.<br/>
[Imgix](https://www.imgix.com/) is a hosted real time image processing service.

##Getting started

To get started install the package with the following command

```
PM> Install-Package Imgix-LinkBuilder -Pre
```

Once you have installed the package to your project, you can get started creating image links.

``` csharp
/* https://assets.imgix.net/blog/woman-hat.jpg?w=200&h=200&mask=ellipse&fit=crop&crop=faces&fm=png */
var result = Imgix.NewImage("assets", "blog/woman-hat.jpg")
                  .Width(200)
                  .Height(200)
                  .EllipseMask()
                  .Fit("crop")
                  .Crop("faces")
                  .AddParameter("fm", "png") //If there is no extension method for a transform just add a parameter.
```
[![Example](https://assets.imgix.net/blog/woman-hat.jpg?w=200&h=200&mask=ellipse&fit=crop&crop=faces&fm=png)](https://assets.imgix.net/blog/woman-hat.jpg?w=200&h=200&mask=ellipse&fit=crop&crop=faces&fm=png)

*Example image from the [imgix sandbox](https://sandbox.imgix.com/create)*

##Changes
