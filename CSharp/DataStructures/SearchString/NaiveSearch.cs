using System;
using System.Collections.Generic;

namespace SearchString
{
    public class NaiveSearch : IStringSearchAlgorithm
    {
        IEnumerable<ISearchMatch> IStringSearchAlgorithm.Search(string toFind, string toSearch)
        {
            var foundMatches = new LinkedList<ISearchMatch>();

            for (int i = 0; i <= toSearch.Length - toFind.Length; i++)
            {
                int matchSymbolsCount = 0;
                while (toSearch[i + matchSymbolsCount] == toFind[matchSymbolsCount]){
                    matchSymbolsCount++;
                    if (matchSymbolsCount == toFind.Length)
                    {
                        yield return new SearchMatch(i,matchSymbolsCount);
                        i += matchSymbolsCount - 1;
                        break;
                    }
                }
            }
        }
    }
}
