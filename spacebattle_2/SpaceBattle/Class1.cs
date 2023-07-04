﻿namespace SpaceBattleLib;
public class Spaceship
{
    public Engine Engine {get; set;}
    public PositionInSpace Position {get; set;}
    public Spaceship() 
    {
        this.Engine = new Engine();
        this.Position = new PositionInSpace();
    }
    public void SillyCheck()
    {
        List<double> allParameters = this.Position.Position.ToList<double>();
        allParameters.AddRange(this.Engine.UniformMotionSpeed);
        allParameters.Add(this.Position.RotateAngle);
        allParameters.Add(this.Engine.AngularVelocity);
        if (allParameters.Any(x => double.IsNaN(x) || double.IsInfinity(x)))
            throw new Exception();
    }
    public void UniformMotion()
    {
        SillyCheck();
        double[] instantSpeed = this.Engine.UniformMotion();
        for (int i = 0; i < 2; i++)
        {
            this.Position.Position[i] += instantSpeed[i];
        }
    }
    public void Rotate() 
    {
        SillyCheck();
        double angularVelocity = this.Engine.Rotate();
        this.Position.RotateAngle += angularVelocity;
        if (360 < this.Position.RotateAngle)
        {
            this.Position.RotateAngle -= 360;
        }
    }
}

public class PositionInSpace
{
    public double[] Position {get; set;}
    public double RotateAngle {get; set;}
    public PositionInSpace()
    {
        this.Position = new double[] {0, 0};
        this.RotateAngle = 0;
    }
}

public class Engine
{
    public double Fuel {get; set;}
    public double FuelConsumption {get; set;}
    public double[] UniformMotionSpeed {get; set;}
    public double AngularVelocity {get; set;}
    public Engine()
    {
        this.UniformMotionSpeed = new double[] {0, 0};
        this.AngularVelocity = 0;
        this.Fuel = 0;
        this.FuelConsumption = 0;
    }
    public void TryMove()
    {
        if (this.Fuel < this.FuelConsumption)
            throw new Exception();
        else 
            this.Fuel -= this.FuelConsumption;
    }
    public double[] UniformMotion()
    {
        TryMove();
        return this.UniformMotionSpeed;
    }
    public double Rotate()
    {
        TryMove();
        return this.AngularVelocity;
    }
}