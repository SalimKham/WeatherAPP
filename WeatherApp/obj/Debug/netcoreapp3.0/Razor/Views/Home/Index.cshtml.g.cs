#pragma checksum "C:\c#project\WeatherApp\WeatherApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a7f20dd75296fa8d4f60d94a7a44f790ac9ecee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\c#project\WeatherApp\WeatherApp\Views\_ViewImports.cshtml"
using WeatherApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\c#project\WeatherApp\WeatherApp\Views\_ViewImports.cshtml"
using WeatherApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\c#project\WeatherApp\WeatherApp\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a7f20dd75296fa8d4f60d94a7a44f790ac9ecee", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5982ed880600284e9d1c6d2e6f98bfd2936ac1ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\c#project\WeatherApp\WeatherApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"text-center\">\r\n        <br />\r\n        <br />\r\n        <br />\r\n\r\n        <h1 class=\"display-1 font-weight-bold font-italic\">Welcome</h1>\r\n\r\n");
#nullable restore
#line 16 "C:\c#project\WeatherApp\WeatherApp\Views\Home\Index.cshtml"
         if (SignInManager.IsSignedIn(User))
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <p> <a type=\"button\" class=\"btn btn-primary\" href=\"/cities\">List of Cities</a>.</p>\r\n");
#nullable restore
#line 20 "C:\c#project\WeatherApp\WeatherApp\Views\Home\Index.cshtml"
       }else {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <P class="" text-white font-weight-bold "">You are not logged in yet.</P>
        <P class=""text-white font-weight-bold ""> Please <a type=""button"" class=""btn btn-success"" href=""Identity/Account/Login"">Log in</a> Or <a type=""button"" class=""btn btn-primary"" href=""Identity/Account/Register"">Register</a> </P>
");
#nullable restore
#line 23 "C:\c#project\WeatherApp\WeatherApp\Views\Home\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
