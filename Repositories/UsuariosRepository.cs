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

        // Método responsável por criar um novo registro de usuário no banco de dados.

        public Usuarios Create(Usuarios usuario)
        {
            try
            {
                // Cria um novo objeto "Usuarios" baseado nos dados fornecidos.
                var createUsers = new Usuarios()
                {
                    Nome = usuario.Nome,
                    Data_Nascimento = usuario.Data_Nascimento,
                    Email = usuario.Email
                };

                // Adiciona o novo objeto "Usuarios" ao contexto "_context"
                _context.Add(createUsers);

                // Salva as alterações no banco de dados.
                _context.SaveChanges();

                // Retorna o objeto "Usuarios" recém-criado após a operação de criação no banco de dados.
                return createUsers;

            }
            catch
            {
                // Em caso de exceção durante o processamento, a exceção é propagada para ser tratada em um nível superior.
                throw;
            }

        }

        // Método responsável por deletar um usuário do banco de dados com base no seu "id".

        public bool Delete(int id)
        {
            try
            {
                // Busca o usuário correspondente pelo seu "id" no contexto "_context" usando "_context.usuarios.Find(id)".
                var getUsers = _context.usuarios.Find(id);

                // Se o usuário for encontrado, remove o objeto "Usuarios" do contexto "_context" usando "_context.Remove(getUsers)".
                if (getUsers != null)

                    if (getUsers != null)
                {
                    _context.Remove(getUsers);

                     // Salva as alterações no banco de dados usando "_context.SaveChanges()" para efetivamente deletar o usuário.
                    _context.SaveChanges();

                    return true;
                }

                // Retorna "false" caso o usuário não seja encontrado.
                return false;
            }
            catch
            {
                // Em caso de erro durante o processamento, retorna "false".
                return false;
            }
        }

        // Método que verifica se existe algum usuário no banco de dados com o e-mail fornecido.

        public bool ExistUsersEmail(string email)
        {
            return _context.usuarios.Any(u => u.Email.ToLower() == email.ToLower());
        }

        public List<Usuarios> GetallUsers()
        {
            var GetUsers = _context.usuarios.AsEnumerable().ToList();

            // Caso a lista obtida seja nula (nenhum usuário encontrado), lança uma exceção com a mensagem "Não foi possível encontrar usuário".
            if (GetUsers == null) throw new Exception("Não foi possível encontrar usuário");

            // Se houver usuários na lista, retorna a lista com todos os usuários cadastrados no banco de dados.
            return GetUsers;
        }

        // Método responsável por ler informações de um usuário do banco de dados com base em seu "id".

        public Usuarios Read(int id)
        {
            try
            {
                // Busca o usuário correspondente pelo seu "id" no contexto "_context" usando "_context.usuarios.Find(id)".
                var GetUserFromId = _context.usuarios.Find(id);

                // Se o usuário for encontrado, retorna o objeto "Usuarios" com as informações do usuário.
                if (GetUserFromId == null) throw new Exception("Não foi possível encontrar usuário");
                
                    return GetUserFromId;
                // Caso o usuário não seja encontrado, lança uma exceção com a mensagem "Não foi possível encontrar usuário".
            }
            catch
            {
                // Em caso de exceção durante o processamento, retorna um novo objeto "Usuarios" vazio.
                return new Usuarios();
            }
        }

        // Método responsável por atualizar as informações de um usuário no banco de dados.

        public bool Update(Usuarios usuario)
        {

            try
            {
                // Busca o usuário correspondente pelo seu "Id" no contexto "_context" usando "_context.usuarios.Find(usuario.Id)".
                var GetUsers = _context.usuarios.Find(usuario.Id);

                // Se o usuário for encontrado, atualiza seus dados com as informações fornecidas no objeto "usuario".
                if (GetUsers != null)
            {
                GetUsers.Nome = usuario.Nome;
                GetUsers.Email = usuario.Email;
                GetUsers.Data_Nascimento = usuario.Data_Nascimento;

                    // Salva as alterações no banco de dados usando "_context.SaveChanges()".
                    _context.SaveChanges();

                return true;
            }
                // Retorna "false" caso o usuário não seja encontrado.
                return false;
            }

            catch 
            {
                // Em caso de erro durante o processamento, retorna "false".
                return false; 
            }

        }
    }
    
}