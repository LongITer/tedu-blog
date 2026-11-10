
namespace TeduBlog.Core.Models
{
    public abstract class PageResultBase
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int RowCount { get; set; }

        // Read-only: Tự động tính toán số trang
        public int PageCount => PageSize > 0
            ? (int)Math.Ceiling((double)RowCount / PageSize)
            : 0;

        // Nếu không có dữ liệu (RowCount == 0) thì hàng đầu tiên là 0
        public int FirstRowOnPage => RowCount == 0
            ? 0
            : (CurrentPage - 1) * PageSize + 1;

        // Hàng cuối cùng không vượt quá tổng số hàng
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);

        public string? AdditionalData { get; set; }
    }
}
