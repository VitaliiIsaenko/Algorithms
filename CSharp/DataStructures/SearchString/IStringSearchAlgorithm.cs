using System;
using System.Collections.Generic;

namespace SearchString {
    public interface IStringSearchAlgorithm
    {
        IEnumerable<ISearchMatch> Search(string toFind, string toSearch);
    }

}