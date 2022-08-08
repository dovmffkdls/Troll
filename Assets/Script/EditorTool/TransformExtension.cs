using System.Collections.Generic;
using System.Linq;

public static class TransformExtension
{
    public static bool ExIsEmpty<T>(this IEnumerable<T> enumerable)
    {
        return enumerable == null || enumerable.All(item => EqualityComparer<T>.Default.Equals(item, default));
    }
}