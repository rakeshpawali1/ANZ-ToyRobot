namespace ToyRobotTest;
using ANZ_ToyRobot;
public class MainProcessorTest
{
    [Test]
    public void TestProcessPlaceCommandSuccess()
    {
        MainProcessor mainProcessor = new MainProcessor();
        string command = "PLACE 1, 1, NORTH";
        mainProcessor.ProcessPlaceCommand(command);
        Assert.NotNull(mainProcessor.actionProcessor.robot );
    }
    
    [Test]
    public void TestProcessPlaceWrongDirection()
    {
        MainProcessor mainProcessor = new MainProcessor();
        string command = "PLACE 1, 1, N";
        mainProcessor.ProcessPlaceCommand(command);
        Assert.Null(mainProcessor.actionProcessor.robot );
    }
    
    [Test]
    public void TestProcessPlaceInvalidLocation1()
    {
        MainProcessor mainProcessor = new MainProcessor();
        string command = "PLACE 1, -1, NORTH";
        mainProcessor.ProcessPlaceCommand(command);
        Assert.Null(mainProcessor.actionProcessor.robot );
    }
    
    [Test]
    public void TestProcessPlaceInvalidLocation2()
    {
        MainProcessor mainProcessor = new MainProcessor();
        string command = "PLACE 1, 5, NORTH";
        mainProcessor.ProcessPlaceCommand(command);
        Assert.Null(mainProcessor.actionProcessor.robot );
    }
    [Test]
    public void TestProcessOtherActionRobotNotInitialised()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            MainProcessor mainProcessor = new MainProcessor();
            string command = "PLACE 1, 5, N";
            mainProcessor.ProcessPlaceCommand(command);
            mainProcessor.ProcessOtherCommand("MOVE");
            string expected = "Robot is not placed on the Table. Please place the Robot on the Table \n";
            Assert.That(sw.ToString(), Is.EqualTo(expected));
            
        }
    }
    
    [Test]
    public void TestProcessOtherActionMove()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            MainProcessor mainProcessor = new MainProcessor();
            string command = "PLACE 1, 1, NORTH";
            mainProcessor.ProcessPlaceCommand(command);
            mainProcessor.ProcessOtherCommand("MOVE");
            mainProcessor.ProcessOtherCommand("REPORT");
            string expected = "Output: 1,2,NORTH\n";
            Assert.That(sw.ToString(), Is.EqualTo(expected));
            
        }
    }
    
    [Test]
    public void TestProcessOtherActionMoveNoChange()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            MainProcessor mainProcessor = new MainProcessor();
            string command = "PLACE 1, 4, NORTH";
            mainProcessor.ProcessPlaceCommand(command);
            mainProcessor.ProcessOtherCommand("MOVE");
            mainProcessor.ProcessOtherCommand("REPORT");
            string expected = "Output: 1,4,NORTH\n";
            Assert.That(sw.ToString(), Is.EqualTo(expected));
            
        }
    }
    
    [Test]
    public void TestProcessOtherActionTurnLeft()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            MainProcessor mainProcessor = new MainProcessor();
            string command = "PLACE 1, 4, NORTH";
            mainProcessor.ProcessPlaceCommand(command);
            mainProcessor.ProcessOtherCommand("LEFT");
            mainProcessor.ProcessOtherCommand("REPORT");
            string expected = "Output: 1,4,WEST\n";
            Assert.That(sw.ToString(), Is.EqualTo(expected));
            
        }
    }
    
    [Test]
    public void TestProcessOtherActionTurnRight()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            MainProcessor mainProcessor = new MainProcessor();
            string command = "PLACE 1, 4, NORTH";
            mainProcessor.ProcessPlaceCommand(command);
            mainProcessor.ProcessOtherCommand("RIGHT");
            mainProcessor.ProcessOtherCommand("REPORT");
            string expected = "Output: 1,4,EAST\n";
            Assert.That(sw.ToString(), Is.EqualTo(expected));
            
        }
    }
}