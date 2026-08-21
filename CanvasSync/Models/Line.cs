using System.Text.Json.Serialization;

namespace CanvasSync.Models {
    public class Line {
        public int ID { get; set; }
        public string BoardID { get; set; }

        // Nav property for the strokes that make up this line
        public ICollection<Stroke> Strokes { get; set; } = new List<Stroke>();
    }
}
