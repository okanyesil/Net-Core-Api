using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAngularBlogCore.api.Responses
{
    public class ArticleResponse
    {
        public int  ID { get; set; }
        public string  Title { get; set; }
        public string MainContent { get; set; }
        public string ContentSummary { get; set; }
        public DateTime  PublishDate { get; set; }
        public string Picture { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }

        public CategoryResponse Category { get; set; }

    }
}
