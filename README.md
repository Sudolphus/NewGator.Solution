<p align="center">
  <a href="" rel="noopener">
 <img width=640px height=426px src="./news.jpeg" alt="Project logo"></a>
</p>

<h3 align="center">NewsGator</h3>

<div align="center">

[![Status](https://img.shields.io/badge/status-active-success.svg)]()
[![GitHub Issues](https://img.shields.io/github/issues/Sudolphus/NewGator.Solution.svg)](https://github.com/Sudolphus/NewGator.Solutionissues)
[![GitHub Pull Requests](https://img.shields.io/github/issues-pr/Sudolphus/NewGator.Solution.svg)](https://github.com/Sudolphus/NewGator.Solution/pulls)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](./LICENSE.md)

</div>

---

<p align="center"> A C#/.NET app with a React front-end for all the news that's fit to query!
    <br> 
</p>

## 📝 Table of Contents

- [About](#about)
- [Getting Started](#getting_started)
- [Usage](#usage)
- [Built Using](#built_using)
- [TODO](./TODO.md)
- [Authors](#authors)

## 🧐 About <a name = "about"></a>

This app is designed to pull data from various news apis, and store that information in a ready state so the client app can pull the data with the maximum of speed.

## 🏁 Getting Started <a name = "getting_started"></a>

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See [deployment](#deployment) for notes on how to deploy the project on a live system.

### Prerequisites

For the back end:
1. MySQL Server [Mac](https://dev.mysql.com/downloads/file/?id=484914)/[Windows](https://dev.mysql.com/downloads/file/?id=484919)
2. [.NET framework](https://dotnet.microsoft.com/download/dotnet-core/2.2)
3. A terminal, such as Powershell or Git Bash
4. A MySQL manager, such as MySQL Workbench (optional)
5. A code editor, such as VS Code or Atom (optional)

### Installing

1. Start by acquiring the repo, by either clicking the download button, or running `git clone https://github.com/Sudolphus/NewsGator.Solution`
2. You'll also need MySQL Server and .NET Framework installed (linked above)
3. Once .NET is installed, navigate into the NewsGator directory in your terminal of choice and acquire the necessary packages with `dotnet restore`
4. Install the database with `dotnet ef database update`. For this step to work, you'll need to update the {password} in appsettings.json with your MySQL password.
5. You'll need to get api keys for [NewsApi](https://newsapi.org/docs/get-started) and the [New York Times](https://developer.nytimes.com/), and add them to an EnvironmentalVariables.cs file in the appropriate places:
```
namespace NewsGator.Models
{
  public static class EnvironmentalVariables
  {
    public static string NewsApiKey { get; } = (Your News API Key);
    public static string NewYorkTimesKey { get; } = (Your New York Times Key);
  }
}
```
Place this file in the NewsGator/Models folder.

6. You can then build the project with `dotnet build`, or run the project directly with `dotnet run`.


## 🔧 Running the tests <a name = "tests"></a>

Some tests for the backend are included in the NewsGator.Tests folder. To run, them, navigate into the NewsGator.Tests directory and run `dotnet test`. These tests should handle the constructors on the classes needed to standardize the API call results for consistent storage.

## 🎈 Usage <a name="usage"></a>

To use the back end, start the project as listed above, then you can load up the project in your browser by navigating to localhost:5000. You should see some buttons that will then execute the queries and display the results.

## ⛏️ Built Using <a name = "built_using"></a>

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-core/2.2) - Development Framework

## ✍️ Authors <a name = "authors"></a>

- [Micheal Hansen](https://github.com/Sudolphus) - Idea & Initial work
