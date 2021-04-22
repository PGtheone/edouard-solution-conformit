using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Payload;
using TestProgrammationConformit.Wrapper;

namespace TestProgrammationConformit.Repository
{
    public class EvenementRepository : IEvenementRepository
    {
        private readonly ConformitContext db;
        public EvenementRepository( ConformitContext db) => this.db = db;

        public bool create(Evenement evenement)
        {
            this.db.Evenements.Add(evenement);
            return save();
        }

        public bool update(Evenement evenement)
        {
            this.db.Evenements.Update(evenement);
            return save();
        }

        public bool deleteById(int id)
        {
            Evenement com = this.db.Evenements.FirstOrDefault(a => a.id == id);
            if (com != null)
                this.db.Remove(com);

            return save();

        }

        public PagedResponse<Evenement> getAll(PaginationPayload filter)
        {
           var  eventList=  this.db.Evenements
                .Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
                .Include(e=> e.comments).ToList();

            var totalRecords =  db.Evenements.Count();
           
            return new PagedResponse<Evenement>(eventList, filter.PageNumber, filter.PageSize, totalRecords);

        }

        public Evenement getById(int id)
        {
            return this.db.Evenements.Include(e => e.comments).FirstOrDefault(a => a.id == id);
        }
        public bool save()
        {
            return this.db.SaveChanges() >= 0 ? true : false;
        }
    }
}
