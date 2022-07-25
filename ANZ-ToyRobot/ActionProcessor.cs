

namespace ANZ_ToyRobot;

public class ActionProcessor
{
    private Table Table = new Table(5, 5);
    public Robot robot;

    public void Place(int xCordinate, int yCordinate, string direction)
    {
        if (RobotUtil.IsValidLocation(xCordinate, yCordinate, Table) && RobotUtil.IsValidDirection(direction))
        {
            robot = new Robot(xCordinate, yCordinate, direction);
        }
    }


    public void Report()
    {
        if (robot == null)
        {
            Console.WriteLine("Robot is not placed on the Table. Please place the Robot on the Table");
            return;
        }

        Console.WriteLine("Output: " +   robot.xCordinate + "," + robot.yCordinate + "," + robot.direction);
    }

    public void Move()
    {
        switch (robot.direction)
        {
            case "EAST":
                Move(robot.xCordinate+1, robot.yCordinate);
                break;
            case "WEST":
                Move(robot.xCordinate-1, robot.yCordinate);
                break;
            case "NORTH":
                Move(robot.xCordinate, robot.yCordinate+1);
                break;
            case "SOUTH":
                Move(robot.xCordinate, robot.yCordinate-1);
                break;
        }
    }

    public void Move(int xCordinate, int yCordinate)
    {
        if (RobotUtil.IsValidLocation(xCordinate, yCordinate, Table))
        {
            robot.xCordinate = xCordinate;
            robot.yCordinate = yCordinate;
        }
    }

    public void TurnLeft()
    {
        switch (robot.direction)
        {
            case "EAST":
                robot.direction = "NORTH";
                break;
            case "WEST":
                robot.direction = "SOUTH";
                break;
            case "NORTH":
                robot.direction = "WEST";
                break;
            case "SOUTH":
                robot.direction = "EAST";
                break;
        }
    }

    public void TurnRight()
    {
        switch (robot.direction)
        {
            case "EAST":
                robot.direction = "SOUTH";
                break;
            case "WEST":
                robot.direction = "NORTH";
                break;
            case "NORTH":
                robot.direction = "EAST";
                break;
            case "SOUTH":
                robot.direction = "EAST";
                break;
        }
    }
}