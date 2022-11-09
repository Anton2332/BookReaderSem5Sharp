namespace BLL2.DTO.Response;

public class BookResponseDTO
{
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public int StatusId { get; set; }
}