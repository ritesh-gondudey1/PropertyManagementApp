namespace PropertyManagement.Helper.Models
{
    public class PropertyModel
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public List<string> Features { get; set; }
        public List<string> Highlights { get; set; }
        public List<TransportationModel> Transportation { get; set; }
        public List<SpaceModel> Spaces { get; set; }
    }
}
