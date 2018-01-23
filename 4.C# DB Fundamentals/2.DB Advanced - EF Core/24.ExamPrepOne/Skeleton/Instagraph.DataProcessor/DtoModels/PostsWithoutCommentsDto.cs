namespace Instagraph.DataProcessor.DtoModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PostsWithoutCommentsDto
    {
        public int Id { get; set; }

        public string Picture { get; set; }

        public string User { get; set; }
    }
}
