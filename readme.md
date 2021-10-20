# Introduction

The **Learn PrismLibrary** repository provides a variety of samples across different framework implementaitons such as, Xamarin.Forms, Uno, WPF, and Avalonia, all using Prism!

Each of the samples uses DryIoc for Dependency Injection and is based off of their respective Visual Studio template.

Enjoy!<br />
Author: [Damian Suess](https://www.linkedin.com/in/damiansuess/)<br />
Website: [suesslabs.com](https://suesslabs.com)

## About Prism Library

Prism is a framework for building loosely coupled, maintainable, and testable XAML applications in WPF, Windows 10 UWP, and Xamarin Forms. Separate releases are available for each platform and those will be developed on independent timelines. Prism provides an implementation of a collection of design patterns that are helpful in writing well-structured and maintainable XAML applications, including MVVM, dependency injection, commands, EventAggregator, and others. Prism's core functionality is a shared code base in a Portable Class Library targeting these platforms.

## Samples Table

### [Prism.Forms](https://github.com/PrismLibrary/Prism)

| Name                        | Prism Ver. | Details |
|-|-|-|-|
| Ex 1 - Intro to Navigation  | 7.0 | Introduction to View/ViewModel registration and navigation.
| Ex 2 - Master Detail Page   | 7.1 | Navigation using the MasterDetailPage. Xamarin.Forms has since renamed the control to, "FlyoutPage". We're keeping the name for historical purposes.
| Ex 3 -Tab Page              | 7.1 | Navigation using the TabbedPage user control.
| Ex 4 - (Coming Soon)        | 8.1 | Sample pop-up and dialogs
| Ex 5 - Partial Content View | 7.1 | Prism's `AutowirePartialView` is a legacy feature that has since been replaced with `Region` support in v8.x. Reference, [this post](https://stackoverflow.com/a/61503648/249492) by Dan Siegel.
| Ex 6 - v7.2 Features        | 7.2 | Prism v7.2 features (_legacy_)
| Ex 7 - v7.2 Template        | 7.2 | Prism.Forms v7.2 Template Project (_legacy_)
| Ex 8 - v8.1 Template        | 8.1 | Prism.Forms v8.1 Template Project

### [Prism.Uno](https://github.com/PrismLibrary/Prism)

| Name                        | Prism Ver. | Details |
|-|-|-|-|
| Ex 1 - Basics               | 8.1 | Prism.Uno sample targets Linux with GTK, and Windows via UWP.

### [Prism.WPF](https://github.com/PrismLibrary/Prism)

| Name                        | Prism Ver. | Details |
|-|-|-|-|
| Ex 1 - Full App Template    | 8.0 | Prism.WPF sample app with Regions, Modules, and navigation (_.NET Framework 4.8_)
| Ex 2 - Region Navigation    | 8.0 | Navigation using Regions (_.NET Framework 4.8_)
| Ex 3 - Module Permissions   | 8.1 | Module permissions sample using .NET 5 - Based on [Brian Lagunas' Pluralsight course](https://app.pluralsight.com/library/courses/prism-loading-modules-user-roles)

### [Prism.Avalonia](https://github.com/AvaloniaCommunity/Prism.Avalonia)

| Name                        | Prism Ver. | Details |
|-|-|-|-|
| Ex 1 - Intro to Navigation  | 7.2 | Basic navigation using 3-panel client with a sidebar navigation.
| Ex 2 - Intro to Modules     | 7.2 | _Coming Soon!_

## AvaloniaUI Samples

All AvaloniaUI samples are cross-platform ready!  That's right, you can use Linux, Mac, Windows, or Windows with WSL.

In these lessons repo, we'll explore how to wire-up Avalonia with Prism.Avalonia and some of the key user controls that Avalonia has to offer.

Whether you're coming from WPF, Xamarin.Forms, Uno, or some other XAML based language, you'll find a lot of exact syntactical matches, simulatities and a few that require some finessing. Overall, Avalonia is a solid tool for production applications despite its `0.x` version numbering.

## WPF Samples

List of Prism Snippets:

* [X]  Prism Library Sample Full App
* [X]  Basic Regions with Navigation and Service wire-ups
* [/]  Basic Modules (_work in progress_)
* [ ]  Dynamic Tab Regions

### WPF - Ex1 - Full App Template

* Main Program
* Module 1 - Login Screen Module
* Module 2 - Basic Inventory Management Module, with personalized services.
* Module 3 - Logging Module, shared by both Modules
* Services - Shared services

### WPF - Ex2 - Basic Regions

Demonstrates how to configure regions, perform navigation, and wire up services with Dependendency Injection. There are 2 regions, a sidebar and a content region where the main body of work is performed.

### WPF - Ex3 - Basic Modules

Demonstrates how to interact with multiple modules from your main form and share common services, plus personalized services to the module.

Here we'll use basic login system to gain access to our inventory manager

## Semi-Requirements

The project works best if you include the [Prism Template Pack](https://marketplace.visualstudio.com/items?itemName=BrianLagunas.PrismTemplatePack). This allows the system to quickly type in code for you and _even creates a ViewModel class when you create a new page_!

## Resources

* [Prism Library](https://prismlibrary.github.io/)
* [Prism on GitHub](https://github.com/PrismLibrary/Prism)
* [Prism Template Pack](https://marketplace.visualstudio.com/items?itemName=BrianLagunas.PrismTemplatePack)
* [Prism official samples](https://github.com/PrismLibrary/Prism-Samples-Forms)
* [Plugin Popups](https://github.com/dansiegel/Prism.Plugin.Popups)

### Learn

* [Prism for Xamarin.Forms - Create your first application](https://www.youtube.com/watch?v=81Q2fxFWIqA) - Created 2018-12-04
* [The Xamarin Show | Episode 10: Prism for Xamarin.Forms with Brian Lagunas](https://www.youtube.com/watch?v=mb3_vhYw1mA) - Created 2018-01-04 _Prism v6_
* [Xamarin Forms with Prism — Getting Started — Part 1](https://medium.com/tutorialsxl/xamarin-forms-with-prism-getting-started-part-1-14832d7cf5fa) - Created 2018-03-23
