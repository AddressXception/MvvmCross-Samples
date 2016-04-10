# Cross-Platform UI Testing with Specflow, Xamarin, and CodedUI 
___
### (Based on MvvmCross-Samples)

This fork and branch is an example demonstrating how to configure [Cross-Platform UI Testing with Specflow, Xamarin,and CodedUI](http://blog.infernored.com/cross-platform-ui-testing-with-specflow-xamarin-and-codedui).  It was created for a blog series on the [InfernoRed Technology Blog](http://blog.infernored.com/).  In this example we combine the aforementioned technologies to leverage the Gherkin language in UI tests on Android, iOS, and Windows (8.1 and UWP).

### So how'd you do it?

The crux of this strategy relies on leveraging Xamarin's excellent work in their Xamarin.UITest library that already takes care of abstracting the platform for us.  In Xamarin.UITest, there is an [IApp interface](https://developer.xamarin.com/api/type/Xamarin.UITest.IApp/) that provides a common language for working with platforms in a fluent way.  Since Xamarin.UITest doesn't work with windows (yet?), we need to implement this interface on Windows and call the respective CodedUI methods.  From there it is a matter of building out common boilerplate to glue SpecFlow Features and Steps to both platforms.  [It's all here in this pamphlet.](http://blog.infernored.com/cross-platform-ui-testing-with-specflow-xamarin-and-codedui)

### Why fork MvvMCross-Samples?

1. I wanted a fairly basic sample that already compiles and runs on my platforms of choice
2. MvvMCross is awesome and I use it frequently for demanding and high performance applications

### What if I have questions?

- Twitter ([@AddressXception](https://twitter.com/AddressXception/))
- Email (InfernoRed.BlogATAddressXception.com)

___

### About MvvMCross

[MvvmCross](https://github.com/MvvmCross/MvvmCross) is a cross-platform mvvm framework that enables developers to create cross platform apps. Additional support is available for [Xamarin.Forms](https://github.com/MvvmCross/MvvmCross-Forms) and the [Android support library](https://github.com/MvvmCross/MvvmCross-AndroidSupport). Lots of [plugins](https://github.com/MvvmCross/MvvmCross-Plugins) are available as well.

See the official [MvvmCross blog](http://mvvmcross.com/) for the latest news!

### Questions & support

* [StackOverflow](http://stackoverflow.com/questions/tagged/mvvmcross)
* [Xamarin forums](http://forums.xamarin.com)
* [Slack](https://xamarinchat.herokuapp.com/) join the mvvmcross channel after you are in

### Documentation

**See the [MvvmCross Wiki](https://github.com/MvvmCross/MvvmCross/wiki) for additional articles and information.**

**When creating a new sample, please do the following:**

 - Use NuGets for all external references
 - Provide a Readme.md file describing the sample
 - Provide a screenshots of the sample

### Acknowledgements
___

Licensing
---------

This project is developed and distributed under the [Microsoft Public License (MS-PL)](http://opensource.org/licenses/ms-pl.html).
