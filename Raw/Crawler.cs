using System.Collections.Generic;

namespace Raw
{
    public interface Crawler
    {
        Article Craw(string url);

        List<string> GetListLink(string ListUrl);
    }
}