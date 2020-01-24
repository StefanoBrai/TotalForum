using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotalForum.Model
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; set; }
        public IPostRepository PostRepository { get; set; }

        public EFUnitOfWork(IUserRepository userRepository, IPostRepository postRepository)
        {
            UserRepository = userRepository;
            PostRepository = postRepository;
        }

        //Post
        public Task<List<Post>> GetAllPost()
        {
            return PostRepository.GetAllPost();
        }
        
        public Task<Post> InsertPost(Post post)
        {
            return PostRepository.InsertPost(post);
        }

        public Task<Post> UpdatePost(Post post)
        {
            return PostRepository.UpdatePost(post);
        }

        public Task<bool> DeletePost(int id)
        {
            return PostRepository.DeletePost(id);
        }

        public Task<List<Post>> GetPostsByUserId(int userId)
        {
            return PostRepository.GetPostsByUserId(userId);
        }

        //User
        public Task<List<User>> GetAllUser()
        {
            return UserRepository.GetAllUser();
        }
        
        public Task<User> InsertUser(User user)
        {
            return UserRepository.InsertUser(user);
        }

        public Task<User> UpdateUser(User user)
        {
            return UserRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            //var asDeletedPosts = await PostRepository.DeletePostsByUserId(id);

            //if (asDeletedPosts)
            //{
            //    return await UserRepository.DeleteUser(id);
            //}

            //return false;

            return await PostRepository.DeletePostsByUserId(id) ? await UserRepository.DeleteUser(id) : false;
        }

        public Task<List<User>> GetUserByName(string name)
        {
            return UserRepository.SearchUserByName(name);
        }

        public Task<User> GetUserById(int id)
        {
            return UserRepository.GetUserById(id);
        }
    }
}
