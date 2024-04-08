namespace AutoMapperMVC.Models.DTOs;

public class AddressDto
{
	public int Id { get; set; }
	public string Aciklama { get; set; }
	public string Sehir { get; set; }
	public string PostaKodu { get; set; }
	public int MusteriId { get; set; }
}
