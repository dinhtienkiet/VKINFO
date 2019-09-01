using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VKINFO.APPLICATION.BookCategoryList.Queries.GetBookCategoryList;
using VKINFO.APPLICATION.Authors.Queries.GetAllAuthor;
using VKINFO.APPLICATION.Authors.Queries.GetAuthor;
using VKINFO.APPLICATION.BooksUI.Queries.GetBook;
using VKINFO.APPLICATION.GenreList.Queries.GetGenreList;
using VKINFO.APPLICATION.ChapterUI.Queries.GetChapter;
using VKINFO.APPLICATION.Users.Queries.GetUser;
using VKINFO.DOMAIN.Entities;
using VKINFO.APPLICATION.BooksAdmin.Queries.getBookAdminById;
using VKINFO.APPLICATION.BooksAdmin.Commands.UpdateBookAdmin;
using VKINFO.APPLICATION.CategoryAdmin.Queries.GetAllCategoryAdmin;
using VKINFO.APPLICATION.AuthorUI.Queries.GetAuthorList;
using VKINFO.APPLICATION.GenreAdmin.Queries.GetAllGenreAdmin;
using VKINFO.APPLICATION.GenreAdmin.Queries.GetGenreAdmin;
using VKINFO.APPLICATION.Queries.BooksAdmin.GetAllBookAdmin;
using VKINFO.APPLICATION.Users.Queries.Login;
using VKINFO.APPLICATION.CategoryAdmin.Queries.GetCategoryAdminByID;

namespace VKINFO.APPLICATION.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ChapterAdminByIdBookViewModelMap();
            CategoryAdminMap();
            UserViewModelMap();
            BookViewModelMap();
            CategoryListViewModelMap();
            GenreListViewModelMap();
            ChapterViewModelMap();
            AuthorListViewModelMap();
            BookAdminViewModelMap();
            AuthorAdminViewModelMap();
            AuthorViewModelMap();
            UserLoginViewModelMap();
        }

        private void UserLoginViewModelMap()
        {
            CreateMap<User, UserLoginViewModel>();
            CategoryAdminMap();
        }

        private void BookAdminViewModelMap()
        {
            CreateMap<Book, BookAdminViewModel>()
                 .ForMember(d => d.AuthorName, opt => opt.MapFrom(s => s.Author.FullName))
                 .ForMember(d => d.ChapterNumber, opt => opt.MapFrom(s => s.Chapters.Count()));
            CreateMap<Book, BookAminViewModelById>()
                .ForMember(det => det.chapterAdminByIdBookViewModels, opt => opt.MapFrom(s => s.Chapters))
                .ForMember(det => det.CategoriesID, opt => opt.MapFrom(s => s.BookCategories.Select(u => u.Category.Id)))
                .ForMember(det => det.GenreID, opt => opt.MapFrom(s => s.BookGenres.Select(u => u.Genre.Id))
                );
        }

        private void ChapterAdminByIdBookViewModelMap()
        {
            CreateMap<Chapter,ChapterAdminByIdBookViewModel>()
                .ForMember(det => det.StatusBook, opt => opt.MapFrom(s => s.Book.Status));
        }

        public void CategoryAdminMap()
        {
            CreateMap<Category, CategoryAdminViewModelById>();
            CreateMap<Category, CategoryAdminViewModel>()
                 .ForMember(d => d.numberBook, opt => opt.MapFrom(s => s.BookCategories.Count()));
        }

        private void AuthorAdminViewModelMap()
        {
            CreateMap<Author, AuthorAdminViewModel>().ForMember(det => det.numberBook,d => d.MapFrom(u => u.Books.Count()));
        }
        private void AuthorViewModelMap()
        {
            CreateMap<Author, AuthorViewModel>();
        }

        public void UserViewModelMap()
        {
            CreateMap<User, UserViewModel>();
        }
        public void BookViewModelMap()
        {
            CreateMap<Book, BookViewModel>();
        }
        public void CategoryListViewModelMap()
        {
            CreateMap<Category, CategoryListViewModel>();
        }
        public void GenreListViewModelMap()
        {
            CreateMap<Genre, GenreAdminViewModel>();
            CreateMap<Genre, GenreDetailAdminViewModel>();
        }
        public void ChapterViewModelMap()
        {
            CreateMap<Chapter, ChapterViewModel>();
        }
        public void AuthorListViewModelMap()
        {
            CreateMap<Author, AuthorListViewModel>();
        }
    }
}
