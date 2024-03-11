namespace mvc1.Helpers
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Filtros { get; set; }
        public int PreviousPage => CurrentPage - 1;
        public int NextPage => CurrentPage + 1;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int StartPage => CurrentPage - 3 < 1 ? 1 : CurrentPage - 3;
        public int EndPage => CurrentPage + 3 > TotalPages ? TotalPages : CurrentPage + 3;

    }
}
