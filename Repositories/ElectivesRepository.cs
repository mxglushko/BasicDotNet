using DB;
using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repositories.Extentions;
using Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Request;

namespace Repositories
{
    public sealed class ElectivesRepository : BaseRepository, IElectivesRepository
    {
        public ElectivesRepository(BasicDotNetDataContext DbContext) : base(DbContext) { }

        /// <summary>
        /// Get electives info as page
        /// </summary>
        public async Task<IEnumerable<Elective>> GetPageAsync(ElectiveFilter filter)
        {
            return await DbContext.Electives.AsNoTracking()
                                            .Select(e => new Elective(e.Id, e.Name))
                                            .ApplyFilter(filter)
                                            .ToArrayAsync();
        }

        /// <summary>
        /// Get electives with schoolchildren
        /// </summary>
        // TODO [M.Go]: Add Groupby
        // TODO [M.Go]: Add electiveId tp Filter
        // TODO [M.Go]: Add mapping from db model
        public async Task<IEnumerable<SchoolchildrenElectives>> GetWithSchollchildrenAsync(ElectiveFilter filter)
        {
            return await DbContext.SchoolchildrenElectives.AsNoTracking()
                                                          .Where(se => se.ElectiveId == filter.Id)
                                                          .Include(se => se.Elective)
                                                          .Include(se => se.Schoolchildren)
                                                          .Select(se => new SchoolchildrenElectives
                                                          {
                                                              Elective = new Elective(se.Elective.Id, se.Elective.Name),
                                                              Schoolchildren = new Schoolchildren(se.Schoolchildren.Id, se.Schoolchildren.Name)
                                                          })
                                                          .ApplyFilter(filter)
                                                          .ToArrayAsync();
        }

        /// <summary>
        /// Creates elective
        /// </summary>
        // TODO [M.Go]: Add exceptions
        public async Task<Elective> CreateAsync(Elective elective)
        {
            if (elective is null)
            {
                return null;
            }

            var dbElective = await DbContext.Electives.FindAsync(elective.Id);
            if (dbElective is null)
            {
                DbContext.Electives.Add(new ElectiveDB { Name = elective.Name });
                DbContext.SaveChanges();
            }

            dbElective = await DbContext.Electives.OrderBy(e => e.Name)
                                                  .LastAsync(e => e.Name == elective.Name);
            return new Elective(dbElective.Id, dbElective.Name);
        }

        /// <summary>
        /// Updates elective
        /// </summary>
        public async Task<Elective> UpdateAsync(Elective elective)
        {
            if (elective is null)
            {
                return null;
            }

            var dbElective = await DbContext.Electives.FindAsync(elective.Id);
            if (dbElective is null)
            {
                return await CreateAsync(elective);
            }
            else
            {
                dbElective.Name = elective.Name;
                DbContext.SaveChanges();
            }


            dbElective = await DbContext.Electives.OrderBy(e => e.Name)
                                                  .LastAsync(e => e.Name == elective.Name);
            return new Elective(dbElective.Id, dbElective.Name);
        }

        /// <summary>
        /// Removes elective
        /// </summary>
        public async Task<int> DeleteAsync(int electiveId)
        {
            var dbElective = await DbContext.Electives.FindAsync(electiveId);
            if (dbElective is not null)
            {
                DbContext.Electives.Remove(dbElective);
                DbContext.SaveChanges();

                return StatusCodes.Status200OK;
            }

            return StatusCodes.Status404NotFound;
        }
    }
}