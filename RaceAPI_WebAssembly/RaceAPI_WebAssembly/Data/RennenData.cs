namespace RaceAPI_WebAssembly.Data
{
    public class RennenData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ort { get; set; }
        public List<int> ergebnis { get; set; }
        public string serie { get; set; }

        public RennenData()
        {

        }
        public RennenData(string id, string name, string ort, List<int> ergebnis)
        {
            this.id = id;
            this.name = name;
            this.ort = ort;
            this.ergebnis = ergebnis;
        }
    }
}
