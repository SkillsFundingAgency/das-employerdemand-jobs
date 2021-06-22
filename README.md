## ⛔Never push sensitive information such as client id's, secrets or keys into repositories including in the README file⛔

# Employer Demand Jobs

<img src="https://avatars.githubusercontent.com/u/9841374?s=200&v=4" align="right" alt="UK Government logo">


[![Build Status](https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_apis/build/status/das-employerdemand-jobs?branchName=main)](https://dev.azure.com/sfa-gov-uk/Digital%20Apprenticeship%20Service/_build/latest?definitionId=_projectid_&branchName=main)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=_projectId_&metric=alert_status)](https://sonarcloud.io/dashboard?id=_projectId_)
[![Jira Project](https://img.shields.io/badge/Jira-Project-blue)](https://skillsfundingagency.atlassian.net/secure/RapidBoard.jspa?rapidView=564&projectKey=_projectKey_)
[![Confluence Project](https://img.shields.io/badge/Confluence-Project-blue)](https://skillsfundingagency.atlassian.net/wiki/spaces/_pageurl_)
[![License](https://img.shields.io/badge/license-MIT-lightgrey.svg?longCache=true&style=flat-square)](https://en.wikipedia.org/wiki/MIT_License)

Employer Demand Jobs is an Azure Function responsible for executing any scheduled or automated tasks necessary for normal operation of the Employer Demand system. This currently includes: 
* reminder emails
* expiration of employer demands


## How It Works

Employer Demand Jobs calls the employer demand outer api, [das-apim-endpoints](https://github.com/skillsfundingagency/das-apim-endpoints), for all of its operations. The Azure Functions use time based triggers to start its operations.

## 🚀 Installation

### Pre-Requisites

* A clone of this repository
* A code editor that supports Azure functions and .NetCore 3.1
* It would also make sense to have [das-apim-endpoints](https://github.com/skillsfundingagency/das-apim-endpoints) installed if you want to run locally, and the associated inner api's required for employer demand outer api.

The triggers can also be executed ad hoc by calling the function directly, for example:
```
POST http://localhost:7071/admin/functions/SendCourseStoppedEmailsTimerTrigger
Headers Content-Type application/json
body :{}
```

### Config

This utility uses the standard Apprenticeship Service configuration. All configuration can be found in the [das-employer-config repository](https://github.com/SkillsFundingAgency/das-employer-config).

* Add an appsettings.Development.json file
* Add table storage config


AppSettings.Development.json file
```json
{
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft": "Warning",
        "Microsoft.Hosting.Lifetime": "Information"
      }
    },
    "ConfigurationStorageConnectionString": "UseDevelopmentStorage=true;",
    "ConfigNames": "SFA.DAS.EmployerDemand.Jobs",
    "EnvironmentName": "LOCAL",
    "Version": "1.0",
    "APPINSIGHTS_INSTRUMENTATIONKEY": ""
  }  
```

Azure Table Storage config

Row Key: SFA.DAS.EmployerDemand.Jobs_1.0

Partition Key: LOCAL

Data:

```json
{
  "EmployerDemandJobsApiConfiguration": {
    "Key": "test",
    "BaseUrl": "https://localhost:5003/"
  }
}
```

## 🔗 External Dependencies

* This utility uses the [das-apim-endpoints](https://github.com/skillsfundingagency/das-apim-endpoints) Api to perform all operations. You will need to install this api locally, and all it's dependant inner apis locally in order to run it.


## Technologies

* .NetCore 3.1
* Azure Functions V3
* NLog
* Azure Table Storage
* NUnit
* Moq
* FluentAssertions


## 🐛 Known Issues

