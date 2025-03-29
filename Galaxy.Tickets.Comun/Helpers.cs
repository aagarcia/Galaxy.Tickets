namespace Galaxy.Tickets.Comun
{
	public static class Helpers
	{
		public static int CalcularNumeroPaginas(int TotalRegistros, int NumeroFilas)
		{
			return (int)Math.Ceiling((double)TotalRegistros / NumeroFilas);
		}
	}
}
