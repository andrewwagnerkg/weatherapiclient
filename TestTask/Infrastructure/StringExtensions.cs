namespace TestTask.Infrastructure
{
    internal static class StringExtensions
    {
        internal static UnitEnum GetUnit(this string unitString)
        {
            switch (unitString.ToUpper())
            {
                case "CELSIOUS": return UnitEnum.Celsious;
                case "FARENGATE": return UnitEnum.Farengate;
                default: return UnitEnum.Kelvin;
            }
        }
    }
}
