#pragma checksum "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Settings\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "556f1855a84766b6040c4f4ba5abbdf277482a05"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Settings_Index), @"mvc.1.0.view", @"/Views/Settings/Index.cshtml")]
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
#line 1 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Settings\Index.cshtml"
using Application.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"556f1855a84766b6040c4f4ba5abbdf277482a05", @"/Views/Settings/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4b376b33640e51e4281f4fe4d5aabc6922c9aff", @"/Views/_ViewImports.cshtml")]
    public class Views_Settings_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SettingsDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Settings\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Settings</h2>\r\n\r\n<div class=\"settings\">\r\n    <div>\r\n        <span>Title</span>\r\n    </div>\r\n    <div>\r\n        <span>");
#nullable restore
#line 15 "D:\Study\3 year\Курсач\Cooking\CookingPortal\Views\Settings\Index.cshtml"
         Write(Model.FollowerSeeFollowers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SettingsDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
