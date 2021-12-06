# AoCHelper.Net

Helpers for [Advent of Code](https://adventofcode.com) in C#.

[![publish to nuget](https://github.com/danielwagn3r/AoCHelper/actions/workflows/publish.yml/badge.svg)](https://github.com/danielwagn3r/AoCHelper/actions/workflows/publish.yml) [![NuGet](https://img.shields.io/nuget/v/AoCHelper.Net.svg)](https://www.nuget.org/packages/AoCHelper.Net/)

## Usage

To get your session secret press F12 while you are logged in on [adventofcode.com](https://adventofcode.com) to open the developer tools of your browser.
Then open the Application Tab on Chromium Browsers or Storage on firefox. There you can have a look at your cookies and copy the session id. You need to provide this session id as parameter for the `InputDownloader` instance.

Example:
```csharp
string sessionId = "53418d7865....";
var downloader = new InputDownloader(sessionId);

var input = await downloader.GetInput(1, 2021);
```

