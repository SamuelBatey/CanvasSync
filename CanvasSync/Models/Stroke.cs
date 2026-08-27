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
        public string Color { get; set; } = "#000000";

        // Navigation property for the line this stroke is a part of
        // JsonIgnore is needed to prevent loop when encoding stroke data to Json
        [JsonIgnore]
        public Line Line { get; set; }
    }
}
