namespace Hotel.Models
{
    public class ImmaginiCamera
    {
        public int Id { get; set; }
        public int CameraId { get; set; }
        public string ImmagineCover { get; set; }
        public string Immagine1 { get; set; }
        public string Immagine2 { get; set; }
        public string Immagine3 { get; set; }
        public Camera Camera { get; set; }
    }
}
