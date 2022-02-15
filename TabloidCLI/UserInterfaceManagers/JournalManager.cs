using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class JournalManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private JournalRepository _journalRepository;
        private string _connectionString;

        public JournalManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _journalRepository = new JournalRepository(connectionString);
            _connectionString = connectionString;
        }
        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine(" 1) List Entries");
            Console.WriteLine(" 2) Add Entries");
            Console.WriteLine(" 3) Edit Entries");
            Console.WriteLine(" 4) Remove Entries");
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
            List<Journal> journalEntries = _journalRepository.GetAll();
            foreach (Journal entry in journalEntries)
            {
                Console.WriteLine(entry);
                Console.WriteLine("---------");
            }
        }

        private Journal Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose an Entry:";
            }

            Console.WriteLine(prompt);

            List<Journal> journalEntries = _journalRepository.GetAll();

            for (int i = 0; i < journalEntries.Count; i++)
            {
                Journal journal = journalEntries[i];
                Console.WriteLine($" {i + 1}) {journal.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return journalEntries[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private void Add()
        {
            Console.WriteLine("New Entry");
            Journal entry = new Journal();

            Console.Write("Entry Title: ");
            entry.Title = Console.ReadLine();

            Console.Write("Entry Content: ");
            entry.Content = Console.ReadLine();

            //This line auto captures Date & Time so user doesn't need to manually enter it.
            entry.CreateDateTime = DateTime.Now;

            _journalRepository.Insert(entry);
        }

        private void Edit()
        {
            Journal entryToEdit = Choose("Which entry would you like to edit?");
            if (entryToEdit == null)
            {
                return;
            }

            Console.WriteLine();
            Console.Write("New title (blank to leave unchanged): ");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                entryToEdit.Title = title;
            }
            Console.Write("New entry (blank to leave unchanged): ");
            string content = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(content))
            {
                entryToEdit.Content = content;
            }

            _journalRepository.Update(entryToEdit);
        }

        private void Remove()
        {
            Journal entryToDelete = Choose("Which entry would you like to remove?");
            if (entryToDelete != null)
            {
                _journalRepository.Delete(entryToDelete.Id);
            }
        }
    }
}
