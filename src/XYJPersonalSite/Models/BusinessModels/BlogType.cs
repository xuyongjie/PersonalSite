using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XYJPersonalSite.Models.BusinessModels;

public class BlogType{
    public const string TECH="Tech";
    public const string TECH_DESC="技术、专业相关";
    public const string LIFE="Life";
    public const string LIFE_DESC="生活感悟、思考和看法等";
    public const string IDEA="Idea";
    public const string IDEA_DESC="日常灵感、设想等";

    [Key]
    public string TypeName{get;set;}
    public string TypeDesc{get;set;}
    public int ThisTypeBlogCount{get;set;}
    public List<Blog> Blogs{get;set;}
}