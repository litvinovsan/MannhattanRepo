using System.Collections.Generic;
using System.Data.Entity;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.control
{
    // FIXME Тут недоделаны сами классы абонемент и Персон для работы с энтити.
    // Нужно прописать Id и протестить что добавление новых полей не порушит всё нафиг

    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("DbConnection") { }

        public DbSet<Dictionary<string, List<AbonementBasic>>> Abonements { get; set; }
    }
}
