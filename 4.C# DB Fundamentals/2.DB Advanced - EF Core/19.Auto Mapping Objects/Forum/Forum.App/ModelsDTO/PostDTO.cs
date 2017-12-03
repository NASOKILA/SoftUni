namespace Forum.App.Commands
{
    //Oshte edno DTO za postove koeto shte durji razlichni neshta
    public  class PostDTO
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Authorusername { get; set; }

        //Sega veche shte mojem da si slojim neshtata vutre i da grupirame kakto iskame !

    }
}