using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    //журнал отображения происходящих с коллекцией событий
    public class Journal<T>
        where T : class, IInit<T>, ICloneable, new()
    {
        //определение одной записи журнала событий
        public class JournalEntry
        {
            public string? CollectionName { get; set; } //название изменяемой коллекции
            public string? ChangeType { get; set; } //тип изменений (напр. удаление, добавление или изменение)
            public T? Data { get; set; }    //объект коллекции, с которым связано событие

            public DateTime? Date { get; set; } = DateTime.Now;

            //конструктор
            public JournalEntry(object source, CollectionHandlerEventArgs<T> args)
            {
                CollectionName = ((MyNewCollection<T>)source).CollectionName;
                ChangeType = args.ChangeType;
                Data = args.Object;
            }
        }

        public string? JournalName { get; set; }
        public List<JournalEntry> journalEntries = new();
        public bool IsEmpty { get => journalEntries.Count == 0; }

        public Journal(string? journalName = "")
        {
            JournalName = journalName;
            journalEntries = new();
        }

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs<T> args)
        {
            journalEntries.Add(new JournalEntry(source, args));
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs<T> args)
        {
            journalEntries.Add(new JournalEntry(source, args));
        }

        public void ShowJournal()
        {
            foreach (var entry in journalEntries)
            {
                Console.WriteLine($"Журнал: {JournalName}\nКоллекция: {entry.CollectionName}\nДействие: {entry.ChangeType}\nВремя: {entry.Date}" );
                Console.WriteLine("\tОбъект: "+entry.Data);
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (var entry in journalEntries)
            {
                result += $"Журнал: {JournalName}\nКоллекция: {entry.CollectionName}\nДействие: {entry.ChangeType}\nВремя: {entry.Date}\n";
                result += "\tОбъект: " + entry.Data+"\n";
            }
            return result;
        }
    }
}
