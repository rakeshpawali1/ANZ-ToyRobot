using System.Text.RegularExpressions;

namespace ANZ_ToyRobot;

public class RobotUtil
{
    public static bool IsValidLocation(int xCordinate, int yCordinate, Table table) 
        => xCordinate >= 0 && xCordinate < table.width && yCordinate >= 0 && yCordinate < table.length;

    public static bool IsValidDirection(string direction) 
        => Regex.IsMatch(direction, "SOUTH|NORTH|EAST|WEST");
}