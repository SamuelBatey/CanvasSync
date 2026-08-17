using System.Text.Json.Serialization;

namespace CanvasSync.Models {
    public class Stroke {
        public int ID { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public int Thickness { get; set; }
        public bool IsEraser { get; set; }

        [JsonIgnore]
        public Line Line { get; set; }
    }
}
