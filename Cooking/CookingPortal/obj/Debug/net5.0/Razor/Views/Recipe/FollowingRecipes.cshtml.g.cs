#pragma checksum "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f085f74aac7f06c7878cb5691d62aa883b09226"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recipe_FollowingRecipes), @"mvc.1.0.view", @"/Views/Recipe/FollowingRecipes.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\_ViewImports.cshtml"
using CookingPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\_ViewImports.cshtml"
using CookingPortal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
using Application.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f085f74aac7f06c7878cb5691d62aa883b09226", @"/Views/Recipe/FollowingRecipes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4b376b33640e51e4281f4fe4d5aabc6922c9aff", @"/Views/_ViewImports.cshtml")]
    public class Views_Recipe_FollowingRecipes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RecipeDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
  
    ViewBag.Title = "FollowingRecipes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"row justify-content-md-center mb-4\">Recipes</h2>\r\n\r\n<ul class=\"recipes\">\r\n");
#nullable restore
#line 11 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
     foreach (var recipe in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card recipe_content mb-5\" style=\"width: 18rem;\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 322, "\"", 341, 1);
#nullable restore
#line 14 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
WriteAttributeValue("", 328, recipe.Image, 328, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title link-primary\">");
#nullable restore
#line 16 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
                                               Write(Html.ActionLink(recipe.Name, "Index", "RecipeDetails", new { recipeId = recipe.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-subtitle mb-2 text-muted\">");
#nullable restore
#line 17 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
                                                    Write(recipe.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <h6 class=\"card-subtitle\">Ingredients:</h6>\r\n                <p class=\"card-text\">");
#nullable restore
#line 19 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
                                Write(recipe.Ingredients);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <h6 class=\"card-subtitle\">Serving time:</h6>\r\n                <p class=\"card-text\">");
#nullable restore
#line 21 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
                                Write(recipe.ServingTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <h6 class=\"card-subtitle\">Nutrition facts:</h6>\r\n                <p class=\"card-text\">");
#nullable restore
#line 23 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
                                Write(recipe.NutritionFacts);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <h6 class=\"card-subtitle\">Author:</h6>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1090, "\"", 1166, 1);
#nullable restore
#line 25 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
WriteAttributeValue("", 1097, Url.Action("UserProfile", "User", new { userId = recipe.Author.Id }), 1097, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link-primary\">");
#nullable restore
#line 25 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
                                                                                                                Write(recipe.Author.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 28 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\FollowingRecipes.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RecipeDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591