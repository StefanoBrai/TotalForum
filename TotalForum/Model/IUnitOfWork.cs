using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotalForum.Model
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; set; }
        public IPostRepository PostRepository { get; set; }

        //Post
        Task<User> InsertUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> UpdateUser(User user);
        Task<List<User>> GetAllUser();
        Task<List<Post>> GetPostsByUserId(int userId);

        //User
        Task<Post> InsertPost(Post post);
        Task<bool> DeletePost(int id);
        Task<Post> UpdatePost(Post post);
        Task<List<Post>> GetAllPost();
        Task<List<User>> GetUserByName(string name);
        Task<User> GetUserById(int id);
    }
}
