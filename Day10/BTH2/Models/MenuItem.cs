namespace BTH2.Models
{
    public class MenuItem
    {
        // ID của menu
        public int Id { get; set; }

        // Tên hiển thị
        public string Name { get; set; } = string.Empty;

        // Đường dẫn menu
        public string Link { get; set; } = string.Empty;
    }
}