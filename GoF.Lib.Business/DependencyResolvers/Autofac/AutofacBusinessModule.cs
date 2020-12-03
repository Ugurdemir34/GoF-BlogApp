using Autofac;
using GoF.Core.Utilities.Security.Jwt;
using GoF.Lib.Business.Abstract;
using GoF.Lib.Business.Concrete;
using GoF.Lib.DataAccess.Abstract;
using GoF.Lib.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Lib.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdminManager>().As<IAdminService>();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<TagManager>().As<ITagService>();
            builder.RegisterType<EfTagDal>().As<ITagDal>();   

            builder.RegisterType<QuestionManager>().As<IQuestionService>();
            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>();

            builder.RegisterType<ArticleManager>().As<IArticleService>();
            builder.RegisterType<EfArticleDal>().As<IArticleDal>();

            builder.RegisterType<ArticleTagManager>().As<IArticleTagService>();
            builder.RegisterType<EfArticleTagDal>().As<IArticleTagDal>();

            builder.RegisterType<AdminManager>().As<IAdminService>();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>();

            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>();
            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>();

            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();

            builder.RegisterType<SecondLevelCommentManager>().As<ISecondLevelCommentService>();
            builder.RegisterType<EfSecondLevelCommentDal>().As<ISecondLevelCommentDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
