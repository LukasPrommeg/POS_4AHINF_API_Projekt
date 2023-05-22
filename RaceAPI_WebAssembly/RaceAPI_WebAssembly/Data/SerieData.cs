namespace RaceAPI_WebAssembly.Data
{
    public class SerieData
    {
        public string name { get; set; }
        public List<RennenData> rennenList { get; set; }
        public List<int> punkteSystem { get; set; }
        public List<DriverData> fahrerfeld { get; set; }
        public Dictionary<int, int> gesamtWertung { get; set; }

        public SerieData()
        {

        }
        public SerieData(string name, List<RennenData> rennenList, List<int> punkteSystem, List<DriverData> fahrerfeld, Dictionary<int,int> gesamtWertung)
        {
            this.name = name;
            this.rennenList = rennenList;
            this.punkteSystem = punkteSystem;
            this.fahrerfeld = fahrerfeld;
            this.gesamtWertung = gesamtWertung;
        }
    }
}
