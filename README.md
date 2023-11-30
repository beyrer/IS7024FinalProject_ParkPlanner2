# IS7024FinalProject_ParkPlanner2
## (Migrated from [beyrer/IS7024FinalProject](https://github.com/beyrer/IS7024FinalProject))

---

IS7024 Final Project Repository

Design Document  

Group 1  
- Neil Bechmann
- Jameson Zink
- Jessie Beyrer

## Important Information For Project Grading
The API Key for this project is "mLBONbm3NZfawfBoS0w4bXT3yyJ1nBpLhqh6o0Au"  

Please run "dotnet user-secrets init" and "dotnet user-secrets set PP-API mLBONbm3NZfawfBoS0w4bXT3yyJ1nBpLhqh6o0Au" in Visual Studio Developer Powershell terminal before trying to run this in IIS Express mode in Visual Studio. 

## Introduction  

As we look out the window today in mid-autumn, the leaves are turning multiple colors and people are longing to walk under the branches.  We wanted to find a way to plan trips to various parks for families, individuals, or any group of people wanting to experience nature.  

- Create a website about parks integrating available web data sources. (We will begin with U.S. National Park data and integrate state and local data as it becomes available.)
- Have users share content (statuses, trips, reviews or photos) of parks visited
- Provide available park amenity data to users to help them plan visits
- Integrate online weather data from another source to provide additional information to people wishing to visit parks.

Ultimately, we would like to create a better experience for people who want to be out in nature and enjoy our park resources through this web application.

## Icon/Logo  

![985a4470-2506-4270-89a9-50e6340898ef](https://github.com/beyrer/IS7024FinalProject/assets/88552005/3a55302a-d57f-4ee4-86c3-15473b3e651e)

## Storyboard

### Planned Screens/Views
![Wireframe PP](https://github.com/beyrer/IS7024/assets/88552005/e856fdd1-801b-49b3-bbfb-3865f5831321)

[WireframePP](https://whiteboard.office.com/me/whiteboards/p/c3BvOmh0dHBzOi8vbWFpbHVjLW15LnNoYXJlcG9pbnQuY29tL3BlcnNvbmFsL2JleXJlcmpsX21haWxfdWNfZWR1/b!EOSXDY993kSvqBhyr8vYCPeGUG2lOxNAtvpDuC7X9QXv1ZECSrzBSrvpeh-cKmYK/01U5X6VGB4PIU2MRR4UZAJKBTKACYJ3YWB)  

### Planned Widgets  
- Distance Calculator
- Weather Conditions at Park
- Park Status, Hours of Operation, etc.

## Projects  
-	[ParkPlanner](https://github.com/beyrer/IS7024FinalProject/tree/main/ParkPlanner)
-	[Jira Board for ParkPlanner.com](https://parkprojectis7024.atlassian.net/jira/core/projects/PAR/board)

## Requirements  
A centralized and convenient location of park data so that I can plan visits to various parks.
### Requirement 1  
---
#### Scenario
As a user, I want to be able to serach for Distance guide to parks from my current location.

#### Dependencies  
Park location data is available and accessible

#### Assumptions  
Park data is in a format that can be mapped or measured to current location.

#### Example
Given park data is available  
When I search for a park
Then I should then be able to receive the distance to that particular park.

### Requirement 2  
---  
#### Scenario
As a user I want to be able to post and review information about a specific park.

#### Dependencies  
Park data is available and accessible

#### Assumptions  
Website can record user reviews of parks and associated facilities to Park Planner

#### Example
Given park data is available  
When I search for a park
Then I should be able to post that review to Park Planner.

## Data Sources

-	[National Park Service](https://www.nps.gov/subjects/developer/api-documentation.htm)

## Team Composition  

### Team Members
- Neil Bechmann (Lead Developer)
- Jameson Zink (Developer and Lead Design)
- Jessie Beyrer (Developer and Azure/GitHub Administrator)

### Meeting Cadence
- Weekly meetings Saturdays at 5 pm
- Other ad hoc times as necessary
