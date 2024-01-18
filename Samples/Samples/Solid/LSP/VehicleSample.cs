namespace Samples.Solid.LSP;

public abstract class Vehicle
{
    public abstract void Move();
    public abstract int GetFuelStatus();
}

public class Car : Vehicle
{
    public override void Move() => Accelerate();
    public override int GetFuelStatus() => GetFuelCompleteness();

    private int GetFuelCompleteness()
    {
        throw new NotImplementedException();
    }
    private void Accelerate()
    {
        throw new NotImplementedException();
    }
}

public class Bike : Vehicle
{
    public override void Move() => Accelerate();
    public override int GetFuelStatus() => throw new NotSupportedException();
    private void Accelerate()
    {
        throw new NotImplementedException();
    }
}




