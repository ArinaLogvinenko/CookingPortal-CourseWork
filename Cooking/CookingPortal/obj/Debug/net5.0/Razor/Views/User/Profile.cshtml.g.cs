#pragma checksum "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2ad50a06f50226177df66d63c13b7ac13992c32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Profile), @"mvc.1.0.view", @"/Views/User/Profile.cshtml")]
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
#line 1 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\Profile.cshtml"
using Application.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2ad50a06f50226177df66d63c13b7ac13992c32", @"/Views/User/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4b376b33640e51e4281f4fe4d5aabc6922c9aff", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\Profile.cshtml"
  
    ViewBag.Title = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"user-profile d-flex justify-content-center\">\r\n    <div class=\"card\" style=\"width: 18rem;\">\r\n        <img class=\"card-img-top cook\"");
            BeginWriteAttribute("src", " src=\"", 226, "\"", 244, 1);
#nullable restore
#line 10 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\Profile.cshtml"
WriteAttributeValue("", 232, Model.Image, 232, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n        <div class=\"card-body\">\r\n            <h5 class=\"card-title\">");
#nullable restore
#line 12 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\Profile.cshtml"
                              Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <h6 class=\"card-subtitle mb-2 text-muted\">");
#nullable restore
#line 13 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\Profile.cshtml"
                                                 Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n            <ul class=\"navbar\">\r\n                <li class=\"nav-item text-body-small\">\r\n                    <span class=\"link-without-visited-state\">\r\n                        <span class=\"t-bold\">");
#nullable restore
#line 17 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\Profile.cshtml"
                                        Write(Model.Follower);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> followers\r\n                    </span>\r\n                </li>\r\n                <li class=\"nav-item text-body-small\">\r\n                    <span class=\"link-without-visited-state\">\r\n                        <span class=\"t-bold\">");
#nullable restore
#line 22 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\Profile.cshtml"
                                        Write(Model.Following);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> following\r\n                    </span>\r\n                </li>\r\n            </ul>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 998, "\"", 1036, 1);
#nullable restore
#line 26 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\User\Profile.cshtml"
WriteAttributeValue("", 1005, Url.Action("EditUser", "User"), 1005, 31, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">\r\n                Edit profile\r\n            </a>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591