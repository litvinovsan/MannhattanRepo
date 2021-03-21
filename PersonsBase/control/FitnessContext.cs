using System.Collections.Generic;
using System.Data.Entity;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.control
{
    // FIXME Тут недоделаны сами классы абонемент и Персон для работы с энтити.
    // Нужно прописать Id и протестить что добавление новых полей не порушит всё нафиг
    // SQlite
    // https://metanit.com/sharp/uwp/16.1.php
    // https://stackoverflow.com/questions/38557170/simple-example-using-system-data-sqlite-with-entity-framework-6
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("DbConnection") { }

        public DbSet<MyEmploee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
