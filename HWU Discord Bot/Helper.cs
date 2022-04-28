namespace HWU_Discord_Bot;
public static class Helper
{
    public static string TimeSpanToString(TimeSpan span) =>
        (span.Days > 365 ? span.Days / 365 + "y " : "")
            + (span.Days > 0 ? span.Days % 365 + "d " : "")
            + (span.Hours > 0 ? span.Hours + "h " : "")
            + (span.Minutes > 0 ? span.Minutes + "m " : "")
            + (span.Seconds > 0 ? span.Seconds + "s " : "");
    public static TimeSpan AgoTime(DateTime date) => new ((DateTime.Now - date).Ticks);
    public static string DeleteFormatting(string str) => str.Replace("_", @"\_").Replace("*", @"\*").Replace("~", @"\~").Replace("`", @"\`");
}