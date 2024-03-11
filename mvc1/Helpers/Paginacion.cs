namespace mvc1.Helpers
{
    public class Paginacion
    {
        public int CurrentPage { get; private set; }
        public int ItemsPerPage { get; private set; } = 10;
        public int TotalItems { get; private set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        public int StartIndex => (CurrentPage - 1) * ItemsPerPage;
        public string Filtros { get; set; }
        public Paginacion(int currentPage, int totalItems)
        {
            CurrentPage = Math.Max(1, currentPage);
            TotalItems = totalItems;
        }
    }
}
