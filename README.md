# Clear Channel Senior QA Engineer Test

## Introduction

Thank you for your consideration.

## Things to install

1. Install Visual studio commniunty edition or above.

## Getting started

1. Clone repo or download the zip file.
2. Unzip the file.
3. Open ClearChannel.sln using Visual Studio.
4. Right click on the solution name at the top of solution explorer tree and select Restore NuGet Packages.
5. Right click on the project name within the solution explorer tree and select Build.
6. If not open yet, right click on Test at the top, windows and select Test Explorer to run test.
7. Select SearchFeature and right click to run selected test.

## If you want to run test with other search term parameters

1. Click on folder called Features, Search and select Search.feature
2. Change the search parameters within the Examples table accordingly.
3. Right click on the project name within the solution explorer tree and select Build.
4. Navigate back to the Test Explorer to run test.
5. Select SearchFeature and right click to run selected test.

## If you want to run test with Firefox browser

1. Replace @Chrome with @Firefox tag ontop of each Scenario.
2. And run test again using Firefox.

## Something to take Note

1. There is log file been created after each test run, this should be seating in the bin directory of the project
2. There is also a screenshot folder with screenshot of failed pages been created should there be any test failures.


# Thank you.
