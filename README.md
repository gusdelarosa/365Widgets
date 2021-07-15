
# Overview

Sensor classifier based on test results. The `SensorEvaluator` project is the code that classifies Devices. 
`SensorConsoleTester` is a console app I created to test my library with the provided input in the prompt. 

## Improvements

A couple of things I would've done given more time.

- I would've like to remove the classification  from the Devices themselves. 
  - Create a generic classification service to classify a particular device and change the parameters that define the classification types. I figure these parameters/threshold would change once in a while or different testers would have different thresholds 
- Unit tests
- Add validation. Currently, the library assumes the log file string format is valid for all items
- Error handling and monitoring
- All of the readings are handled as decimals, CO readings are integers
   - I could spent more time thinking about how this would affect precision
- Better system for determining classification i.e. no hardcoded values

## Running SensorConsoleTester

VSCode and Visual Studio handle relative files differently. See `Program.cs` to change path depending on where the code is run