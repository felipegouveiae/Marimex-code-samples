namespace Samples.Solid.ISP.Violations;

public class BrazilianPlug : IElectricalPlug
{
    public bool Supports10A => true;
    public bool Supports20A => true;
    public bool Supports110V => true;
    public bool Supports250V => true;
    public bool USFormat => false;
    public bool EUFormat => false;
    public bool BRFormat => true;
}

public class USPlug : IElectricalPlug
{
    public bool Supports10A => true;
    public bool Supports20A => true;
    public bool Supports110V => true;
    public bool Supports250V => false;
    public bool USFormat => true;
    public bool EUFormat => false;
    public bool BRFormat => false;
}














