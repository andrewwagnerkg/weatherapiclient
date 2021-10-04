namespace TestTask.Infrastructure
{
    internal static class UnitEnumExtensions
    {
        internal static string GetAPIUnit(this UnitEnum unit)
        {
            switch (unit)
            {
                case UnitEnum.Celsious: return "metric";
                case UnitEnum.Farengate: return "imperial";
                default: return "standart";
            }
        }
    }
}
