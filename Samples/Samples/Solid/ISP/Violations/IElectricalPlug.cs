namespace Samples.Solid.ISP.Violations;

public interface IElectricalPlug
{
    bool Supports10A { get; }
    bool Supports20A { get; }
    bool Supports110V { get; }
    bool Supports250V { get; }

    bool USFormat { get; }
    bool EUFormat { get; }
    bool BRFormat { get; }
}