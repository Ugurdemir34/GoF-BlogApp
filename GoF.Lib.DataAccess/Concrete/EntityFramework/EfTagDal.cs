using GoF.Core.DataAccess.EntityFramework;
using GoF.Lib.DataAccess.Abstract;
using GoF.Lib.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GoF.Lib.Entities.Dtos;

namespace GoF.Lib.DataAccess.Concrete.EntityFramework
{
    public class EfTagDal : EfEntityRepositoryBase<Tag, GoFContext>, ITagDal
    {
        public TagArticleTagDto GetTagsWhichArticleDoesNotHave(int articleId)
        {

            using (var _context = new GoFContext())
            {
                var hasTags = _context.ArticleTags.Where(i => i.ArticleId == articleId).ToList().Select(i=>i.TagId);
                var allTags = _context.Tags.ToList().Select(i=>i.Id);
                var result = allTags.Except(hasTags).ToList();
                var model = new TagArticleTagDto();
                for (int i = 0; i < result.Count(); i++)
                {
                    model.Tags.Add(new Tag()
                    {
                        Id = result[i],
                        TagName=_context.Tags.Where(a=>a.Id==result[i]).Select(a=>a.TagName).FirstOrDefault().ToString()

                    });
                }                             
                return model;
            }
        }
    }
}
