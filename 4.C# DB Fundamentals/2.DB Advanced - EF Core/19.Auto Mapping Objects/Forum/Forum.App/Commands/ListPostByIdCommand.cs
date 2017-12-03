namespace Forum.App.Commands
{
    using AutoMapper;
    using Forum.App.Commands.Contracts;
    using Forum.App.Models;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ListPostByIdCommand : ICommand
    {
        private readonly IPostService postService;
        
        public ListPostByIdCommand(IPostService IPostService)
        {
            this.postService = IPostService;
        }

        public string Excecute(params string[] args)
        {

            int id = int.Parse(args[0]);

            var post = postService.getById(id);

            if(post == null)
            {
                return $"No such post exixsts !";
            }



            /*

            //SUZDAVAME SI NOVO PostDTO I SI GO PULNIM RUCHNO S DANNI
            var postDTO = new ListPostDTO()
            {
                Id = post.Id,

                Content = post.Content,

                AuthorUsername = post.Author.UserName,


                //Pulnim si replies no trqbva da e s ReplyDTO, taka sme go napravili.
                Replies = post.Replies.Select(r => new ReplyDTO {
                    AuthotUsername = r.Author.UserName,
                     Content = r.Content
                }),

            };
            
             */


            //PULNENE S AUTOMAPPER: Ako mappera ne e konfiguriran shte ni hvurli exception
            var postDTO = Mapper.Map<ListPostDTO>(post); //RABOTI PERFEKTNO !
            
            //NAPULNIHME SI DTO-tata I SEGA SHTE GI POLZVAME 
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{postDTO.Id} {postDTO.Title} {postDTO.Content}  -  {postDTO.ReplyCount}");

            foreach (var ReplyDTO in postDTO.Replies)
                sb.AppendLine($"-{ReplyDTO.AuthotUsername} {ReplyDTO.Content}");
            
            //DTO-tata SI RABOTAT PERFEKTNO.

            return sb.ToString();

        }
    }
}
