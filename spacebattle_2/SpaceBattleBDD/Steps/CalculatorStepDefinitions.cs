namespace SpaceBattle.Tests;
using SpaceBattleLib;
using TechTalk.SpecFlow;

[Binding, Scope(Feature = "Поворот корабля")]
public class SpaceshipRotate
{
    private Spaceship _spaceShip = new Spaceship();
    private Exception _actualException = new Exception();
    
    [Given(@"космический корабль, угол наклона которого невозможно определить")]
    public void ДопустимКосмическийКорабльУголНаклонаКоторогоНевозможноОпределить()
    {
        _spaceShip.Position.RotateAngle = double.NaN;
    }
    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void ДопустимИмеетМгновеннуюУгловуюСкоростьГрад(double angularVelocity)
    {
        _spaceShip.Engine.AngularVelocity = angularVelocity;
    }
    [When(@"происходит вращение вокруг собственной оси")]
    public void КогдаПроисходитВращениеВокругСобственнойОси()
    {
        try
        {
            _spaceShip.Rotate();
        }
        catch (Exception e)
        {
            _actualException = e;
        }
    }
    [Then(@"возникает ошибка Exception")]
    public void ТоВозникаетОшибкаException()
    {
        Assert.ThrowsAsync<Exception>(() => throw _actualException);
    }
    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void ДопустимКосмическийКорабльИмеетУголНаклонаГрадКОсиOX(double rotateAngle)
    {
        _spaceShip.Position.RotateAngle = rotateAngle;
    }
    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void ТоУголНаклонаКосмическогоКорабляКОсиOXСоставляетГрад(double rotateAngle)
    {
        _spaceShip.Position.RotateAngle = rotateAngle;
    }
    [Given(@"мгновенную угловую скорость невозможно определить")]
    public void ДопустимМгновеннуюУгловуюСкоростьНевозможноОпределить()
    {
        _spaceShip.Engine.AngularVelocity = double.NaN;
    }
    [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
    public void ДопустимНевозможноИзменитьУголдНаклонаКОсиOXКосмическогоКорабля()
    {
        _spaceShip.Position.RotateAngle = double.NaN;
    }


}


[Binding, Scope(Feature =  "Расход топлива")]
public class SpaceshipFuel
{
    private Spaceship _spaceShip = new Spaceship();
    private Exception _actualException = new Exception();
    [When(@"происходит прямолинейное равномерное движение без деформации")]
    public void КогдаПроисходитПрямолинейноеРавномерноеДвижениеБезДеформации()
    {
        try 
        {
            _spaceShip.UniformMotion();
        }
        catch (Exception e)
        {
            _actualException = e;
        }
    }   
    [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
    public void ДопустимКосмическийКорабльИмеетТопливоВОбъемеЕд(double fuel)
    {  
        _spaceShip.Engine.Fuel = fuel;
    }
    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void ТоНовыйОбъемТопливаКосмическогоКорабляРавенЕд(double fuel)
    {
        _spaceShip.Engine.Fuel = fuel;
    }

    [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
    public void ДопустимИмеетСкоростьРасходаТопливаПриДвиженииЕд(double fuelConsumption)
    {
        _spaceShip.Engine.FuelConsumption = fuelConsumption;
    }
    [Then(@"возникает ошибка Exception")]
    public void ТоВозникаетОшибкаException()
    {
        Assert.ThrowsAsync<Exception>(() => throw _actualException);
    }
}


[Binding, Scope(Feature = "Равномерное движение корабля")]
public class SpaceshipUniformMotion_Tests
{
    private Spaceship _spaceShip = new Spaceship();
    private Exception _actualException = new Exception();
    [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
    public void CantDefinePosition()
    {
        _spaceShip.Position.Position = new double[] {double.NaN, double.NaN};
    }
    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void HasInstantSpeed(double x, double y)
    {
        _spaceShip.Engine.UniformMotionSpeed = new double[] {x, y};
    }
    
    [When(@"происходит прямолинейное равномерное движение без деформации")]
    public void ExecuteUniformMovement()
    {
        try
        {
            _spaceShip.UniformMotion();
        }
        catch(Exception e)
        {
            _actualException = e;
        }
    }
    [Then(@"возникает ошибка Exception")]
    public void TrowsExceptionExpception()
    {
        Assert.ThrowsAsync<Exception>(() => throw _actualException);
    }
    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void SpaceshipInPosition(double x, double y)
    {
        _spaceShip.Position.Position = new double[] {x, y};
    }
    [Given(@"скорость корабля определить невозможно")]
    public void CantDefineInstantSpeed()
    {
        _spaceShip.Engine.UniformMotionSpeed = new double[] {double.NaN, double.NaN};
    }
     [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void SpaceShipMoveToPoint(double x, double y)
    {
        double[] expectedCoord = new double[] {x, y};
        for (int i = 0; i < 2; i++)
        {
            Assert.Equal(expectedCoord[i], _spaceShip.Position.Position[i], 6);
        }
    }
    [Given(@"изменить положение в пространстве космического корабля невозможно")]
    public void CantChangePosition()
    {
        _spaceShip.Engine.UniformMotionSpeed = new double[] {double.NaN, double.NaN};
    }
}