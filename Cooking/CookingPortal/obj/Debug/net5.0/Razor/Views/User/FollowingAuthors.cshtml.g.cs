#pragma checksum "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0265cb56b898bea04b06af7ace56a10ac552fb5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_FollowingAuthors), @"mvc.1.0.view", @"/Views/User/FollowingAuthors.cshtml")]
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
#line 1 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml"
using Application.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0265cb56b898bea04b06af7ace56a10ac552fb5", @"/Views/User/FollowingAuthors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4b376b33640e51e4281f4fe4d5aabc6922c9aff", @"/Views/_ViewImports.cshtml")]
    public class Views_User_FollowingAuthors : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<UserDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml"
  
    ViewBag.Title = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\"row justify-content-md-center mb-4\">Following authors</h2>\r\n\r\n<ul class=\"authors\">\r\n");
#nullable restore
#line 11 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml"
     foreach (var user in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"author\">\r\n            <div class=\"card\" style=\"width: 18rem;\">\r\n                <img class=\"card-img-top cook\"");
            BeginWriteAttribute("src", " src=\"", 356, "\"", 373, 1);
#nullable restore
#line 15 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml"
WriteAttributeValue("", 362, user.Image, 362, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title link-primary\">");
#nullable restore
#line 17 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml"
                                                   Write(Html.ActionLink(user.FullName, "UserProfile", "User", new { userId = user.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <h6 class=\"card-subtitle mb-2 text-muted\">");
#nullable restore
#line 18 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml"
                                                         Write(user.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                    <ul class=\"navbar\">\r\n                        <li class=\"nav-item text-body-small\">\r\n                            <span class=\"link-without-visited-state\">\r\n                                <span class=\"t-bold\">");
#nullable restore
#line 22 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml"
                                                Write(user.Follower);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span> followers
                            </span>
                        </li>
                        <li class=""nav-item text-body-small"">
                            <span class=""link-without-visited-state"">
                                <span class=""t-bold"">");
#nullable restore
#line 27 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml"
                                                Write(user.Following);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> following\r\n                            </span>\r\n                        </li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 34 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\FollowingAuthors.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<UserDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
