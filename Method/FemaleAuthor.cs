﻿using QuanLyThuVien.Models;

namespace QuanLyThuVien.Method
{
    public class FemaleAuthor: Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Address { get; set; }
        public string History { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public FemaleAuthor()
        {
            this.AuthorName = "Anonymous ";
            this.Address = "Secret";
            this.History = "Update";
            this.PhoneNumber = "Update";
            this.Sex = "Male";
        }

        public FemaleAuthor(string authorName, string address, string history, string phoneNumber)
        {
            this.AuthorName = authorName;
            this.Address = address;
            this.History = history;
            this.PhoneNumber = phoneNumber;
            this.Sex = "Female";
        }
        public FemaleAuthor(int authorId, string authorName, string address, string history, string phoneNumber)
        {
            this.AuthorId = authorId;
            this.AuthorName = authorName;
            this.Address = address;
            this.History = history;
            this.PhoneNumber = phoneNumber;
            this.Sex = "Female";
        }
    }
}
