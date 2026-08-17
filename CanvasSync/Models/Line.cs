using System.Text.Json.Serialization;

namespace CanvasSync.Models {
    public class Line {
        public int ID { get; set; }
        public string BoardID { get; set; }
        public ICollection<Stroke> Strokes { get; set; }
    }
}
