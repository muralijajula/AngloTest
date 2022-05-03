namespace AA.CommoditiesDashboard.Infrastructure.Entities
{
    public class Commodity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public Model Model { get; set; }
    }
}
