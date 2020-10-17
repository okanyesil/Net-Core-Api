using System;
using System.Collections.Generic;

namespace UdemyAngularBlogCore.api.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string MainContent { get; set; }
        public DateTime PublishDate { get; set; }

        public Article Article { get; set; }
    }
}
