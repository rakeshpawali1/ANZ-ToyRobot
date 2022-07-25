

namespace ANZ_ToyRobot;

public class MainProcessor
{
    public ActionProcessor actionProcessor = new ActionProcessor();

    public static void Main()
    {
        MainProcessor MainProcessor = new MainProcessor();
        Console.WriteLine("Please enter Robot instructions");
        string input;
        while ((input = Console.ReadLine()) != null)
        {
            input = input.ToUpper();
            if (input.Contains("PLACE"))
            {
                MainProcessor.ProcessPlaceCommand(input);
            }
            else
            {
                MainProcessor.ProcessOtherCommand(input);
            }
        }
    }

    public void ProcessPlaceCommand(string command)
    {
        string[] placeList = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (placeList.Length == 4)
        {
            int xCordinate;
            int yCordinate;
            string direction = placeList[3];
            if (Int32.TryParse(placeList[1], out xCordinate) && Int32.TryParse(placeList[2], out yCordinate))
            {
                actionProcessor.Place(xCordinate, yCordinate, direction);
            }
        }
        else
        {
            Console.WriteLine("Please enter proper place instructions \nPLACE X,Y,F");
            
        }
    }

    public void ProcessOtherCommand(string command)
    {
        if (actionProcessor.robot == null)
        {
            Console.WriteLine("Robot is not placed on the Table. Please place the Robot on the Table ");
            return;
        }

        switch (command)
        {
            case "REPORT":
                actionProcessor.Report();
                break;
            case "LEFT":
                actionProcessor.TurnLeft();
                break;
            case "RIGHT":
                actionProcessor.TurnRight();
                break;
            case "MOVE":
                actionProcessor.Move();
                break;
        }
    }
}