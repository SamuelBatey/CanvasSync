namespace CanvasSync.Models {
    public class Board {
        public string ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }

        // Navigation property for all the lines in the board
        public ICollection<Line> Lines { get; set; } = new List<Line>();
    }
}
