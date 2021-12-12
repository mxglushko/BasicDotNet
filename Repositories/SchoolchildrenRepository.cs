using DB;
using DB.Models;
using Domain.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repositories.Extentions;
using Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class SchoolchildrenRepository : BaseRepository, ISchoolchildrenRepository
    {
        public SchoolchildrenRepository(BasicDotNetDataContext DbContext) : base(DbContext) { }

        /// <summary>
        /// Get schoolchildren info as page
        /// </summary>
        public async Task<IEnumerable<Schoolchildren>> GetPageAsync(GetFilter filter)
        {
            return await DbContext.Schoolchildren.AsNoTracking()
                                                 .Select(s => new Schoolchildren(s.Id, s.Name))
                                                 .ApplyFilter(filter)
                                                 .ToArrayAsync();
        }

        /// <summary>
        /// Get schoolchildren with electives
        /// </summary>
        // TODO [M.Go]: Add Groupby
        // TODO [M.Go]: Add schoolchildrenId to Filter
        public async Task<IEnumerable<SchoolchildrenElectives>> GetWithElectivesAsync(int schoolchildrenId, IGetFilter filter)
        {
            return await DbContext.SchoolchildrenElectives.AsNoTracking()
                                                          .Where(se => se.SchoolchildrenId == schoolchildrenId)
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
        /// Creates schoolchildren
        /// </summary>
        public async Task<Schoolchildren> CreateAsync(Schoolchildren schoolchildren)
        {
            if (schoolchildren is null)
            {
                return null;
            }

            var dbSchoolchildren = await DbContext.Schoolchildren.FindAsync(schoolchildren.Id);
            if (dbSchoolchildren is null)
            {
                DbContext.Schoolchildren.Add(new SchoolchildrenDB { Name = schoolchildren.Name });
                DbContext.SaveChanges();
            }

            dbSchoolchildren = await DbContext.Schoolchildren.OrderBy(e => e.Name)
                                                             .LastAsync(e => e.Name == schoolchildren.Name);
            return new Schoolchildren(dbSchoolchildren.Id, dbSchoolchildren.Name);
        }

        /// <summary>
        /// Updates schoolchildren
        /// </summary>
        public async Task<Schoolchildren> UpdateAsync(Schoolchildren schoolchildren)
        {
            if (schoolchildren is null)
            {
                return null;
            }

            var dbSchoolchildren = await DbContext.Schoolchildren.FindAsync(schoolchildren.Id);
            if (dbSchoolchildren is null)
            {
                return await CreateAsync(schoolchildren);
            }
            else
            {
                dbSchoolchildren.Name = schoolchildren.Name;
                DbContext.SaveChanges();
            }


            dbSchoolchildren = await DbContext.Schoolchildren.OrderBy(e => e.Name)
                                                             .LastAsync(e => e.Name == schoolchildren.Name);
            return new Schoolchildren(dbSchoolchildren.Id, dbSchoolchildren.Name);
        }

        /// <summary>
        /// Deletes schoolchildren
        /// </summary>
        public async Task<int> DeleteAsync(int schoolchildrenId)
        {
            var dbSchoolchildren = await DbContext.Schoolchildren.FindAsync(schoolchildrenId);
            if (dbSchoolchildren is not null)
            {
                DbContext.Schoolchildren.Remove(dbSchoolchildren);
                DbContext.SaveChanges();

                return StatusCodes.Status200OK;
            }

            return StatusCodes.Status404NotFound;
        }
    }
}