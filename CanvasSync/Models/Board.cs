namespace CanvasSync.Models {
    public class Board {
        public string ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public ICollection<Line> Lines { get; set; } = new List<Line>();
    }
}
