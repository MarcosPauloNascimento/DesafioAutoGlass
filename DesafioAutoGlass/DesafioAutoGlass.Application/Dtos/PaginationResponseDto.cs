using System.Collections.Generic;

namespace DesafioAutoGlass.Application.Dtos
{
    public class PaginationResponseDto<TDto>
    where TDto : class
    {
        public PaginationResponseDto(int currentPage,
            int count, 
            int pageSize, 
            int totalPages,
            List<TDto> result) 
        {
            this.CurrentPage = currentPage;
            this.Count = count;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.Result = result;
        }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IReadOnlyList<TDto> Result { get; set; } = new List<TDto>();
    }
}
