using System.Reflection;

namespace Trakk.Utils.Helpers;

public class VersionHelper
{
    public static Version? Version => typeof(VersionHelper).Assembly.GetName().Version;
}