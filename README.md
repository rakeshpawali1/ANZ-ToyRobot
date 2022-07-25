# Toy Robot Simulator

## Problem statement
The application is a simulation of a toy robot moving on a square tabletop, of dimensions
5 units x 5 units.

## Technlogies
- C#
- Dotnet 6

## IDE used
JetBrains Rider
https://www.jetbrains.com/rider/

## Application flow

MainProcessor -- > Start of the application
- Takes user input from command line
- Initializes and places the robot on the 5*5 Table
- Input validation
- If the inputs are not well-formed then Robot is not initialized
- Appropriate error messages are displayed
- Robot will not be moved if it's going out of the table
- Input directions are validated. Inputs are case-insensitive



