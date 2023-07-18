using Crud_API.Models;

namespace API_EF6.Repositories
{
    public interface IUsuariosRepository
    {
        public Usuarios Create(Usuarios usuario);
        public bool ExistUsersEmail(string email);

        public List<Usuarios> GetallUsers();
        public Usuarios Read(int id);
        public bool Update(Usuarios usuario);
        public bool Delete(int id);


    }
    public class UsuariosRepository : IUsuariosRepository
    {

        private readonly _DbContext _context;
        
        public UsuariosRepository (_DbContext context)
        {
            _context = context;
        }

        public Usuarios Create(Usuarios usuario)
        {
            try
            {

                var createUsers = new Usuarios()
                {
                    Nome = usuario.Nome,
                    Data_Nascimento = usuario.Data_Nascimento,
                    Email = usuario.Email
                };

                _context.Add(createUsers);
                _context.SaveChanges();
                return createUsers;

            }
            catch
            {
                 throw;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var getUsers = _context.usuarios.Find(id);
                if (getUsers != null)
                {
                    _context.Remove(getUsers);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ExistUsersEmail(string email)
        {
            return _context.usuarios.Any(u => u.Email.ToLower() == email.ToLower());
        }

        public List<Usuarios> GetallUsers()
        {
            var GetUsers = _context.usuarios.AsEnumerable().ToList();
            if(GetUsers == null) throw new Exception("Não foi possível encontrar usuário");

            return GetUsers;
        }

        public Usuarios Read(int id)
        {
            try
            {
                var GetUserFromId = _context.usuarios.Find(id);
                if (GetUserFromId == null) throw new Exception("Não foi possível encontrar usuário");
                
                    return GetUserFromId;

            }
            catch
            {
                return new Usuarios();
            }
        }

        public bool Update(Usuarios usuario)
        {

            try
            {
            var GetUsers = _context.usuarios.Find(usuario.Id);

            if (GetUsers != null)
            {
                GetUsers.Nome = usuario.Nome;
                GetUsers.Email = usuario.Email;
                GetUsers.Data_Nascimento = usuario.Data_Nascimento;
                _context.SaveChanges();
                return true;
            }
                return false;
            }

            catch 
            { 
                return false; 
            }

        }
    }
    
}