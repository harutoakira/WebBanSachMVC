namespace QuanLyThuVien.Method
{
    public interface IAuthor
    {
        int AuthorId { get; set; }
        string AuthorName { get; set; }
        string AuthorPic { get; set; }
        string Address { get; set; }
        string History { get; set; }
        string PhoneNumber { get; set; }
        int getAuthorId();
        string getAuthorName();
        string getAuthorAddress();
        string getAuthorPicture();
        string getAuthorPhone();
        string getAuthorBackground();
    }
}
