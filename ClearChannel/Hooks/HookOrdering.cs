namespace ClearChannel.Hooks
{
    /// <summary>
    ///     Defines the order the hook should be run in, BE CAREFUL WHEN CHANGING.
    /// </summary>
    public class HookOrdering
    {
        public const int FeatureContextSetting = 5;
        public const int UseChromeDriver = 20;
        public const int UseFireFoxDriver = 30;
        public const int LoggedOut = int.MaxValue;
    }
}
