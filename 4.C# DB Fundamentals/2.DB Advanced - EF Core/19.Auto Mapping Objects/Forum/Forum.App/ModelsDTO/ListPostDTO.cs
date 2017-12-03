namespace Forum.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //Tova e nasheto DTO koeto e za postove i shte durji samo nqkoi neshta ot posts
    //HUBAVO E DA GI KRUSHtaVAME TaKA CHE DA Se raZBIRA KUDE SHTE GI POLZVAME !
    public class ListPostDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorUsername { get; set; }

        public IEnumerable<ReplyDTO> Replies { get; set; }

        public int ReplyCount { get; set; }

        //VAJNO !!!  OTIDI NA ListPostByIdCommand

    }
}
