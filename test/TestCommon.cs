namespace Hangry.Test;

internal static class TestCommon
{
    internal static Func<string, Stream> TestFileReader = ((path) =>
    {
        return File.OpenRead(path);
    });
}
