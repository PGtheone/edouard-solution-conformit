using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Payload;
using TestProgrammationConformit.Wrapper;

namespace TestProgrammationConformit.Repository
{
    public interface IEvenementRepository
    {
        // Il doit etre possible d'ajouter, modifier, supprimer et visualiser des evenements (sous forme de liste et de manière individuel).
        // Insert
        bool create(Evenement evenement);
        // Update
        bool update(Evenement evenement);

        // Select All
        PagedResponse<Evenement> getAll(PaginationPayload filter);
        // Select by Id
        Evenement getById(int id);
        // Delete
        bool deleteById(int id);
    }
}
