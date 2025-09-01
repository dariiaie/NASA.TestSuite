# 🚀 NASA API & UI Test Automation Suite
# 📌 Overview

This repository contains an end-to-end test automation framework built with C# .NET 8 using:

API Testing → SpecFlow + RestSharp + NUnit

UI Testing → Playwright + NUnit

BDD Style → Gherkin Feature Files (SpecFlow)

The framework validates NASA's DONKI API endpoints (CME, FLR) and automates the API Key sign-up flow on the NASA Open APIs
 website.
 
🏗 Project Structure

```
NASA.TestSuite
 ┣ NASA.Tests.API          # API Project
 ┃ ┣ Dependencies
 ┃ ┣ Features              # Gherkin feature files
 ┃ ┃ ┣ CME.feature
 ┃ ┃ ┗ FLR.feature
 ┃ ┣ Steps                 # API step implementations
 ┃ ┃ ┗ CmeFlrSteps.cs      
 ┃ ┗ specflow.json
 ┣ NASA.Tests.Common       # Helper Method Project
 ┃ ┣ Dependencies
 ┃ ┣ Helpers
 ┃ ┃ ┗ ApiClient.cs
 ┣ NASA.Tests.UI           # UI Project 
 ┃ ┣ Dependencies
 ┃ ┣ Features              # Gherkin feature files
 ┃ ┃ ┗ Signup.feature
 ┃ ┣ Steps                 # UI step implementations
 ┃ ┃ ┗ SignupSteps.cs
 ┗ README.md

```

## ⚙️ Tech Stack
- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [NUnit](https://nunit.org/)  
- [SpecFlow](https://specflow.org/)  
- [RestSharp](https://restsharp.dev/)  
- [Playwright for .NET](https://playwright.dev/dotnet/)  

🚀 Getting Started
## Clone the Repo
git clone https://github.com/dariiaie/NASA.TestSuite.git <br>
cd NASA.TestSuite

## Install Prerequisites

Visual Studio 2022 with .NET desktop development workload

.NET 8 SDK

(Optional) SpecFlow for Visual Studio extension

## Install Dependencies

Restore NuGet packages:
```bash
dotnet restore

```
Install Playwright browsers:
```bash
dotnet tool install --global Microsoft.Playwright.CLI
playwright install

```

Install the SpecFlow+ LivingDoc CLI tool:
```bash
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

```


▶ Running Tests

Run All Tests
```bash
dotnet test --configuration Release
```

Run API Tests Only
```bash
dotnet test NASA.Tests.API/NASA.Tests.API.csproj --configuration Release
```

Run UI Tests Only
```bash
dotnet test NASA.Tests.UI/NASA.Tests.UI.csproj  --configuration Release
```
📊 Reporting
Generate LivingDoc Reports <br>
For API Tests:

```bash
livingdoc test-assembly NASA.Tests.API/bin/Release/net8.0/NASA.Tests.API.dll \
  -t NASA.Tests.API/bin/Release/net8.0/TestExecution.json \
  -o LivingDoc_API.html

  ```
For UI Tests:

```bash
livingdoc test-assembly NASA.Tests.UI/bin/Release/net8.0/NASA.Tests.UI.dll \
  -t NASA.Tests.UI/bin/Release/net8.0/TestExecution.json \
  -o LivingDoc_UI.html

  ```

---

🔑 NASA API Configuration
The framework uses NASA's DEMO_KEY by default (rate-limited). For production testing, obtain your own API key:

Register at NASA API Portal

Set environment variable:

Windows (PowerShell):

powershell
```bash
$env:NASA_API_KEY="YOUR_ACTUAL_API_KEY"  

```
<br>
Linux/macOS:

```bash
export NASA_API_KEY="YOUR_ACTUAL_API_KEY"

```

---

---
📦 Continuous Integration (GitHub Actions)

The pipeline (.github/workflows/ci.yml) runs automatically on each push request:

Restores NuGet dependencies

Installs Playwright browsers

Runs API & UI tests headless

Uploads LivingDoc HTML reports as build artifacts

CI → Report is available in GitHub Actions artifacts (LivingDoc_API.html, LivingDoc_UI.html)

---

---
🧩 Possible Improvements

Add screenshots & trace logs for failed UI tests

Introduce parallel test execution

Extendable → Can integrate with Allure or ExtentReports

---



