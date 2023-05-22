namespace RaceAPI_WebAssembly.Data
{
    public class DriverData
    {
        public int number { get; set; }
        public string name { get; set; }
        public string team { get; set; }

        public string serie = "";

        public DriverData() 
        {
            
        }
        public DriverData(int number, string name, string team) 
        {
            this.number = number;
            this.name = name;
            this.team = team;
        }
    }
}
