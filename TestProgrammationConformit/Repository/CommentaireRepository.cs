using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Repository
{
    public class CommentaireRepository : ICommentaireRepository
    {
        private readonly ConformitContext db;
        public CommentaireRepository(ConformitContext db) => this.db = db;

        public bool create(Commentaire commentaire)
        {
            this.db.Commentaires.Add(commentaire);
            //commentaire.id = this.db.SaveChanges();
            return save();
        }

        public bool update(Commentaire commentaire)
        {
            this.db.Commentaires.Update(commentaire);
            return save();// ? commentaire : null;
        }

        public bool deleteById(int id)
        {
            Commentaire com = this.db.Commentaires.FirstOrDefault(a => a.id == id);
            if( com!=null )
            this.db.Remove(com);

            return save();

        }

        public ICollection<Commentaire> getAll()
        {
            return this.db.Commentaires.ToList();
        }

        public Commentaire getById(int id)
        {
            return this.db.Commentaires.FirstOrDefault( a => a.id == id );
        }
        public bool save()
        {
            return this.db.SaveChanges()>=0 ? true : false;
        }
    }
}
