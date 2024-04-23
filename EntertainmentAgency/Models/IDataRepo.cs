namespace EntertainmentAgency.Models
{
    public interface IDataRepo
    {
        public List<Entertainer> Entertainers { get; }

        public Entertainer GetEntById(int id);
        public void AddEnt(Entertainer ent);
        public void UpdateEnt(Entertainer ent);
        public void DeleteEnt(Entertainer ent);
    }
}
