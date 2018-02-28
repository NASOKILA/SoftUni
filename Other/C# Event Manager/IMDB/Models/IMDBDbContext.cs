using System.Data.Entity;

namespace IMDB.Models
{   
    public class IMDBDbContext : DbContext //NASLEDQVA KLASA DbContext
    {
        //Tuk polzvam Interfeis za eventite
        //virtual oznachava che moje da se prezapisva
        public virtual IDbSet<Event> Events { get; set; }

        //TOZI KLAS NI E VRUZKATA S BAZATA !!!

        //Tozi konstruktor izvikva basoviq toest tozi na Parenta  na klasa koito e DbContext
        public IMDBDbContext() : base("IMDB")
        {}
    }
}
