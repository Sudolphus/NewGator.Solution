<p align="center">
  <a href="" rel="noopener">
 <img width=200px height=200px src="https://i.imgur.com/6wj0hh6.jpg" alt="Project logo"></a>
</p>

<h3 align="center">NewsGator</h3>

<div align="center">

[![Status](https://img.shields.io/badge/status-active-success.svg)]()
[![GitHub Issues](https://img.shields.io/github/issues/Sudolphus/NewGator.Solution.svg)](https://github.com/Sudolphus/NewGator.Solutionissues)
[![GitHub Pull Requests](https://img.shields.io/github/issues-pr/Sudolphus/NewGator.Solution.svg)](https://github.com/Sudolphus/NewGator.Solution/pulls)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](/LICENSE)

</div>

---

<p align="center"> A C#/.NET app with a React front-end for all the news that's fit to query!
    <br> 
</p>

## 📝 Table of Contents

- [About](#about)
- [Getting Started](#getting_started)
- [Deployment](#deployment)
- [Usage](#usage)
- [Built Using](#built_using)
- [TODO](./TODO.md)
- [Authors](#authors)
- [Acknowledgments](#acknowledgement)

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

For the front end:
1. Node (or other package manager)
2. A terminal, such as GIT Bash or Windows Powershell
3. A code editor

### Installing

1. Start by acquiring the repo, by either clicking the download button, or running `git clone https://github.com/Sudolphus/NewsGator.Solution`
2. You'll also need MySQL Server and .NET Framework installed (linked above)
3. Once .NET is installed, navigate into the NewsGator directory in your terminal of choice and acquire the necessary packages with `dotnet restore`
4. Install the database with `dotnet ef database update`. For this step to work, you'll need to update the {password} in appsettings.json with your MySQL password.
5. You can then build the project with `dotnet build`, or run the project directly with `dotnet run`.


## 🔧 Running the tests <a name = "tests"></a>

Explain how to run the automated tests for this system.

### Break down into end to end tests

Explain what these tests test and why

```
Give an example
```

### And coding style tests

Explain what these tests test and why

```
Give an example
```

## 🎈 Usage <a name="usage"></a>

Add notes about how to use the system.

## 🚀 Deployment <a name = "deployment"></a>

Add additional notes about how to deploy this on a live system.

## ⛏️ Built Using <a name = "built_using"></a>

- [MySql Server](https://dev.mysql.com/) - Database
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-core/2.2) - Development Framework

## ✍️ Authors <a name = "authors"></a>

- [Micheal Hansen](https://github.com/Sudolphus) - Idea & Initial work

See also the list of [contributors](https://github.com/kylelobo/The-Documentation-Compendium/contributors) who participated in this project.

## 🎉 Acknowledgements <a name = "acknowledgement"></a>

- Hat tip to anyone whose code was used
- Inspiration
- References
