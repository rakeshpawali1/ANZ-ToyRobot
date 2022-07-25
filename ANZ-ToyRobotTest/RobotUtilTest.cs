using ANZ_ToyRobot;

namespace ToyRobotTest;

public class RobotUtilTest
{
    [Test]
    public void TestIsValidLocationSuccess()
    {
        Assert.True(RobotUtil.IsValidLocation(1, 1, new Table(5, 5)));
    }
    
    [Test]
    public void TestIsValidLocationFail()
    {
        Assert.False(RobotUtil.IsValidLocation(5, 1, new Table(5, 5)));
    }
    [Test]
    public void TestIsValidLocationFailYCor()
    {
        Assert.False(RobotUtil.IsValidLocation(1, 5, new Table(5, 5)));
    }
    
    [Test]
    public void TestIsValidDirection()
    {
        Assert.False(RobotUtil.IsValidDirection("TEST"));
    }
    
    [Test]
    public void TestIsValidDirectionSuccess()
    {
        Assert.True(RobotUtil.IsValidDirection("NORTH"));
    }
    
    [Test]
    public void TestIsValidDirectionSuccessSouth()
    {
        Assert.True(RobotUtil.IsValidDirection("SOUTH"));
    }
}