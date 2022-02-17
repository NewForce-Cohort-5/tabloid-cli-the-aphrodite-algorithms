﻿using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    public class NoteManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private NoteRepository _noteRepository;
        private string _connectionString;


        public NoteManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _noteRepository = new NoteRepository(connectionString);
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
            //    case "1":
            //        List();
            //        return this;
                case "2":
                    Add();
                    return this;
             //   case "3":
             //       Remove();
             //       return this;
                    
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

       // private void List()
        //{
            //List<Note> noteList = _noteRepository.GetAll();
            //foreach (Note note in noteList)
            //{
        //        Console.WriteLine(note);
        //        Console.WriteLine("---------");
        //    }
       // }

       // private Note Choose(string prompt = null)
       // {
        //    if (prompt == null)
        //    {
        //        prompt = "Please choose a Note:";
         //   }

         //   Console.WriteLine(prompt);

         //   List<Note> noteEntries = _noteRepository.GetAll();

         //   for (int i = 0; i < noteEntries.Count; i++)
         //   {
         //       Note note = noteEntries[i];
         //       Console.WriteLine($" {i + 1}) {note.Title}");
         //   }
         //   Console.Write("> ");

        //    string input = Console.ReadLine();
        //    try
        //    {
         //       int choice = int.Parse(input);
        //        return noteEntries[choice - 1];
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("Invalid Selection");
        //        return null;
        //    }
        //}

        private void Add()
        {
            Console.WriteLine("New Note");
            Note note = new Note();

            Console.WriteLine("Title: ");
            note.Title = Console.ReadLine();

            Console.WriteLine("Note Content: ");
            note.Content = Console.ReadLine();

            Console.WriteLine("Publish Date: ");
            note.CreateDateTime = DateTime.Parse(Console.ReadLine());


            //post.Blog = ChooseBlog("Please choose a blog for this post");

            _noteRepository.Insert(note);
        }

        //private void Remove()
        //{
        //    Note noteToDelete = Choose("Which note would you like to remove?");
        //    if (noteToDelete != null)
        //    {
        //        _noteRepository.Delete(noteToDelete.Id);
        //    }
        //}



    }
}
