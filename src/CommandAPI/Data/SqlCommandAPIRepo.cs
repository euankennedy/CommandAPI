using System.Collections.Generic;
using CommandAPI.Models;
using System.Linq;

namespace CommandAPI.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;
        public SqlCommandAPIRepo(CommandContext context)
        {
            _context = context;
        }
        void ICommandAPIRepo.CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new System.ArgumentNullException(nameof(cmd));
            }
            _context.CommandItems.Add(cmd);
        }

        void ICommandAPIRepo.DeleteCommand(Command cmd)
        {
            if (cmd == null) throw new System.ArgumentNullException(nameof(cmd));
            _context.CommandItems.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.CommandItems.FirstOrDefault(p => p.Id == id);
        }

        bool ICommandAPIRepo.SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        void ICommandAPIRepo.UpdateCommand(Command cmd)
        {
            // We don't need to do anything here
        }
    }
}