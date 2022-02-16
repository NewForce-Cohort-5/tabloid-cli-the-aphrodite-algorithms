using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class TagManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private TagRepository _tagRepository;
        private string _connectionString;

        public TagManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _tagRepository = new TagRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Tag Menu");
            Console.WriteLine(" 1) List Tags");
            Console.WriteLine(" 2) Add Tag");
            Console.WriteLine(" 3) Edit Tag");
            Console.WriteLine(" 4) Remove Tag");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    Add();
                    return this;
                case "3":
                    Edit();
                    return this;
                case "4":
                    Remove();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            Console.WriteLine("Tag List:");

            List<Tag> tags = _tagRepository.GetAll();
            foreach (Tag tag in tags)
            {
                Console.WriteLine($"#{tag}");
            }
            Console.WriteLine();
        }

        private void Add()
        {
            Console.WriteLine();

            //Console.WriteLine("New Tag");
            Tag tag = new Tag();

            Console.Write("Enter a new tag name: ");
            tag.Name = Console.ReadLine();

            _tagRepository.Insert(tag);

            Console.WriteLine("Thank you, your new tag has been entered.");
            Console.WriteLine();
        }

        private void Edit()
        {
            Console.WriteLine();
            throw new NotImplementedException();
        }

        private void Remove()
        {
            Console.WriteLine();
            throw new NotImplementedException();

        }
    }
}
