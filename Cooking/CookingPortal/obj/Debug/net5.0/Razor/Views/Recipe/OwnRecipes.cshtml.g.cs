#pragma checksum "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "691558d9e3d6c4969d644e0485a168b2e4bf6d49"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recipe_OwnRecipes), @"mvc.1.0.view", @"/Views/Recipe/OwnRecipes.cshtml")]
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
#line 1 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
using Application.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"691558d9e3d6c4969d644e0485a168b2e4bf6d49", @"/Views/Recipe/OwnRecipes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4b376b33640e51e4281f4fe4d5aabc6922c9aff", @"/Views/_ViewImports.cshtml")]
    public class Views_Recipe_OwnRecipes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RecipeDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
  
    ViewBag.Title = "Own Recipes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"head mb-4\">\r\n    <h2 class=\"text-center\">Own Recipes</h2>\r\n\r\n    <div class=\"add_recipe text-right\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 227, "\"", 262, 1);
#nullable restore
#line 12 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
WriteAttributeValue("", 234, Url.Action("Add", "Recipe"), 234, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-success\">\r\n            Add Recipe\r\n        </a>\r\n    </div>\r\n</div>\r\n    \r\n    <ul class=\"recipes\">\r\n");
#nullable restore
#line 19 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
         foreach (var recipe in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card recipe_content mb-5\" style=\"width: 18rem;\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 533, "\"", 552, 1);
#nullable restore
#line 22 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
WriteAttributeValue("", 539, recipe.Image, 539, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title link-primary\">");
#nullable restore
#line 24 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                                   Write(Html.ActionLink(recipe.Name, "Index", "RecipeDetails", new { recipeId = recipe.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-subtitle mb-2 text-muted\">");
#nullable restore
#line 25 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                                        Write(recipe.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <h6 class=\"card-subtitle\">Ingredients:</h6>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 27 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                    Write(recipe.Ingredients);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <h6 class=\"card-subtitle\">Serving time:</h6>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 29 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                    Write(recipe.ServingTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <h6 class=\"card-subtitle\">Nutrition facts:</h6>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 31 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                    Write(recipe.NutritionFacts);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <h6 class=\"card-subtitle\">Author:</h6>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1345, "\"", 1421, 1);
#nullable restore
#line 33 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
WriteAttributeValue("", 1352, Url.Action("UserProfile", "User", new { userId = recipe.Author.Id }), 1352, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link-primary\">");
#nullable restore
#line 33 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                                                                                                    Write(recipe.Author.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    <div class=\"recipe-actions mt-3\">\r\n                        <div class=\"edit\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1602, "\"", 1668, 1);
#nullable restore
#line 36 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
WriteAttributeValue("", 1609, Url.Action("Edit", "Recipe", new { recipeId = recipe.Id }), 1609, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\">\r\n                                Edit\r\n                            </a>\r\n                        </div>\r\n                        <div class=\"delete mx-4\">\r\n");
#nullable restore
#line 41 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                             using (Html.BeginForm("Delete", "Recipe", new { recipeId = recipe.Id }, FormMethod.Post))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <button class=\"btn btn-outline-danger\">Delete</button>\r\n");
#nullable restore
#line 44 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <!--<div class=\"recipe\">\r\n                <h4>");
#nullable restore
#line 50 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
               Write(recipe.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                <div class=\"recipe_content\">-->\r\n");
            WriteLiteral("            <!--<div class=\"description_recipe\">\r\n                        <span class=\"description\">");
#nullable restore
#line 54 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                             Write(recipe.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"ingredients_recipe\">\r\n                        <span class=\"ingredients\">Ingredients: ");
#nullable restore
#line 57 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                                          Write(recipe.Ingredients);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"serving_time_recipe\">\r\n                        <span class=\"serving_time\">Serving time: ");
#nullable restore
#line 60 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                                            Write(recipe.ServingTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"nutrition_recipe\">\r\n                        <span class=\"nutrition\">Nutrition facts: ");
#nullable restore
#line 63 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                                            Write(recipe.NutritionFacts);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"author_recipe\">\r\n                        <span class=\"author\">Author: ");
#nullable restore
#line 66 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                                Write(recipe.Author.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                    <div class=\"author_recipe\">\r\n                        <span class=\"author\">Likes: ");
#nullable restore
#line 69 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                                               Write(recipe.Likes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n");
#nullable restore
#line 71 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                     using (Html.BeginForm("Delete", "Recipe", new { recipeId = recipe.Id }, FormMethod.Post))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button>DELETE</button>\r\n");
#nullable restore
#line 74 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a href=\"");
#nullable restore
#line 75 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
                        Write(Url.Action("Edit", "Recipe", new { recipeId = recipe.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        Edit\r\n                    </a>\r\n                </div>\r\n            </div>-->\r\n");
#nullable restore
#line 80 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Recipe\OwnRecipes.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n");
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
