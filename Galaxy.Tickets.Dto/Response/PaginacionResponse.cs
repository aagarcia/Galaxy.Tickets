namespace Galaxy.Tickets.Dto.Response
{
	public class PaginacionResponse<T> : BaseResponse
	{
		public ICollection<T> Data { get; set; } = new List<T>();
		public int TotalFilas { get; set; }
		public int TotalPaginas { get; set; }
	}
}
