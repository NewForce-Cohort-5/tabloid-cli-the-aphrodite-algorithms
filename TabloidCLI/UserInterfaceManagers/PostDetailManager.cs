using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class PostDetailManager : IUserInterfaceManager
    {
        private IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private AuthorRepository _authorRepository;
        private TagRepository _tagRepository;
        private int _postId;
        private string _connectionString;
       

        public PostDetailManager(IUserInterfaceManager parentUI, string connectionString, int postId)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _authorRepository = new AuthorRepository(connectionString);
            _tagRepository = new TagRepository(connectionString);
            _postId = postId;
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Post post = _postRepository.Get(_postId);
            Console.WriteLine($"{post.Title} Details");
            Console.WriteLine(" 1) View");
            Console.WriteLine(" 2) Add Tag");
            Console.WriteLine(" 3) Remove Tag");
            Console.WriteLine(" 4) Note Management");
            Console.WriteLine(" 0) Return");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    View(post);
                    return this;
                case "2":
                    throw new NotImplementedException();
                case "3":
                    throw new NotImplementedException();
                case "4":
                    return new NoteManager(this, _connectionString, _postId);
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }

        }

        private void View(Post post)
        {
            Console.WriteLine($"Title: {post.Title}");
            Console.WriteLine($"URL: {post.Url}");
            Console.WriteLine($"Publish Date: {post.PublishDateTime}");
            Console.WriteLine($"Author: {post.Author.FullName}");
            Console.WriteLine($"Blog: {post.Blog.Title}");
            Console.WriteLine("Tags:");
            foreach (Tag tag in post.Tags)
            {
                Console.WriteLine("#" + tag);
            }
            Console.WriteLine();
        }
    }
}
