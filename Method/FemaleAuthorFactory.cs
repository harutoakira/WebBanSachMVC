using QuanLyThuVien.Models;

namespace QuanLyThuVien.Method
{
    public class FemaleAuthorFactory : AuthorFactory
    {
        public override Author GetAuthor(int authorId,string authorName, string address, string history, string phoneNumber)
        {
            FemaleAuthor postAuthor = new FemaleAuthor(authorName, address, history, phoneNumber);
            Author author = new Author()
            {
                AuthorId = postAuthor.AuthorId,
                AuthorName = postAuthor.AuthorName,
                Address = postAuthor.Address,
                History = postAuthor.History,
                PhoneNumber = postAuthor.PhoneNumber,
                Sex = postAuthor.Sex,
            };
            return author;
        }

        public override Author PostAuthor(string authorName, string address, string history, string phoneNumber)
        {
            FemaleAuthor postAuthor = new FemaleAuthor(authorName, address, history, phoneNumber);
            Author author = new Author()
            {
                AuthorName = postAuthor.AuthorName,
                Address = postAuthor.Address,
                History = postAuthor.History,
                PhoneNumber = postAuthor.PhoneNumber,
                Sex = postAuthor.Sex,
            };
            return author;
        }
    }
}
