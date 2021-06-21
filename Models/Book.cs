using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace lab02.Models
{
    public class Book
    {
        public Book()
        {

        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [Required(ErrorMessage ="Tieu de khong duoc trong")]
        [StringLength(250,ErrorMessage ="Tieu de sach khong duoc vuot qua 250 ky tu")]
        [Display(Name ="Tieu de")]
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string author;

        public string Author
        {
            get { return author;; }
            set { author = value; }
        }
        private string imageCover;

        public string ImageCover
        {
            get { return imageCover; }
            set { imageCover = value; }
        }

        public Book(int id,string title, string author, string image_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.imageCover = image_cover;
        }

    }
}