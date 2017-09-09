using System;

namespace SearchString
{
    public interface ISearchMatch
    {
        int StartIndex { get; }

        int MatchCount { get; }
    }
}