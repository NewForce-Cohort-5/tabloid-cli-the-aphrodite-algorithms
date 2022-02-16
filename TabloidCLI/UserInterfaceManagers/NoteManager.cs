using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class NoteManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private NoteRepository _NoteRepository;
        private string _connectionString;

        public NoteManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _NoteRepository = new NoteRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Note Menu");
            Console.WriteLine(" 1) List Notes");
            Console.WriteLine(" 2) Add Notes");
            Console.WriteLine(" 3) Remove Notes");
            Console.WriteLine(" 4) Note Management");
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
                    Remove();
                    return this;
                case "4":
                    throw new NotImplementedException();
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            List<Note> notes = _noteRepository.GetAll();
            foreach (Note note in notes)
            {
                Console.WriteLine(note);
            }
        }

        private void Add()
        {
            Console.WriteLine("New Note");
            Note note = new Note();

            Console.WriteLine("Title: ");
            note.Title = Console.ReadLine();

            Console.WriteLine("Post URL: ");
            note.Content = Console.ReadLine();

            Console.WriteLine("Publish Date: ");
            note.PublishDateTime = DateTime.Parse(Console.ReadLine());

            //note.Author = ChooseAuthor("Please choose an author for this post:");

            //post.Blog = ChooseBlog("Please choose a blog for this post");

            _noteRepository.Insert(note);
        }

        private void Remove()
        {
            Note noteToDelete = Choose("Which note would you like to remove?");
            if (noteToDelete != null)
            {
                _noteRepository.Delete(noteToDelete.Id);
            }
        }



    }
}
