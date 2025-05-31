namespace PropertyManagement.Helper.Models
{
    public class TransportationModel
    {
        private string _distance;
        public string Type { get; set; }
        public string Line { get; set; }
        public string Distance
        {
            get => _distance;
            set => _distance = !string.IsNullOrEmpty(value) ? $"({value})" : value;
        }
        public string Station { get; set; }
    }
}
