#Imgix-Dotnet

**Note: This project is still in its infancy**

[![Build status](https://ci.appveyor.com/api/projects/status/3otyegok2cu9h983/branch/master?svg=true)](https://ci.appveyor.com/project/RasmusLauridsen/imgix-dotnet/branch/master)

A fluent imgix link builder library.<br/>
[Imgix](https://www.imgix.com/) is a hosted real time image processing service.

##Getting started

To get started install the package with the following command

```
PM> Install-Package Imgix-Dotnet -Pre
```

Once you have installed the package to your project, you can get started creating image links.

``` csharp
/* https://assets.imgix.net/blog/woman-hat.jpg?w=200&h=200&mask=ellipse&fit=crop&crop=faces&fm=png */
var result = Imgix.CreateImage("blog/woman-hat.jpg", "assets")
                  .Width(200)
                  .Height(200)
                  .EllipseMask()
                  .Fit("crop")
                  .Crop("faces")
                  .AddParameter("fm", "png") //If there is no extension method for a transform just add a parameter.
```
[![Example](https://assets.imgix.net/blog/woman-hat.jpg?w=200&h=200&mask=ellipse&fit=crop&crop=faces&fm=png)](https://assets.imgix.net/blog/woman-hat.jpg?w=200&h=200&mask=ellipse&fit=crop&crop=faces&fm=png)

*Example image from the [imgix sandbox](https://sandbox.imgix.com/create)*

The ImgixImage class is immutable so it is always a new image that is returned. 
This means that you can use the same image to create multiple resulting images, without worrying about shared state.

Multiple different formats are quickly created in a very dry way.

``` csharp

//Setting up the base shape and format of the image
var baseImage = Imgix.CreateImage("blog/woman-hat.jpg", "assets")
    .Fit("crop")
    .Crop("faces")
    .AddParameter("faceindex", "1");
//Creating multiple sizes
var image400x200 = baseImage.Width(400).Height(200);
var image200x400 = baseImage.Width(200).Height(400);

```
[![Example](https://assets.imgix.net/blog/woman-hat.jpg?fit=crop&crop=faces&faceindex=1&w=400&h=200)](https://assets.imgix.net/blog/woman-hat.jpg?fit=crop&crop=faces&faceindex=1&w=400&h=200) 400x200px 
[![Example](https://assets.imgix.net/blog/woman-hat.jpg?fit=crop&crop=faces&faceindex=1&w=200&h=400)](https://assets.imgix.net/blog/woman-hat.jpg?fit=crop&crop=faces&faceindex=1&w=200&h=400) 200x400px

*Example image from the [imgix sandbox](https://sandbox.imgix.com/create)*

##Changes
