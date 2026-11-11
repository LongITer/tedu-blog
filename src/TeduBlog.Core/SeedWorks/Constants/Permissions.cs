using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Core.SeedWorks.Constants
{
    public static class Permissions
    {
        public static class Dashboard
        {
            public const string View = "Permissions.Dashboard.View";
        }
        public static class Roles
        {
            [Description("Xem vai trò")]
            public const string View = "Permissions.Roles.View";
            [Description("Tạo vai trò")]
            public const string Create = "Permissions.Roles.Create";
            [Description("Cập nhật vai trò")]
            public const string Update = "Permissions.Roles.Update";
            [Description("Xóa vai trò")]
            public const string Delete = "Permissions.Roles.Delete";
        }
        public static class Users
        {
            [Description("Xem người dùng")]
            public const string View = "Permissions.Users.View";
            [Description("Tạo người dùng")]
            public const string Create = "Permissions.Users.Create";
            [Description("Cập nhật người dùng")]
            public const string Update = "Permissions.Users.Update";
            [Description("Xóa người dùng")]
            public const string Delete = "Permissions.Users.Delete";
        }
        public static class Series
        {
            [Description("Xem series")]
            public const string View = "Permissions.Series.View";
            [Description("Tạo series")]
            public const string Create = "Permissions.Series.Create";
            [Description("Cập nhật series")]
            public const string Update = "Permissions.Series.Update";
            [Description("Xóa series")]
            public const string Delete = "Permissions.Series.Delete";
        }
        public static class Posts
        {
            [Description("Xem bài viết")]
            public const string View = "Permissions.Posts.View";
            [Description("Tạo bài viết")]
            public const string Create = "Permissions.Posts.Create";
            [Description("Cập nhật bài viết")]
            public const string Update = "Permissions.Posts.Update";
            [Description("Xóa bài viết")]
            public const string Delete = "Permissions.Posts.Delete";
        }
        public static class PostCategories
        {
            [Description("Xem danh mục bài viết")]
            public const string View = "Permissions.PostCategories.View";
            [Description("Tạo danh mục bài viết")]
            public const string Create = "Permissions.PostCategories.Create";
            [Description("Cập nhật danh mục bài viết")]
            public const string Update = "Permissions.PostCategories.Update";
            [Description("Xóa danh mục bài viết")]
            public const string Delete = "Permissions.PostCategories.Delete";
        }
    }
}
