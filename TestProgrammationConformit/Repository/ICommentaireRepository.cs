using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;

namespace TestProgrammationConformit.Repository
{
    public interface ICommentaireRepository
    {
        // Gérer des commentaires pour un evenements(création, modification, suppression, visualisation).
        // Insert
        bool create(Commentaire commentaire);
        // Update
        bool update(Commentaire commentaire);

        // Select All
        ICollection<Commentaire> getAll();
        // Select by Id
        Commentaire getById(int id);
        // Delete
        bool deleteById(int id);
    }
}
