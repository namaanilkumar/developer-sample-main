using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        public Swallow(SwallowType swallowType)
        {
            Type = swallowType;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            //if (Type == SwallowType.African && Load == SwallowLoad.None)
            //{
            //    return 22;
            //}
            //if (Type == SwallowType.African && Load == SwallowLoad.Coconut)
            //{
            //    return 18;
            //}
            //if (Type == SwallowType.European && Load == SwallowLoad.None)
            //{
            //    return 20;
            //}
            //if (Type == SwallowType.European && Load == SwallowLoad.Coconut)
            //{
            //    return 16;
            //}
            //throw new InvalidOperationException();


            // We can use swith case to improve the code  

            return (Type, Load) switch
            {
                (SwallowType.African, SwallowLoad.None) => 22,
                (SwallowType.African, SwallowLoad.Coconut) => 18,
                (SwallowType.European, SwallowLoad.None) => 20,
                (SwallowType.European, SwallowLoad.Coconut) => 16,
                _ => throw new InvalidOperationException("invalid swallow type and swallow load."),
            };
        }
    }
}