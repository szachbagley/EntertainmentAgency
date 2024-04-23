namespace EntertainmentAgency.Models
{
    public class EFDataRepo : IDataRepo
    {
        private DataContext _context;
        public EFDataRepo(DataContext temp)
        {
            _context = temp;
        }

        public List<Entertainer> Entertainers => _context.Entertainers.ToList();

        public Entertainer GetEntById(int id)
        {
            var ent = _context.Entertainers.Single(x => x.EntertainerID == id);
            return ent;
        }

        public void AddEnt(Entertainer ent)
        {
            _context.Entertainers.Add(ent);
            _context.SaveChanges();
        }

        public void UpdateEnt(Entertainer ent)
        {
            _context.Entertainers.Update(ent);
            _context.SaveChanges();
        }

        public void DeleteEnt(Entertainer ent)
        {
            _context.Entertainers.Remove(ent);
            _context.SaveChanges();
        }
    }
}
