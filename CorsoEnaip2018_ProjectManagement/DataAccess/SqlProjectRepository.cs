using CorsoEnaip2018_ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ProjectManagement.DataAccess
{
    public class SqlProjectRepository : IRepository<Project>
    {
        // AL posto di IRepository<Villain> usare IRepository<Project>
        // Villain => Project

        private AppDbContext _context;

        public SqlProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(Project model)
        {
            _context.Customers.Remove(model);

            var result = _context.SaveChanges();

            return result == 1;
        }

        public Project Find(int id)
        {
            //return _context..FirstOrDefault(x => x.Id == id);
        }

        public List<Project> FindAll()
        {
            var models = _context.Customers
                .Include(x => x.Nemesis)
                .ToList();

            return models;
        }

        public void Insert(Project model)
        {
            _context.Customers.Add(model);

            _context.SaveChanges();
        }

        public bool Update(Project model)
        {
            _context.Customers.Update(model);

            var result = _context.SaveChanges();

            return result == 1;
        }
    }
}
