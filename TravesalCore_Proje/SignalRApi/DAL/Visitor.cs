namespace SignalRApi.DAL
{
    public enum ECity
    {
        Edirne = 1,
        Ankara = 2,
        İstanbul = 3,
        İzmir = 4,
        Antalya = 5
    }

    public class Visitor
    {
        public int VisitorID { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }

    }
}
