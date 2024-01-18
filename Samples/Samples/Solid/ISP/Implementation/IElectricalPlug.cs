namespace Samples.Solid.ISP.Implementation;

public class BrazilianPlug : IElectricalPlug, IElectricalPlug110V,
    IElectricalPlug250V, IElectricalPlugBRCompatible, IElectricalPlug10A,
    IElectricalPlug20A
{
}

public class USPlug : IElectricalPlug, IElectricalPlug110V, IElectricalPlug10A
    , IElectricalPlug20A, IElectricalPlugUSCompatible
{
}

public class EUPlug : IElectricalPlug, IElectricalPlug110V, IElectricalPlug10A
    , IElectricalPlug20A, IElectricalPlugEUCompatible
{
}






public interface IElectricalPlug
{
}

public interface IElectricalPlug110V
{
}

public interface IElectricalPlug10A
{
}

public interface IElectricalPlug20A
{
}

public interface IElectricalPlug250V
{
}

public interface IElectricalPlugUSCompatible
{
}

public interface IElectricalPlugEUCompatible
{
}

public interface IElectricalPlugBRCompatible
{
}