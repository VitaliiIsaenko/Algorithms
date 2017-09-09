using System;

namespace SearchString
{
    public class SearchMatch : ISearchMatch
    {
        public SearchMatch(int startIndex, int matchCount)
        {
            this.StartIndex = startIndex;
            this.MatchCount = matchCount;
        }

        public int StartIndex { get; private set; }
        public int MatchCount { get; private set; }
    }
}