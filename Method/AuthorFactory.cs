using QuanLyThuVien.Models;

namespace QuanLyThuVien.Method
{
    public abstract class AuthorFactory
    {
        public abstract Author GetAuthor(int author,string authorName, string address, string history, string phoneNumber);
        public abstract Author PostAuthor(string authorName, string address, string history, string phoneNumber);
    }
}
