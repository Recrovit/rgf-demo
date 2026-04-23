RecroGrid Framework Demo Solution
=================================

This repository contains the demo solution for the RecroGrid Framework (RGF). It showcases multiple ways to build RGF-based applications, including API-driven backends, Blazor clients, MVC applications, and authentication flows backed by a dedicated identity provider.

The solution also includes shared Northwind-based demo models and infrastructure that are reused across the sample applications. The focus of this repository is to provide a compact overview of how the different RGF building blocks fit together in real applications.

The RecroGrid Framework components used by these demos are maintained in the [`rgf-client`](https://github.com/Recrovit/rgf-client) repository.

## Project Overview

- `RGF.Demo.API`: ASP.NET Core Web API host that demonstrates the demo backend and RGF server-side integration.
- `RGF.Demo.IDP`: Dedicated demo identity provider used for authentication and OpenID Connect scenarios across the solution.
- `RGF.Demo.Northwind`: Shared Northwind-based demo domain and data access layer used by the server-side sample applications.
- `RGF.Demo.Northwind.Common`: Common abstractions and shared models consumed by multiple demo clients and hosts.
- `RGF.DemoApp`: Modern demo host application that showcases OpenID Connect, Blazor, and RGF integration in the current application model.
- `RGF.DemoApp.Client`: Client-side Blazor WebAssembly application for `RGF.DemoApp`, including the interactive RGF UI experience.
- `RGF.Demo.BlazorWasm`: Legacy Blazor WebAssembly demo application retained for reference and backward compatibility.
- `RGF.Demo.MVC`: Legacy ASP.NET Core MVC demo application retained for reference and backward compatibility.

## Related Packages

[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.RecroGridFramework.Abstraction.svg?label=Recrovit.RecroGridFramework.Abstraction)](https://www.nuget.org/packages/Recrovit.RecroGridFramework.Abstraction/)
[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.RecroGridFramework.Client.svg?label=Recrovit.RecroGridFramework.Client)](https://www.nuget.org/packages/Recrovit.RecroGridFramework.Client/)
[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.RecroGridFramework.Client.Blazor.svg?label=Recrovit.RecroGridFramework.Client.Blazor)](https://www.nuget.org/packages/Recrovit.RecroGridFramework.Client.Blazor/)
[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.RecroGridFramework.Client.Blazor.UI.svg?label=Recrovit.RecroGridFramework.Client.Blazor.UI)](https://www.nuget.org/packages/Recrovit.RecroGridFramework.Client.Blazor.UI/)
[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.RecroGridFramework.Blazor.RgfApexCharts.svg?label=Recrovit.RecroGridFramework.Blazor.ApexCharts)](https://www.nuget.org/packages/Recrovit.RecroGridFramework.Blazor.ApexCharts/)

[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.RecroGridFramework.Client.Blazor.Host.OpenIdConnect.svg?label=Recrovit.RecroGridFramework.Client.Blazor.Host.OpenIdConnect)](https://www.nuget.org/packages/Recrovit.RecroGridFramework.Client.Blazor.Host.OpenIdConnect/)
[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.RecroGridFramework.Client.Blazor.SessionAuth.svg?label=Recrovit.RecroGridFramework.Client.Blazor.SessionAuth)](https://www.nuget.org/packages/Recrovit.RecroGridFramework.Client.Blazor.SessionAuth/)

[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.AspNetCore.Authentication.OpenIdConnect?label=Recrovit.AspNetCore.Authentication.OpenIdConnect)](https://www.nuget.org/packages/Recrovit.AspNetCore.Authentication.OpenIdConnect/)
[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.AspNetCore.Components.Routing.svg?label=Recrovit.AspNetCore.Components.RoutingCore)](https://www.nuget.org/packages/Recrovit.AspNetCore.Components.RoutingCore/)

[![NuGet Version](https://img.shields.io/nuget/v/Recrovit.RecroGridFramework.Core.svg?label=Recrovit.RecroGridFramework.Core)](https://www.nuget.org/packages/Recrovit.RecroGridFramework.Core/)
[![NuGet Version](https://img.shields.io/nuget/v/Recrogrid.svg?label=Recrogrid)](https://www.nuget.org/packages/Recrogrid/) ![NuGet Downloads](https://img.shields.io/nuget/dt/RecroGrid)

Official Website: [RecroGrid Framework](https://RecroGridFramework.com)

